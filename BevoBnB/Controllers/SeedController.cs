using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



using BevoBnB.Models;
using BevoBnB.DAL;
using System;


namespace BevoBnB.Controllers
{
    public class SeedController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public SeedController(AppDbContext db, UserManager<AppUser> um, RoleManager<IdentityRole> rm)
        {
            _context = db;
            _userManager = um;
            _roleManager = rm;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> SeedRoles()
        {
            try
            {
                //call the method to seed the roles
                await Seeding.SeedRoles.AddAllRoles(_roleManager);
            }
            catch (Exception ex)
            {
                //add the error messages to a list of strings
                List<String> errorList = new List<String>();

                //Add the outer message
                errorList.Add(ex.Message);

                //Add the message from the inner exception
                errorList.Add(ex.InnerException.Message);

                //Add additional inner exception messages, if there are any
                if (ex.InnerException.InnerException != null)
                {
                    errorList.Add(ex.InnerException.InnerException.Message);
                }

                return View("Error", errorList);
            }

            //this is the happy path - seeding worked!
            return View("Confirm");
        }
        public async Task<IActionResult> SeedPeople()
        {
            try
            {
                //call the method to seed the users
                await Seeding.SeedUsers.SeedAllUsers(_userManager, _context);
            }
            catch (Exception ex)
            {
                //add the error messages to a list of strings
                List<String> errorList = new List<String>();

                //Add the outer message
                errorList.Add(ex.Message);

                if (ex.InnerException != null)
                {
                    //Add the message from the inner exception
                    errorList.Add(ex.InnerException.Message);

                    //Add additional inner exception messages, if there are any
                    if (ex.InnerException.InnerException != null)
                    {
                        errorList.Add(ex.InnerException.InnerException.Message);
                    }

                }


                return View("Error", errorList);
            }

            //this is the happy path - seeding worked!
            return View("Confirm");
        }
        public async Task<IActionResult> SeedReviews()
        {
            try
            {
                // Call the method to seed the reviews
                await Seeding.SeedReviews.SeedAllReviews(_context);
            }
            catch (Exception ex)
            {
                // Collect error messages
                List<string> errorList = new List<string> { ex.Message };

                if (ex.InnerException != null)
                {
                    errorList.Add(ex.InnerException.Message);

                    if (ex.InnerException.InnerException != null)
                    {
                        errorList.Add(ex.InnerException.InnerException.Message);
                    }
                }

                return View("Error", errorList);
            }

            // Successful seeding
            return View("Confirm");
        }

        public async Task<IActionResult> SeedProperties()
        {
            try
            {
                // Call the method to seed the properties
                Seeding.SeedProperties.SeedAllProperties(_context);
            }
            catch (Exception ex)
            {
                // Add the error messages to a list of strings
                List<String> errorList = new List<String>();

                // Add the outer message
                errorList.Add(ex.Message);

                if (ex.InnerException != null)
                {
                    // Add the message from the inner exception
                    errorList.Add(ex.InnerException.Message);

                    // Add additional inner exception messages, if there are any
                    if (ex.InnerException.InnerException != null)
                    {
                        errorList.Add(ex.InnerException.InnerException.Message);
                    }
                }

                // Return the Error view with the list of error messages
                return View("Error", errorList);
            }

            // This is the happy path - seeding worked!
            return View("Confirm");
        }

        public async Task<IActionResult> SeedReservations()
        {
            try
            {
                // Call the method to seed the reservations
                Seeding.SeedReservations.SeedAllReservations(_context);
            }
            catch (Exception ex)
            {
                // Add the error messages to a list of strings
                List<String> errorList = new List<String>();

                // Add the outer message
                errorList.Add(ex.Message);

                if (ex.InnerException != null)
                {
                    // Add the message from the inner exception
                    errorList.Add(ex.InnerException.Message);

                    // Add additional inner exception messages, if there are any
                    if (ex.InnerException.InnerException != null)
                    {
                        errorList.Add(ex.InnerException.InnerException.Message);
                    }
                }

                // Return the Error view with the list of error messages
                return View("Error", errorList);
            }

            // This is the happy path - seeding worked!
            return View("Confirm");
        }

    }
}
