﻿
using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;

namespace IAB251_Assignment_2_Project_Final.Pages;

public class IndexModel : PageModel
{
    public string accountExists { get; set; }
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

    [BindProperty]
    public List<string> UserType { get; set; }

    /// <summary>
    /// Session initialiser
    /// </summary>
    private readonly IUserSessionControl _userSessionService;

    /// <summary>
    /// Allows for password to be hashed via SHA256
    /// </summary>
    private PasswordHasher _passwordHasher = new PasswordHasher();

    /// <summary>
    /// Pulling stored data for Customer object
    /// </summary>
    private CustomerDAO _customerDAO;

    public string errorMessage;

    /// <summary>
    /// Pulling stored data for Employee object
    /// </summary>
    private EmployeeDAO _employeeDAO;

    /// <summary>
    /// Constructor initialising a new Customer Data Access Object
    /// </summary>
    public IndexModel(IUserSessionControl userSessionControl)
    {
        _customerDAO = new CustomerDAO();
        _employeeDAO = new EmployeeDAO();
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
            try
            {
                string hashed = _passwordHasher.hashPassword(password);

                if (_customerDAO.isExist(email, hashed))
                {
                    Customer customer = _customerDAO.getFromEmailPword(email, hashed);
                    Console.WriteLine($"{customer.getFirstName()}");

                    _userSessionService.currentCustomerUser = customer;
                    Console.WriteLine($"{_userSessionService.currentCustomerUser.getFirstName()}"); //checking to see if session aligned properly

                    return RedirectToPage("/CustomerDashboard");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(string.Empty, ex.Message);
                return Page(); // Return to the same page to show the error message
            }
        }
        //}

        //Logic for when the employee user type is selected,
        //will use the Employee DB for user credential verification
        /*
        //else if (UserType.Equals("Employee"))
        //{
            if (action == "signin")
            {
                if (!ModelState.IsValid)
                {
                    // Failed login
                    ModelState.AddModelError(string.Empty, "Invalid email or password, please try again.");
                    return Page();
                }

                if (_employeeDAO.isExist(email, password))
                {
                    Employee employee = _employeeDAO.getFromEmailPword(email, password);
                    Console.WriteLine($"{employee.getFirstName()}");

                    _userSessionService.currentEmployeeUser = employee;
                    Console.WriteLine($"{_userSessionService.currentCustomerUser.getFirstName()}"); //checking to see if session aligned properly

                    Console.WriteLine(employee.getEmail() + " " + employee.getPassword());

                    return RedirectToPage("/EmployeeDashboard");
                }
            }
        //}
        */

        //Logic for new customer signup
        else if (action == "customer")
        {
            return RedirectToPage("/CustomerSignIn");
        }

        //Logic for new employee signup
        else if (action == "employee")
        {
            return RedirectToPage("/EmployeeSignIn");
        }

        return Page();
    }


    public void OnGet()
    {
        UserType = new List<string>
        {
        "Select User",
        "Customer",
        "Employee"
        };
    }
}