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
        [BindProperty]
        public bool Discount { get; set; }

        [BindProperty]
        public double total { get; set; }

        /// <summary>
        /// Instance of Quotation Database
        /// </summary>
        private readonly QuotationDAO _quotationDAO;
        private readonly IUserSessionControl _userSessionControl;

        /// <summary>
        /// Creating a new Quotation model
        /// </summary>
        private Quotation _quotation { get; set; }

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

        /// <summary>
        /// Logic for employee button press
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost(string action, int quoteIDAccept, int quoteIDReject)
        {
            if (action == "Discount")
            {
                _quotation = _quotationDAO.getSpecificQuotation(quoteIDAccept);
                total = _quotation.calculateCharges(_quotation.getsizeOfContainers(), _quotation.calculateDiscount());

            }

            if (action == "accept")
            {
                _quotation = _quotationDAO.getSpecificQuotation(quoteIDAccept);
                _quotation.setStatus("sentForApproval");
                _quotationDAO.update(_quotation, _quotation.getCustomerId());
            }

            if (action == "reject")
            {
                _quotation = _quotationDAO.getSpecificQuotation(quoteIDReject);
                _quotation.setStatus("Rejected");
                _quotationDAO.update(_quotation, _quotation.getCustomerId());
            }
            return RedirectToPage("/EmployeeDashboard");
        }
    }
}
