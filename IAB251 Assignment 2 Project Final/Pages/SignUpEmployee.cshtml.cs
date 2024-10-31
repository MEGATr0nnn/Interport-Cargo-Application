using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public string firstNameEmployee { get; set; }

        [BindProperty]
        public string lastNameEmployee { get; set; }

        [BindProperty]
        public string emailEmployee { get; set; }

        [BindProperty]
        public string phoneNumberEmployee { get; set; }

        [BindProperty]
        public string employeeType { get; set; }

        [BindProperty]
        public string addressEmployee { get; set; }

        [BindProperty]
        public string passwordEmployee { get; set; }

        /// <summary>
        /// New instance of the EmployeeDAO
        /// </summary>
        private EmployeeDAO _employeeDAO;

        /// <summary>
        /// Constructor for Model, cretes new instance
        /// </summary>
        public SignUpEmployeeModel()
        {
            _employeeDAO = new EmployeeDAO();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns a redirect to the quotation page upon successful registration</returns>
        public IActionResult OnPost()
        {
            Employee employee = new Employee(firstNameEmployee, lastNameEmployee, emailEmployee, phoneNumberEmployee, passwordEmployee);

            _employeeDAO.insertNew(employee);

            return RedirectToPage("/QuotationManagement");
        }



        /// <summary>
        /// 
        /// </summary>
        public void OnGet()
        {
        }
    }
}
