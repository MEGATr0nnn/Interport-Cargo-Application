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
        private CustomerDAO _customerDAO;

        private readonly IUserSessionControl _userSessionService;

        [BindProperty]
        public string customerName { get; set; }

        public Customer customer { get; set; }

        private readonly QuotationDAO _quotationDAO;

        public Quotation quotation { get; set; }

        public CustomerDashboardModel(IUserSessionControl userSessionControl)
        {
            _customerDAO = new CustomerDAO();
            _userSessionService = userSessionControl;
            _quotationDAO = new QuotationDAO();
        }

        public List<Quotation> Quotations { get; set; }



        public IActionResult OnPost()
        {
            return RedirectToPage("/QuotationRequest");
        }



        public void OnGet()
        {
            customer = _userSessionService.currentCustomerUser;

            Quotations = _quotationDAO.getAllFromCustomerId(_userSessionService.currentCustomerUser.getId());

            /*
            foreach (var item in x)
            {
                item.getCustomerId();
                item.getCustomerInformation();
                item.getSource();
                item.getDestination();
                item.getNumOfContainers();
                item.getNatureOfPackage();
                item.getImport();
                item.getPacking();
                item.getQuarantineRequirements();
            }
            */


            customerName = customer.getFirstName() + " " + customer.getLastName();

        }
    }
}
