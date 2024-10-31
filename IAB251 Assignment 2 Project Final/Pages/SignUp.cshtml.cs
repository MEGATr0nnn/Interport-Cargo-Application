using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IAB251_Assignment_2_Project_Final.Pages
{
    public class SignUp : PageModel
    {
        /// <summary>
        /// 
        /// </summary>
        [BindProperty]
        [Required(ErrorMessage = "First Name is Required")]
        public string firstName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Last Name is Required")]
        public string lastName { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Email Address is Required")]
        public string email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Phone Number is Required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number is not a valid number")]
        public string phoneNumber { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is Required")]
        public string password { get; set; }

        //ok i did some reading, you need to bind these first, from your main file to your code behind file, this is what i was saying
        //to you earlier on tuesday by 'pulling from html to the code behind', then once youve done all this you can create a new customer from
        //the inputs ie customer = new customer(first_Name) etc.. and then insert it to the DAO, which should be instantised on view start or whatever
        //the initalisation page is. THE insertion probably wont work until i figure out how the system wants the DB initalised but that reading is 
        //too complex for midnight

        //im going to bed but heres the web page i quickly browsed https://learn.microsoft.com/en-us/aspnet/core/razor-pages/?view=aspnetcore-8.0&tabs=visual-studio
        //also heres another, a bit more comples but was helpful for me https://learn.microsoft.com/en-us/answers/questions/1823580/asp-net-core-razor-pages-bindproperty-collections


        //session control
        private IUserSessionControl _userSessionControl;

        //pulling vars
        private CustomerDAO _customerDAO;

        //!!I WATCHED A VIDEO ON C# SYNTAX, ALL PRIVATE FIELDS MUST BE DENOTED WITH AN _ ACCORDING TO C# COMMON PRACTICE

        public string accountExists;

        /// <summary>
        /// Creating a new instance of the CustomerDAO to store users
        /// </summary>
        public SignUp()
        {
           _customerDAO = new CustomerDAO();
        }


        /// <summary>
        /// 
        /// </summary>
        public void OnGet()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult OnPost()
        {
            Customer currentUser = new Customer(firstName, lastName, email, phoneNumber, password);

            _customerDAO.insertNew(currentUser);

            //_userSessionControl.currentCustomerUser = currentUser;

            ModelState.Clear();

            return RedirectToPage("/QuotationRequest");

        }
        
    }
}