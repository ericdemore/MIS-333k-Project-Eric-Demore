using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


using BevoBnB.DAL;
using BevoBnB.Models;
using BevoBnB.Utilities;
using System;
using Microsoft.EntityFrameworkCore;


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
        [ValidateAntiForgeryToken]
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
                    return RedirectToAction("Profiles", "Admin");
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
                    return RedirectToAction("Index", "Home");
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
            //if user forgot to include user name or password,
            //send them back to the login page to try again
            if (ModelState.IsValid == false)
            {
                return View(lvm);
            }

            //attempt to sign the user in using the SignInManager
            Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(lvm.Email, lvm.Password, lvm.RememberMe, lockoutOnFailure: false);

            //if the login worked, take the user to either the url
            //they requested OR the homepage if there isn't a specific url
            if (result.Succeeded)
            {
                //return ?? "/" means if returnUrl is null, substitute "/" (home)
                return Redirect(returnUrl ?? "/");
            }
            else //log in was not successful
            {
                //add an error to the model to show invalid attempt
                ModelState.AddModelError("", "Invalid login attempt.");
                //send user back to login page to try again
                return View(lvm);
            }
        }

        public IActionResult AccessDenied()
        {
            return View("Error", new string[] { "You are not authorized for this resource" });
        }

        //GET: Account/Index
        public IActionResult Index()
        {
            IndexViewModel ivm = new IndexViewModel();

            //get user info
            String id = User.Identity.Name;
            AppUser user = _context.Users.FirstOrDefault(u => u.UserName == id);

            //populate the view model
            //(i.e. map the domain model to the view model)
            ivm.Email = user.Email;
            ivm.HasPassword = true;
            ivm.UserID = user.Id;
            ivm.UserName = user.UserName;
            ivm.Address = user.LineAddress;
            ivm.FirstName = user.FirstName;
            ivm.LastName = user.LastName;
            ivm.PhoneNumber = user.PhoneNumber;
            ivm.DOB = user.DOB;
            ivm.HireStatus = user.HireStatus == HireStatus.Employed ? "Employee" : "Terminated Employee";



            //send data to the view
            return View(ivm);
        }



        //Logic for change password
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

        public IActionResult Edit()
        {
            return View();
        }


        public async Task<IActionResult> Profiles()
        {

            // Retrieve all users from the UserManager
            var allUsers = await _userManager.Users.ToListAsync();

            // Pass the list of users to the view
            return View(allUsers);
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

    }
}