using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IAB251_Assignment_2_Project_Final.Pages
{
    public class QuotationManagementModel : PageModel
    {
        public void OnGet()
        {
        }

        private readonly IUserSessionControl _sessionControl;

        private readonly EmployeeDAO _employeeDAO;


        public QuotationManagementModel()
        {

        }
    }
}
