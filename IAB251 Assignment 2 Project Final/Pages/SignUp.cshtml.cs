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
        public string firstName { get; set; }

        [BindProperty]
        public string lastName { get; set; }

        //ok i did some reading, you need to bind these first, from your main file to your code behind file, this is what i was saying
        //to you earlier on tuesday by 'pulling from html to the code behind', then once youve done all this you can create a new customer from
        //the inputs ie customer = new customer(first_Name) etc.. and then insert it to the DAO, which should be instantised on view start or whatever
        //the initalisation page is.

        //im going to bed but heres the web page i quickly browsed https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-8.0&tabs=visual-studio
        //also heres another, a bit more comples but was helpful for me https://learn.microsoft.com/en-us/answers/questions/1823580/asp-net-core-razor-pages-bindproperty-collections


        /*
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
        */
    }
}