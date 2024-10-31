using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace IAB251_Assignment_2_Project_Final.Pages;

public class IndexModel : PageModel
{
    /// <summary>
    /// Gets the Email Address from the user input from the frontend of the Homepage
    /// </summary>
    [BindProperty]
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    /// <summary>
    /// Gets the Password from the user input from the frontend of the Homepage
    /// </summary>
    [BindProperty]
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    /// <summary>
    /// Session initialiser
    /// </summary>
    IUserSessionControl userSessionControl;

    /// <summary>
    /// Pulling stored data for customer object
    /// </summary>
    public CustomerDAO customerDAO;

    /// <summary>
    /// Constructor initialising a new Customer Data Access Object
    /// </summary>
    public IndexModel()
    {
        customerDAO = new CustomerDAO();
    }

    /// <summary>
    /// Actions for successful login (or not) and associating customer when successful login
    /// Customer email and password is accessed via the CustomerDAO
    /// If no existing customer, login will fail
    /// </summary>
    /// <param name="action">User Button selection</param>
    /// <returns>A redirect to a new page according to successful login or not</returns>
    public IActionResult OnPost(string action)
    {
        Console.WriteLine("Action: " + action); 
        Console.WriteLine(Email + " " + Password);

        //Procedure for when user signs in
        if (action == "signin")
        {
            if (customerDAO.isExist(Email, Password))
            {
                Customer customer = customerDAO.getFromEmailPword(Email, Password);

                //userSessionControl.currentCustomerUser = customer;

                Console.WriteLine(customer.getEmail() + " " + customer.getPassword()); 

                return RedirectToPage("/QuotationRequest");

            }


            // Failed login
            ModelState.AddModelError(string.Empty, "Invalid email or password, please try again.");
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

