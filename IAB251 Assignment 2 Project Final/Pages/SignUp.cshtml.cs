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

        [BindProperty]
        public string email { get; set; }

        [BindProperty]
        public int phoneNumber { get; set; }

        [BindProperty]
        public string password { get; set; }

        //ok i did some reading, you need to bind these first, from your main file to your code behind file, this is what i was saying
        //to you earlier on tuesday by 'pulling from html to the code behind', then once youve done all this you can create a new customer from
        //the inputs ie customer = new customer(first_Name) etc.. and then insert it to the DAO, which should be instantised on view start or whatever
        //the initalisation page is. THE insertion probably wont work until i figure out how the system wants the DB initalised but that reading is 
        //too complex for midnight

        //im going to bed but heres the web page i quickly browsed https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-8.0&tabs=visual-studio
        //also heres another, a bit more comples but was helpful for me https://learn.microsoft.com/en-us/answers/questions/1823580/asp-net-core-razor-pages-bindproperty-collections



        public CustomerDAO customerDAO;

        public string accountExists;

        public SignUp()
        {
           customerDAO = new CustomerDAO();
        }


        public void OnGet()
        {

        }


        public IActionResult OnPost()
        {
            Console.WriteLine("Testing ");

            Customer currentUser = new Customer(
                firstName,
                lastName,
                email,
                phoneNumber,
                password
            );

            customerDAO.insertNew(currentUser);

            ModelState.Clear();

            return RedirectToPage("/Dashboard");

        }
        
    }
}