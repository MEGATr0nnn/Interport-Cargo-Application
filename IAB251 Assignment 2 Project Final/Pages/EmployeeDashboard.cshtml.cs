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
        [BindProperty]
        public string firstName { get; set; }



        /// <summary>
        /// Instance of Quotation Database
        /// </summary>
        private readonly QuotationDAO _quotationDAO;
        private readonly IUserSessionControl _userSessionControl;

        /// <summary>
        /// Creating a new Quotation model
        /// </summary>
        private Quotation Quotation { get; set; }

        /// <summary>
        /// Creating a list of all quotations to showcase to the employee dashboard
        /// </summary>
        public List<Quotation> allQuotations { get; set; }

        /// <summary>
        /// Constructor to intialise the employee database and the quotationDAO
        /// </summary>
        public EmployeeDashboardModel(IUserSessionControl userSessionControl)
        {
            _userSessionControl = userSessionControl;
            _quotationDAO = new QuotationDAO();
        }

        /// <summary>
        /// Getting current user and all quotations stored in QuotationDAO
        /// </summary>
        public void OnGet()
        {
            firstName = _userSessionControl.currentEmployeeUser.getFirstName();
            allQuotations = _quotationDAO.getAllQuotations();
        }


    }
}
