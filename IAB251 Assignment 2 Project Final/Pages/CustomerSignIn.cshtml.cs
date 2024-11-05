using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Collections.Specialized.BitVector32;

namespace IAB251_Assignment_2_Project_Final.Pages
{
    /// <summary>
    /// Class used for signin for a customer via accessing CustomerDAO for saved logged in details
    /// </summary>
    public class CustomerSignInModel : PageModel
    {
        /// <summary>
        /// Necessary fields for signin
        /// </summary>
        [BindProperty]
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        /// <summary>
        /// Boolean to check if user has successfully signed in
        /// </summary>
        [BindProperty]
        public bool SignIn { get; set; } = true;

        /// <summary>
        /// Instance of CustomerDAO to access Customer Information
        /// </summary>
        private readonly CustomerDAO _customerDAO;

        /// <summary>
        /// Instance of PasswordHasher to encrypt Password via SHA256
        /// </summary>
        private PasswordHasher _passwordHasher = new PasswordHasher();

        /// <summary>
        /// Instance to assign current user to session
        /// </summary>
        private readonly IUserSessionControl _userSessionService;

        /// <summary>
        /// Constructor used to initialise the DAO Object and User Session 
        /// </summary>
        /// <param name="userSessionControl">Assigning the current user</param>
        public CustomerSignInModel(IUserSessionControl userSessionControl)
        {
            _customerDAO = new CustomerDAO();
            _userSessionService = userSessionControl;

        }

        /// <summary>
        /// Logic for user button input for customer signin
        /// If valid signin, will direct to Customer Dashboard
        /// </summary>
        /// <param name="action">The button click from the user</param>
        /// <returns>Page direct according to valid signin</returns>
        public IActionResult OnPost(string action)
        {
            if (action == "signin")
            {
                Console.WriteLine("input: " + action);
                try
                {
                    SignIn = true;
                    string hashed = _passwordHasher.hashPassword(password);
                    Console.WriteLine("hashed");

                    if (_customerDAO.isExist(email, hashed))
                    {
                        Customer customer = _customerDAO.getFromEmailPword(email, hashed);
                        Console.WriteLine($"{customer.getFirstName()}");

                        _userSessionService.currentCustomerUser = customer;
                        Console.WriteLine($"{_userSessionService.currentCustomerUser.getFirstName()} + testing user session service "); //checking to see if session aligned properly

                        return RedirectToPage("/CustomerDashboard");
                    }
                }
                catch (Exception ex)
                {
                    SignIn = false;
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return Page();
                }
            }
            return Page();
        } 
    }
}
