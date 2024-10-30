using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IAB251_Assignment_2_Project_Final.Pages
{
    public class QuotationRequest : PageModel
    {
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
        public string jobNature { get; set; }



        public void OnGet()
        {
        }
    }
}
