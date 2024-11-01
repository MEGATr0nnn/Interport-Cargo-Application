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
        [Required(ErrorMessage = "A First name is required")]
        public string firstName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "A Last name is required")]
        public string lastName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "A valid email is required.")]
        [EmailAddress]
        public string email { get; set; }

        [BindProperty]
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number is not a valid number.")]
        public string phoneNumber { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "A password is required.")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        /// <summary>
        /// Allows access to the current sessions user
        /// </summary>
        private readonly IUserSessionControl _userSessionService;

        /// <summary>
        /// allows access to the _customerDAO
        /// </summary>
        private CustomerDAO _customerDAO;

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
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            try 
            { 

                Customer currentUser = new Customer(firstName, lastName, email, phoneNumber, password);
                _customerDAO.insertNew(currentUser);

                _userSessionService.currentCustomerUser = currentUser;
                Console.WriteLine($"{_userSessionService.currentCustomerUser.getFirstName()}"); //checking to see if session aligned properly
                ModelState.Clear();
                return RedirectToPage("/QuotationRequest");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return Page(); // Return to the same page to show the error message
            }
        }
    }
}