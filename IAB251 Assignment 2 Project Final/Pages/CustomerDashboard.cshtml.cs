using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IAB251_Assignment_2_Project_Final.Pages
{
    /// <summary>
    /// The dashboard for the Customer once successful login/account creation
    /// Allows the customer to view current quotations made and can create new quotations
    /// </summary>
    public class CustomerDashboardModel : PageModel
    {

        [BindProperty]
        public string firstName { get; set; }

        /// <summary>
        /// Instance of the customerDAO to access customer information
        /// </summary>
        private readonly CustomerDAO _customerDAO;

        /// <summary>
        /// Instance of QuotationDAO to access quotation information
        /// </summary>
        private readonly QuotationDAO _quotationDAO;

        /// <summary>
        /// Assigning user to current session
        /// </summary>
        private readonly IUserSessionControl _userSessionService;

        /// <summary>
        /// Quotation Instance
        /// </summary>
        public Quotation quotation { get; set; }

        /// <summary>
        /// Creating a list of all quotations that have been created by this customer
        /// </summary>
        public List<Quotation> Quotations { get; set; }

        /// <summary>
        /// Constructor to intitialise customer, quotation and user session
        /// </summary>
        /// <param name="userSessionControl">Getting information regarding the current customer</param>
        public CustomerDashboardModel(IUserSessionControl userSessionControl)
        {
            _customerDAO = new CustomerDAO();
            _userSessionService = userSessionControl;
            _quotationDAO = new QuotationDAO();
        }

        /// <summary>
        /// Once user clicks quotation request button direct to Quotation Request Form
        /// </summary>
        /// <returns>Returns a redirect to next page</returns>
        public IActionResult OnPost()
        {
            return RedirectToPage("/QuotationRequest");
        }

        /// <summary>
        /// Data need to process on loading the page
        /// </summary>
        public void OnGet()
        {
            firstName = _userSessionService.currentCustomerUser.getFirstName();
            Quotations = _quotationDAO.getAllFromCustomerId(_userSessionService.currentCustomerUser.getId());
        }
    }
}
