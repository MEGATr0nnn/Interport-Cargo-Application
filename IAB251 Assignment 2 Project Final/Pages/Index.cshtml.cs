using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace IAB251_Assignment_2_Project_Final.Pages;

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
    public InputModel Input { get; set; }

    public Customer Customer = new Customer();

    public IActionResult OnPost(string action)
    {

        if (action == "signin")
        {
            if (Customer != null)
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
            return RedirectToPage("/SignUp");
        }

        return Page();
    }

    public void OnGet()
    {
        // Logic for handling GET requests
    }
}

