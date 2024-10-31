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
        /// Employees first name from input
        /// </summary>
        [BindProperty]
        public string firstNameEmployee { get; set; }

        /// <summary>
        /// Employees last name from input
        /// </summary>
        [BindProperty]
        public string lastNameEmployee { get; set; }

        /// <summary>
        /// Employees email address from input
        /// </summary>
        [BindProperty]
        public string emailEmployee { get; set; }

        /// <summary>
        /// Employees phone number from input
        /// </summary>
        [BindProperty]
        public string phoneNumberEmployee { get; set; }

        /// <summary>
        /// Employees type of role from input
        /// </summary>
        [BindProperty]
        public string employeeType { get; set; }

        /// <summary>
        /// Employees address from input
        /// </summary>
        [BindProperty]
        public string addressEmployee { get; set; }

        /// <summary>
        /// Employees password from input
        /// </summary>
        [BindProperty]
        public string passwordEmployee { get; set; }

        /// <summary>
        /// New instance of the EmployeeDAO
        /// </summary>
        private EmployeeDAO _employeeDAO;





        /// <summary>
        /// 
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
