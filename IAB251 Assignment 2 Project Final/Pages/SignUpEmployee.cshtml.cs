using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace IAB251_Assignment_2_Project_Final.Pages
{
    /// <summary>
    /// 
    /// </summary>
    public class SignUpEmployeeModel : PageModel
    {
        /// <summary>
        /// Relevent fields for employee
        /// </summary>
        [BindProperty]
        [Required(ErrorMessage = "A First name is required.")]
        public string firstName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "A Last name is required.")]
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
        [Required(ErrorMessage = "An Employee type must be defined.")]
        public string employeeType { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "An Employee address must be listed.")]
        public string address { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        /// <summary>
        /// Allows access to current user funcs
        /// </summary>
        private readonly IUserSessionControl _userSessionService;

        /// <summary>
        /// Allowing access to _employeeDAO methods
        /// </summary>
        private EmployeeDAO _employeeDAO; //make readonly???

        /// <summary>
        /// Constructor for Model, cretes new instance
        /// </summary>
        public SignUpEmployeeModel(IUserSessionControl userSessionControl, EmployeeDAO employee)
        {
            _employeeDAO = employee;
            _userSessionService = userSessionControl;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns a redirect to the quotation page upon successful registration</returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                Employee employee = new Employee(firstName, lastName, email, phoneNumber, password);
                _employeeDAO.insertNew(employee);

                _userSessionService.currentEmployeeUser = employee;

                return RedirectToPage("/QuotationManagement");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnGet() { }
    }
}
