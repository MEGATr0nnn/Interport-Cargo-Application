using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace IAB251_Assignment_2_Project_Final.Pages
{
    /// <summary>
    /// Class is used for the management and creation of the employee user
    /// Takes all necessary attributes and stored within the Employee DB Table
    /// Will direct to the Employee Dashboard upon successfull account creation
    /// </summary>
    public class SignUpEmployeeModel : PageModel
    {
        /// <summary>
        /// Relevent input fields for employee
        /// </summary>
        [BindProperty]
        [Required(ErrorMessage = "A First Name is Required.")]
        public string firstName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "A Last Name is Required.")]
        public string lastName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "A Valid Email is Required.")]
        [EmailAddress]
        public string email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "A Phone Number is Required.")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone Number is not a Valid Number.")]
        public string phoneNumber { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "An Employee Type Must be Defined.")]
        public string employeeType { get; set; }


        [BindProperty]
        [Required(ErrorMessage = "An Employee Address Must be Listed.")]
        public string address { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "A Password is Required.")]
        [DataType(DataType.Password)]
        public string password { get; set; }




        /// <summary>
        /// Allows access to current user funcs
        /// </summary>
        private readonly IUserSessionControl _userSessionService;

        /// <summary>
        /// Allowing access to _employeeDAO methods
        /// </summary>
        private readonly EmployeeDAO _employeeDAO;

        /// <summary>
        /// Allows for password to be hashed via SHA256
        /// </summary>
        private PasswordHasher _passwordHasher = new PasswordHasher();

        /// <summary>
        /// Constructor for Model, cretes new instance
        /// </summary>
        public SignUpEmployeeModel(IUserSessionControl userSessionControl)
        {
            _employeeDAO = new EmployeeDAO();
            _userSessionService = userSessionControl;
        }

        /// <summary>
        /// Logic for when an employee successfully registers. 
        /// Directs to the Employee Dashboard if successfull
        /// Returns back to same page if unsuccessful account creation
        /// </summary>
        /// <returns>Returns a redirect to the quotation page upon successful registration</returns>
        public IActionResult OnPost(string action)
        {
            if (action == "signup")
            {
                Console.WriteLine("Action Inputted: " + action);
                try
                {
                    string hashed = _passwordHasher.hashPassword(password);

                    string dateJoined = DateTime.Now.ToString("yyyy-MM-dd");

                    Employee employee = new Employee(firstName, lastName, email, phoneNumber, hashed, employeeType, address, dateJoined);
                    _employeeDAO.insertNew(employee);

                    _userSessionService.currentEmployeeUser = employee;

                    return RedirectToPage("/EmployeeDashboard");
                }

                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                    return Page(); 
                }
            }
            return Page();
        }
    }
}
