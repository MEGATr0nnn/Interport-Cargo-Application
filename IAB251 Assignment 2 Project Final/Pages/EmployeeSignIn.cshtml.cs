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
        [BindProperty]
        [Required]
        [EmailAddress]
        public string email { get; set; }

        [BindProperty]
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }

        private readonly EmployeeDAO _employeeDAO;

        private PasswordHasher _passwordHasher = new PasswordHasher();

        private readonly IUserSessionControl _userSessionService;

        public EmployeeSignInModel(IUserSessionControl userSessionControl)
        {
            _employeeDAO = new EmployeeDAO();
            _userSessionService = userSessionControl;

        }
        public void OnGet()
        {
        }

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

                    ModelState.AddModelError(string.Empty, ex.Message);
                    return Page(); // Return to the same page to show the error message
                }
            }

            return Page();
        }
    }
}
