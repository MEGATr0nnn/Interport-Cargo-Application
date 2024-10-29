using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IAB251_Assignment_2_Project_Final.Pages
{
	public class SignUpPageModel : PageModel
    {
        [BindProperty]
        public Customer Customer { get; set; } = new Customer("", "", "", 0, "");

        private CustomerDAO customerDAO;

        public string accountExists;

        public SignUpPageModel(CustomerDAO customerDAO)
        {
            customerDAO = new CustomerDAO();
        }


        public void OnGet()
        {

        }


        public IActionResult OnPost()
        {
            if (customerDAO.Equals(Customer))
            {
                accountExists = "There is already an account associated with that email address";
                return Page();
            }

            customerDAO.insertNew(Customer);
            
            Customer = new Customer();

            ModelState.Clear();

            return RedirectToPage("/Dashboard");

        }
    }
}
