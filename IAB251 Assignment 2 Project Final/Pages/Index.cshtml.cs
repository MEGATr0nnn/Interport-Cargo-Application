using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace IAB251_Assignment_2_Project_Final.Pages;

public class IndexModel : PageModel
{
    /// <summary>
    /// Gets the email and password from the users input
    /// </summary>
    [BindProperty]
    [Required]
    [EmailAddress]
    public string email { get; set; }

    [BindProperty]
    [Required]
    [DataType(DataType.Password)]
    public string password { get; set; }

    /// <summary>
    /// Session initialiser
    /// </summary>
    private readonly IUserSessionControl _userSessionService;

    /// <summary>
    /// Pulling stored data for customer object
    /// </summary>
    private CustomerDAO _customerDAO;

    /// <summary>
    /// Constructor initialising a new Customer Data Access Object
    /// </summary>
    public IndexModel(IUserSessionControl userSessionControl, CustomerDAO customerDAO)
    {
        _customerDAO = customerDAO;
        _userSessionService = userSessionControl;
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
        Console.WriteLine(email + " " + password);

        //Procedure for when user signs in
        if (action == "signin")
        {
            if (!ModelState.IsValid)
            {
                // Failed login
                ModelState.AddModelError(string.Empty, "Invalid email or password, please try again.");
                return Page();
            }

            if (_customerDAO.isExist(email, password))
            {
                Customer customer = _customerDAO.getFromEmailPword(email, password);
                Console.WriteLine($"{customer.getFirstName()}");

                _userSessionService.currentCustomerUser = customer;
                Console.WriteLine($"{_userSessionService.currentCustomerUser.getFirstName()}"); //checking to see if session aligned properly

                Console.WriteLine(customer.getEmail() + " " + customer.getPassword()); 

                return RedirectToPage("/QuotationRequest");
            }
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

