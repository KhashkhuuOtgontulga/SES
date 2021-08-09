using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPages.Models;
using RazorPages.Services;

namespace SES.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IUserRepository userRepository;
        public IEnumerable<User> Users { get; set; }

        public IndexModel(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void OnGet()
        {
            Users = userRepository.GetAllUsers();
        }

        public IActionResult OnPostFilterMale() {
            Users = userRepository.Filter("Male");
            return Page();
        }

        public IActionResult OnPostFilterFemale()
        {
            Users = userRepository.Filter("Female");
            return Page();
        }

        public IActionResult OnPostFilterAll()
        {
            Users = userRepository.GetAllUsers();
            return Page();
        }
    }
}
