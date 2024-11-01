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

        public CustomerDashboardModel(IUserSessionControl userSessionControl)
        {
            _customerDAO = new CustomerDAO();
            _userSessionService = userSessionControl;

        }


        public IActionResult OnPost()
        {
            return RedirectToPage("/QuotationRequest");
        }



        public void OnGet()
        {
            customer = _userSessionService.currentCustomerUser;
            customerName = customer.getFirstName() + " " + customer.getLastName();  
        }
    }
}
