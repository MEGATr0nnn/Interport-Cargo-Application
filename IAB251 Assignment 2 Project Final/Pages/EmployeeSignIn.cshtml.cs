using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IAB251_Assignment_2_Project_Final.Pages
{
	public class EmployeeSignInModel : PageModel
    {
        /// <summary>
        /// Email from user input
        /// Required field
        /// </summary>
        [BindProperty]
        [Required]
        [EmailAddress]
        public string email { get; set; }

        /// <summary>
        /// Password from user input
        /// Required field
        /// </summary>
        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        /// <summary>
        /// Boolean for if the signin was successfull
        /// </summary>
        [BindProperty]
        public bool SignIn { get; set; } = true;

        /// <summary>
        /// New instance of Employee database for checking values
        /// </summary>
        private readonly EmployeeDAO _employeeDAO;

        /// <summary>
        /// Instance of paswordhasher to hash the password
        /// </summary>
        private PasswordHasher _passwordHasher = new PasswordHasher();

        /// <summary>
        /// Instance of current user session
        /// </summary>
        private readonly IUserSessionControl _userSessionService;

        /// <summary>
        /// Constructor to create an instance of the Employee database
        /// Initialise user session
        /// </summary>
        /// <param name="userSessionControl"></param>
        public EmployeeSignInModel(IUserSessionControl userSessionControl)
        {
            _employeeDAO = new EmployeeDAO();
            _userSessionService = userSessionControl;

        }

        /// <summary>
        /// Logic for when user successfilly signs in 
        /// </summary>
        /// <param name="action">User button input</param>
        /// <returns>Page redirect depending on successful signin</returns>
        public IActionResult OnPost(string action)
        {
            if (action == "signin")
            {
                Console.WriteLine("input: " + action);
                try
                {
                    string hashed = _passwordHasher.hashPassword(password);
                    Console.WriteLine("hashed");

                    if (_employeeDAO.isExist(email, hashed))
                    {
                        SignIn = true;
                        Employee employee = _employeeDAO.getFromEmailPword(email, hashed);
                        Console.WriteLine($"{employee.getEmail()}");
                        Console.WriteLine("Password Value: " + employee.getPassword());

                        _userSessionService.currentEmployeeUser = employee;
                        Console.WriteLine($"{_userSessionService.currentEmployeeUser.getFirstName()} + testing user session service ");

                        return RedirectToPage("/EmployeeDashboard");
                    }
                }
                catch (Exception ex)
                {
                    SignIn = false;
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return Page(); // Return to the same page to show the error message
                }
            }

            return Page();
        }
    }
}
