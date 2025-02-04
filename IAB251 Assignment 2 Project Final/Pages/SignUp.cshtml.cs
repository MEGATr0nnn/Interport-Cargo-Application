using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IAB251_Assignment_2_Project_Final.Pages
{
    public class SignUp : PageModel
    {
        /// <summary>
        /// Signup Fields
        /// </summary>
        [BindProperty]
        [Required(ErrorMessage = "A First Name is Required")]
        public string firstName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "A Last Name is Required")]
        public string lastName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "A Valid Email is Required.")]
        [EmailAddress]
        public string email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "A Phone Number is Required.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone Number is Not a Valid Number.")]
        public string phoneNumber { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "A Password is Required.")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [BindProperty]
        public string company { get; set; }

        /// <summary>
        /// Allows access to the current sessions user
        /// </summary>
        private readonly IUserSessionControl _userSessionService;

        /// <summary>
        /// allows access to the _customerDAO
        /// </summary>
        private CustomerDAO _customerDAO;

        /// <summary>
        /// Allows for password to be hashed via SHA256
        /// </summary>
        private PasswordHasher _passwordHasher = new PasswordHasher();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userSessionControl"></param>
        public SignUp(IUserSessionControl userSessionControl)
        {
            _customerDAO = new CustomerDAO();
            _userSessionService = userSessionControl;
        }


        /// <summary>
        /// 
        /// </summary>
        public void OnGet() { }

        /// <summary>
        /// Logic for when signup has been done correctly
        /// </summary>
        /// <returns>A redirect to the customer dashboard upon successful signup</returns>
        public IActionResult OnPost(string Back)
        {


            if (Back == "Back")
            {
                return RedirectToPage("/Index");
            }

            try
            {
                string hashed = _passwordHasher.hashPassword(password);

                Customer currentUser = new Customer(firstName, lastName, email, phoneNumber, hashed, company);
                _customerDAO.insertNew(currentUser);

                _userSessionService.currentCustomerUser = currentUser;
                Console.WriteLine($"{_userSessionService.currentCustomerUser.getFirstName()}"); //checking to see if session aligned properly
                ModelState.Clear();
                return RedirectToPage("/CustomerDashboard");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page(); // Return to the same page to show the error message
            }
        }
    }
}