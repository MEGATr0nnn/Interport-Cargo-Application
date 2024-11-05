using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IAB251_Assignment_2_Project_Final.Pages
{
    /// <summary>
    /// Class used to manage the Employee Dashboard and necessary inputs
    /// </summary>
    public class EmployeeDashboardModel : PageModel
    {

        private readonly QuotationDAO _quotationDAO;

        private readonly IUserSessionControl _userSessionService;
        
        private EmployeeDAO _employeeDAO;

        private Quotation Quotation {  get; set; }

        [BindProperty]
        public string employeeName { get; set; }

        public Employee employee { get; set; }

        public List<Quotation> allQuotations { get; set; }



        public EmployeeDashboardModel(IUserSessionControl userSessionControl)
        {
            _employeeDAO = new EmployeeDAO();
            _userSessionService = userSessionControl;
            _quotationDAO = new QuotationDAO();

        }

        public IActionResult OnPost(string action)
        {
            if (action == "rates")
            {
                return RedirectToPage("/RatesSchedule");
            }

            return Page();
            //return RedirectToPage("/QuotationManagement");
        }


        /// <summary>
        /// Getting current user and all quotations stored in QuotationDAO
        /// </summary>
        public void OnGet()
        {
            employee = _userSessionService.currentEmployeeUser;
            allQuotations = _quotationDAO.getAllQuotations();
        }
    }
}
