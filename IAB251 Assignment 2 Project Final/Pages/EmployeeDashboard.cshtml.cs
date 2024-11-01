using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IAB251_Assignment_2_Project_Final.Pages
{
    public class EmployeeDashboardModel : PageModel
    {
        private EmployeeDAO _employeeDAO;

        private readonly IUserSessionControl _userSessionService;

        [BindProperty]
        public string employeeName { get; set; }

        public Employee employee { get; set; }

        public EmployeeDashboardModel(IUserSessionControl userSessionControl)
        {
            _employeeDAO = new EmployeeDAO();
            _userSessionService = userSessionControl;

        }

        public IActionResult OnPost()
        {
            return RedirectToPage("/QuotationManagement");
        }



        public void OnGet()
        {
            employee = _userSessionService.currentEmployeeUser;
            employeeName = employee.getFirstName() + " " + employee.getLastName();
        }
    }
}
