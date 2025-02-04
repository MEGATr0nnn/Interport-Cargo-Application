using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IAB251_Assignment_2_Project_Final.Pages
{
    public class QuotationRequest : PageModel
    {
        /// <summary>
        /// All necessary user input fields 
        /// </summary>
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
        public bool quarantineReq { get; set; }

        [BindProperty]
        public int sizeContainer { get; set; }

        [BindProperty]
        public bool isFumigation { get; set; }

        [BindProperty]
        public bool isCrane { get; set; }

        

        private readonly QuotationDAO _quotation;

        private readonly IUserSessionControl _userSessionService;


        public QuotationRequest(IUserSessionControl userSessionControl)
        {
            _quotation = new QuotationDAO();
            _userSessionService = userSessionControl;
        }

        /// <summary>
        /// Return to the homepage after logout button is pressed
        /// set user session service to null
        /// </summary>
        /// <returns></returns>
       

        /// <summary>
        /// Logic for adding a new quotation to the database
        /// </summary>
        /// <returns>Redirects to Dashboard Upon Successful Quotation Creation</returns>
        public IActionResult OnPost(string Logout, string Back)
        {

            if (Logout == "Logout")
            {
                _userSessionService.currentEmployeeUser = null;
                _userSessionService.currentCustomerUser = null;
                return RedirectToPage("/Index");
            }

            if(Back == "Back")
            {
                return RedirectToPage("/CustomerDashboard");
            }



            Quotation quotation = new Quotation(customerInfo, source, destination, numContainers, sizeContainer, packageNature, isImport, isPacking, quarantineReq, isFumigation, isCrane, "Pending");

            _quotation.insertNew(quotation, _userSessionService.currentCustomerUser);


            return RedirectToPage("/CustomerDashboard");

            
        }

     

        public void OnGet()
        {
        }
    }
}