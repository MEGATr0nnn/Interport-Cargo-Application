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

        private readonly CustomerDAO _customerDAO;

        private readonly QuotationDAO _quotationDAO;

        private readonly IUserSessionControl _userSessionService;

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
        public IActionResult OnPost(string Logout,string Back)
        {
            if (Logout == "Logout")
            {
                _userSessionService.currentEmployeeUser = null;
                _userSessionService.currentCustomerUser = null;
                return RedirectToPage("/Index");
            }

           

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
