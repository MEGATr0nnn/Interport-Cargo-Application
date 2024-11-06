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
        /// Creating a list of all necessary status quotations to showcase to the employee dashboard
        /// Pending, Accepted and Rejected are all apart of the graph.
        /// </summary>
        public List<Quotation> allQuotations { get; set; }

        public List<Quotation> allPendingQuotations { get; set; }

        public List<Quotation> allAcceptedQuotations { get; set; }

        public List<Quotation> allRejectedQuotations { get; set; }

        public List<Quotation> allSentToCustomer { get; set; }



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
            allPendingQuotations = _quotationDAO.getStatusQuotation("Pending");
            allAcceptedQuotations = _quotationDAO.getStatusQuotation("Accepted");
            allRejectedQuotations = _quotationDAO.getStatusQuotation("Rejected");
            allSentToCustomer = _quotationDAO.getStatusQuotation("sentForApproval");
        }

        /// <summary>
        /// Logic for employee button press
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost(string action, int quoteIDAccept, int quoteIDReject, int discountID)
        {
            if (action == "addDiscount")
            {
                Console.WriteLine("discount added");
                Discount = true;
                _quotation = _quotationDAO.getSpecificQuotation(discountID);
                _quotation.calculateCharges(_quotation.getsizeOfContainers(), _quotation.calculateDiscount());
                _quotationDAO.update(_quotation, _quotation.getCustomerId());
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

            if (action == "Logout")
            {
                _userSessionControl.currentCustomerUser = null;
                _userSessionControl.currentEmployeeUser = null;
                return RedirectToPage("/Index");
            }

            return RedirectToPage("/EmployeeDashboard");
        }
    }

}
