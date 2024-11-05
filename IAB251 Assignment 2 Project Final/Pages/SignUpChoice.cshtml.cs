using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAB251_Assignment_2_Project_Final.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IAB251_Assignment_2_Project_Final.Pages
{
	public class SignUpChoiceModel : PageModel
    {
        private readonly IUserSessionControl _userSessionService;
  

        public SignUpChoiceModel(IUserSessionControl userSessionControl)
        {
         
            _userSessionService = userSessionControl;
        }

        public IActionResult OnPost(string Logout, string Back)
        {

            if (Logout == "Logout")
            {
                _userSessionService.currentEmployeeUser = null;
                _userSessionService.currentCustomerUser = null;
                return RedirectToPage("/Index");
            }

            if (Back == "Back")
            {
                return RedirectToPage("/index");
            }
            return RedirectToPage("/index");
        }

             
        public void OnGet()
        {
        }
    }
}
