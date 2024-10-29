using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IAB251_Assignment_2_Project_Final.Pages
{
    public class SignUp : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; } = new Customer("", "", "", 0, "");

        public CustomerDAO customerDAO;

        public string accountExists;

        public SignUp(CustomerDAO customerDAO)
        {
            this.customerDAO = customerDAO;
        }


        public void OnGet()
        {

        }


        public IActionResult OnPost()
        {

            Customer newCustomer = new Customer(
                Customer.first_Name,
                Customer.last_Name,
                Customer.email,
                Customer.phoneNumber, 
                Customer.password
            );

            customerDAO.insertNew(newCustomer);

            Customer = new Customer();

            ModelState.Clear();

            return RedirectToPage("/Dashboard");

        }
    }
}