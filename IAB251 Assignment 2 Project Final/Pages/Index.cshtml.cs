using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace IAB251_Assignment_2_Project_Final.Pages;

public class IndexModel : PageModel
{

    [BindProperty]
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [BindProperty]
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }


    //initalising session
    IUserSessionControl userSessionControl;

    //pulling vars
    public CustomerDAO customerDAO;

    public IndexModel()
    {
        customerDAO = new CustomerDAO();
    }


    public IActionResult OnPost(string action)
    {
        Customer customer;

        Console.WriteLine("Action: " + action);

        if (action == "signin")
        {
            // needs to be fixed List<Customer> customers = customerDAO.get(Customer);

            foreach (Customer c in customers)
            {
                if (c.getEmail().Equals(Email))
                {
                    if (c.getPassword().Equals(Password))
                    {
                        return RedirectToPage("/QuotationRequest");
                    }
                }
            }

            // If login fails
            ModelState.AddModelError(string.Empty, "Invalid email or password.");
            return Page();
        }

        else if (action == "customer")
        {
            return RedirectToPage("/SignUp");
        }

        else if (action == "employee")
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

