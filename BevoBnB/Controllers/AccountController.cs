using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


using BevoBnB.DAL;
using BevoBnB.Models;
using BevoBnB.Utilities;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace BevoBnB.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly PasswordValidator<AppUser> _passwordValidator;
        private readonly AppDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(AppDbContext appDbContext, UserManager<AppUser> userManager, SignInManager<AppUser> signIn, RoleManager<IdentityRole> roleManager)
        {
            _context = appDbContext;
            _userManager = userManager;
            _signInManager = signIn;
            //user manager only has one password validator
            _passwordValidator = (PasswordValidator<AppUser>)userManager.PasswordValidators.FirstOrDefault();
            _roleManager = roleManager;
        }

        // GET: /Account/Register
        [AllowAnonymous]
        public IActionResult Register()
        {
            // Check if the user is authenticated
            if (User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Host") || User.IsInRole("Customer"))
                {
                    return View("Error", new string[] { "You are not authorized to access this page." });
                }
            }

            // Allow access for anonymous users or admins
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(RegisterViewModel rvm)
        {
            // Validate the model state
            if (!ModelState.IsValid)
            {
                return View(rvm);
            }

            // Initialize error messages list
            ViewBag.ErrorMessages = new List<string>();

            // Admin-specific logic
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                // Admin must be 18 years or older
                if (!Is18OrOlder(rvm.DOB))
                {
                    return View("Error", new String[] { "You need to be 18 years or older to register an account." });
                }

                // Admins can only create admin accounts
                if (!AdminEmailFormat(rvm.Email))
                {
                    ViewBag.ErrorMessages.Add("All admin emails need to end with @bevobnb.com.");
                    return View(rvm);
                }

                // Check if the email already exists
                if (EmailAlreadyExists(rvm.Email))
                {
                    ViewBag.ErrorMessages.Add("The provided email is already in use.");
                    return View(rvm);
                }

                AppUser newAdmin = new AppUser
                {
                    UserName = rvm.Email,
                    Email = rvm.Email,
                    PhoneNumber = rvm.PhoneNumber,
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                    LineAddress = rvm.LineAddress,
                    DOB = rvm.DOB
                };

                AddUserModel adminAum = new AddUserModel
                {
                    User = newAdmin,
                    Password = rvm.Password,
                    RoleName = "Admin"
                };

                IdentityResult adminResult = await Utilities.AddUser.AddUserWithRoleAsync(adminAum, _userManager, _context);

                if (adminResult.Succeeded)
                {
                    // Admin stays logged in, no redirection to login
                    return RedirectToAction("Profiles", "Account");
                }
                else
                {
                    foreach (var error in adminResult.Errors)
                    {
                        ViewBag.ErrorMessages.Add(error.Description);
                    }
                    return View(rvm);
                }
            }

            // Anonymous user-specific logic
            else
            {
                // Check if the user is 18 or older
                if (!Is18OrOlder(rvm.DOB))
                {
                    return View("Error", new String[] { "You need to be 18 years or older to register an account." });
                }

                // Check if the email already exists
                if (EmailAlreadyExists(rvm.Email))
                {
                    ViewBag.ErrorMessages.Add("The provided email is already in use.");
                    return View(rvm);
                }

                // Determine role based on checkbox
                string roleName = rvm.IsHostAccount ? "Host" : "Customer";

                AppUser newUser = new AppUser
                {
                    UserName = rvm.Email,
                    Email = rvm.Email,
                    PhoneNumber = rvm.PhoneNumber,
                    FirstName = rvm.FirstName,
                    LastName = rvm.LastName,
                    LineAddress = rvm.LineAddress,
                    DOB = rvm.DOB
                };

                AddUserModel aum = new AddUserModel
                {
                    User = newUser,
                    Password = rvm.Password,
                    RoleName = roleName
                };

                IdentityResult result = await Utilities.AddUser.AddUserWithRoleAsync(aum, _userManager, _context);

                if (result.Succeeded)
                {
                    // Automatically log in the user after successful registration
                    await _signInManager.PasswordSignInAsync(rvm.Email, rvm.Password, isPersistent: false, lockoutOnFailure: false);

                    // Redirect to the home page
                    return RedirectToAction("Index", "Properties");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ViewBag.ErrorMessages.Add(error.Description);
                    }
                    return View(rvm);
                }
            }
        }




        // GET: /Account/Login
        [AllowAnonymous]
        public IActionResult Login(string? returnUrl)
        {
            if (User.Identity.IsAuthenticated) //user has been redirected here from a page they're not authorized to see
            {
                return View("Error", new string[] { "Access Denied" });
            }
            _signInManager.SignOutAsync(); //this removes any old cookies hanging around
            ViewBag.ReturnUrl = returnUrl; //pass along the page the user should go back to
            return View();
        }

        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel lvm, string? returnUrl)
        {
            // If the model state is invalid, return to the login view with errors
            if (!ModelState.IsValid)
            {
                return View(lvm);
            }

            // Check if the user is terminated before attempting login
            if (IsEmployeeTerminated(lvm.Email))
            {
                // Add an error to the model state for feedback
                ModelState.AddModelError("", "Your account is terminated and you cannot log in.");
                return View(lvm);
            }

            // Attempt to sign the user in using the SignInManager
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(
                lvm.Email,
                lvm.Password,
                lvm.RememberMe,
                lockoutOnFailure: false
            );

            // If the login was successful, redirect to returnUrl or home
            if (result.Succeeded)
            {
                return Redirect(returnUrl ?? "/");
            }
            else // Login attempt failed
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(lvm);
            }
        }


        public IActionResult AccessDenied()
        {
            return View("Error", new string[] { "You are not authorized for this resource" });
        }

        //GET: Account/Index
        public IActionResult Index(string? id)
        {
            IndexViewModel ivm = new IndexViewModel();
            AppUser user;

            // Check if an ID is passed and retrieve the user by ID
            if (string.IsNullOrEmpty(id) == false)
            {
                user = _context.Users.FirstOrDefault(u => u.Id == id);

                if (user == null)
                {
                    return View("Error", new String[] { "The user was not found." });
                }

                // Security check: Ensure the logged-in user is viewing their own account or is an admin
                // if the user is admin it will fail
                if (User.IsInRole("Admin") == false && user.UserName != User.Identity.Name)
                {
                    return View("Error", new String[] { "You are not authorized to view this user's profile." });
                }
            }
            else
            {
                // Default to logged-in user's profile
                string currentUserName = User.Identity.Name;
                user = _context.Users.FirstOrDefault(u => u.UserName == currentUserName);

                if (user == null)
                {
                    return View("Error", new String[] { "Your account was not found." });
                }
            }

            // Populate the view model
            ivm.Email = user.Email;
            ivm.HasPassword = true; // Assuming this is always true for now
            ivm.UserID = user.Id;
            ivm.UserName = user.UserName;
            ivm.Address = user.LineAddress;
            ivm.FirstName = user.FirstName;
            ivm.LastName = user.LastName;
            ivm.PhoneNumber = user.PhoneNumber;
            ivm.DOB = user.DOB;

            if (user.HireStatus == null)
            {
                ViewBag.EmployeeStatus = false;
                ivm.HireStatus = null;
            }
            else
            {
                ViewBag.EmployeeStatus = true;
                ivm.HireStatus = user.HireStatus == HireStatus.Employed ? "Employee" : "Terminated Employee";
            }

            var reservations = _context.Reservations
                                .Include(r => r.Property)
                                .Where(r => r.User.Id == user.Id &&
                                            (r.ReservationStatus == ReservationStatus.Valid || r.ReservationStatus == ReservationStatus.Cancelled))
                                .ToList();

            // reservations
            ViewBag.Reservations = reservations;

            // Send data to the view
            return View(ivm);
        }

        // GET: /Account/ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }



        // POST: /Account/ChangePassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel cpvm)
        {
            //if user forgot a field, send them back to 
            //change password page to try again
            if (ModelState.IsValid == false)
            {
                return View(cpvm);
            }

            //Find the logged in user using the UserManager
            AppUser userLoggedIn = await _userManager.FindByNameAsync(User.Identity.Name);

            //Attempt to change the password using the UserManager
            var result = await _userManager.ChangePasswordAsync(userLoggedIn, cpvm.OldPassword, cpvm.NewPassword);

            //if the attempt to change the password worked
            if (result.Succeeded)
            {
                //sign in the user with the new password
                await _signInManager.SignInAsync(userLoggedIn, isPersistent: false);

                //send the user back to the home page
                return RedirectToAction("Index", "Home");
            }
            else //attempt to change the password didn't work
            {
                //Add all the errors from the result to the model state
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                //send the user back to the change password page to try again
                return View(cpvm);
            }
        }


        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult LogOff()
        {
            //sign the user out of the application
            _signInManager.SignOutAsync();

            //send the user back to the home page
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return View("Error", new String[] { "You did not provide an ID." });
            }

            // Find the user by ID
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user == null)
            {
                return View("Error", new String[] { "The user was not found." });
            }

            // Security check: Ensure the logged-in user is editing their own account unless they are an admin
            if (!User.IsInRole("Admin") && user.UserName != User.Identity.Name)
            {
                return View("Error", new String[] { "You are not authorized to access this user's information." });
            }

            // Check if the user is in the Admin role
            var isAdmin = await _userManager.IsInRoleAsync(user, "Admin");

            // Populate the model
            var model = new EditViewModel
            {
                Id = user.Id, // Include the user's ID
                FirstName = user.FirstName,
                LastName = user.LastName,
                DOB = user.DOB,
                LineAddress = user.LineAddress,
                HireStatus = isAdmin ? user.HireStatus : null,
                PhoneNumber = user.PhoneNumber,
                IsAdmin = isAdmin
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditViewModel model)
        {
            // Find the user by ID
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == model.Id);

            if (user == null)
            {
                return View("Error", new String[] { "The user was not found." });
            }

            // Security check: Ensure the logged-in user is editing their own account unless they are an admin
            if (!User.IsInRole("Admin") && user.UserName != User.Identity.Name)
            {
                return View("Error", new String[] { "You are not authorized to edit this user's information." });
            }

            var errorMessages = new List<string>();

            // Ensure the user is at least 18 years old
            if (!Is18OrOlder(model.DOB))
            {
                errorMessages.Add("The user must be at least 18 years old.");
            }

            if (errorMessages.Any())
            {
                ViewBag.ErrorMessages = errorMessages;
                return View(model);
            }

            // Update the user's details
            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.DOB = model.DOB;
            user.LineAddress = model.LineAddress;
            user.PhoneNumber = model.PhoneNumber;

            // Update HireStatus if the user is an Admin
            if (await _userManager.IsInRoleAsync(user, "Admin") && model.HireStatus.HasValue)
            {
                user.HireStatus = model.HireStatus;
            }

            try
            {
                // Update the user in the database
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return View("Success", new string[] { "Profile information has successfully been updated!"}); // Redirect after success
                }
                else
                {
                    // Add identity errors to the errorMessages list
                    foreach (var error in result.Errors)
                    {
                        errorMessages.Add(error.Description);
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessages.Add($"An error occurred: {ex.Message}");
            }

            ViewBag.ErrorMessages = errorMessages;

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Profiles(ProfileSearchViewModel? svm)
        {
            var query = _userManager.Users.AsQueryable();

            if (svm != null)
            {
                if (svm.Email != null && svm.Email != " ")
                {
                    query = query.Where(u => u.Email != null && u.Email.Contains(svm.Email));
                }

                if (svm.FirstName != null && svm.FirstName != " ")
                {
                    query = query.Where(u => u.FirstName != null && u.FirstName.Contains(svm.FirstName));
                }

                if (svm.LastName != null && svm.LastName != " ")
                {
                    query = query.Where(u => u.LastName != null && u.LastName.Contains(svm.LastName));
                }

                if (svm.PhoneNumber != null)
                {
                    query = query.Where(u => u.PhoneNumber == svm.PhoneNumber);
                }
            }

            var filteredUsers = await query.ToListAsync();

            return View(filteredUsers);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminChangePassword()
        {
            // Set the users list in the ViewBag
            ViewBag.Users = GetAllUsersSelectList();

            // Return the view
            return View();
        }



        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdminChangePassword(AdminChangePasswordViewModel model)
        {

            // Find the user by the provided UserID
            var user = await _userManager.FindByIdAsync(model.UserID);

            if (user == null)
            {
                // Handle case where the user is not found
                ModelState.AddModelError(string.Empty, "The specified user was not found.");
                ViewBag.Users = GetAllUsersSelectList();
                return View(model);
            }

            // Remove the old password hash (optional, but ensures no leftover data)
            user.PasswordHash = null;

            // Set the new password
            var passwordHasher = new PasswordHasher<AppUser>();
            user.PasswordHash = passwordHasher.HashPassword(user, model.NewPassword);

            // Update the user in the database
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                // Provide feedback and redirect
                TempData["Message"] = "Password changed successfully.";
                return RedirectToAction("Profiles", "Account"); // Redirect to a relevant page
            }
            else
            {
                // Add any errors to the model state
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                // Reload the user list in ViewBag and return the view
                ViewBag.Users = GetAllUsersSelectList();
                return View(model);
            }
        }



        private SelectList GetAllUsersSelectList()
        {
            // Retrieve the list of users from the database
            List<AppUser> userList = _context.Users.ToList();

            // Add a dummy entry to prompt user selection
            AppUser selectNone = new AppUser { Id = "0", Email = "Select a User" };
            userList.Insert(0, selectNone); // Insert at the beginning of the list

            // Convert the list to a SelectList, ordering by Email
            SelectList userSelectList = new SelectList(userList.OrderBy(u => u.Email), "Id", "Email");

            // Return the SelectList
            return userSelectList;
        }


        private bool Is18OrOlder(DateTime dob)
        {
            var today = DateTime.Today;
            var age = today.Year - dob.Year;

            if (dob > today.AddYears(-age))
            {
                age = age - 1;
            }

            bool is18 = age >= 18;

            return is18;
        }

        private bool AdminEmailFormat(string email)
        {
            // Check if the email is valid (not null or empty)
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            // Check if the email ends with "@bevobnb.com"
            if (email.ToLower().EndsWith("@bevobnb.com"))
            {
                return true;
            }

            return false;
        }

        private bool EmailAlreadyExists(string email)
        {
            string normalizedEmail = email.ToLower();

            return _context.Users.Any(u => u.Email.ToLower() == normalizedEmail);
        }

        private bool IsEmployeeTerminated(string email)
        {
            var user = _userManager.Users.FirstOrDefault(u => u.Email == email);

            // Return true if the user exists and their HireStatus is Terminated
            return user != null && user.HireStatus == HireStatus.Terminated;
        }

    }
}