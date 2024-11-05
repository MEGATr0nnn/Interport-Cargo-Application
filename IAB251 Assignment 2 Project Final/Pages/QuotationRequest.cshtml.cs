using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IAB251_Assignment_2_Project_Final.Pages
{
    public class QuotationRequest : PageModel
    {
        /// <summary>
        /// 
        /// </summary>
        [BindProperty]
        public int requestID { get; set; }

        [BindProperty]
        public string customerInfo { get; set; }

        [BindProperty]
        public string source { get; set; }

        [BindProperty]
        public string destination { get; set; }

        [BindProperty]
        public int numContainers { get; set; }

        [BindProperty]
        public string packageNature { get; set; }

        [BindProperty]
        public bool isImport { get; set; }

        [BindProperty]
        public bool isPacking { get; set; }

        [BindProperty]
        public string quarantineReq { get; set; }


        private readonly QuotationDAO _quotation;

        private readonly IUserSessionControl _userSessionService;


        public QuotationRequest(IUserSessionControl userSessionControl)
        {
            _quotation = new QuotationDAO();
            _userSessionService = userSessionControl;
        }


        /// <summary>
        /// Logic for adding a new quotation to the database
        /// </summary>
        /// <returns>Redirects to Dashboard Upon Successful Quotation Creation</returns>
        public IActionResult OnPost(string Action)
        {
            Quotation quotation = new Quotation(customerInfo, source, destination, numContainers, packageNature, isImport, isPacking, quarantineReq);

            _quotation.insertNew(quotation, _userSessionService.currentCustomerUser);

            if(Action == "Logout")
            {
                _userSessionService.currentCustomerUser = null;
                _userSessionService.currentEmployeeUser = null;

                return RedirectToPage("/Index");
            }

            return RedirectToPage("/CustomerDashboard");
        }



            public void OnGet()
        {
        }
    }
}
