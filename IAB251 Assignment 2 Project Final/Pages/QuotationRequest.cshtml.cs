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

        /// <summary>
        /// 
        /// </summary>
        [BindProperty]
        public string customerInfo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [BindProperty]
        public string source { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [BindProperty]
        public string destination { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [BindProperty]
        public int numContainers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [BindProperty]
        public string packageNature { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [BindProperty]
        public string jobNature { get; set; }


        public IActionResult OnPostLogout()
        {
            // Return to the homepage
            //set user session service to null
            return RedirectToPage("/Index");
        }



            public void OnGet()
        {
        }
    }
}
