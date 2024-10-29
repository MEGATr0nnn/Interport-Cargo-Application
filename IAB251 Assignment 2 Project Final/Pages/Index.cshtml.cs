using System.ComponentModel.DataAnnotations;
using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Linq; // Ensure you have this using directive for LINQ

namespace IAB251_Assignment_2_Project_Final.Pages
{
    public class IndexModel : PageModel
    {
        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; } // This should be of type InputModel

        public Customer Customer = new Customer();

        private readonly CustomerModel customerModel; // Ensure this is initialized properly
        private readonly ILogger<IndexModel> _logger;

        // Constructor with dependency injection
        public IndexModel(ILogger<IndexModel> logger, CustomerModel customerModel)
        {
            _logger = logger;
            this.customerModel = customerModel; // Initialize customerModel in the constructor
            Input = new InputModel(); // Initialize Input property here
        }

        public IActionResult OnPost(string action)
        {

            if (action == "signin")
            {
                // Use LINQ to find the matching customer
                var customer = customerModel.customers.FirstOrDefault(c => c.email == Input.Email && c.password == Input.Password);

                if (customer != null)
                {
                    // Successful sign-in
                    return RedirectToPage("/Dashboard");
                }

                // If login fails
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return Page();
            }

            else if (action == "signup")
            {
                return RedirectToPage("/SignUpPage");
            }

            return Page();
        }

        public void OnGet()
        {
            // Logic for handling GET requests
        }
    }
}
