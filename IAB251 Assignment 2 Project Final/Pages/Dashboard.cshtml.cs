using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IAB251_Assignment_2_Project_Final.Pages
{
	public class DashboardModel : PageModel
    {
        public List<CustomerModel> Customers { get; set; }

        public Customer cus;

        public readonly CustomerDAO customerDAO;


        public void OnGet()
        { 


        }
    }
}
