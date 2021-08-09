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
    public class EditModel : PageModel
    {
        private readonly IUserRepository userRepository;

        public EditModel(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User User { get; private set; }

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                User = userRepository.GetUser(id.Value);
            }
            else
            {
                User = new User();
            }

            if (User == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(User user)
        {
            if (ModelState.IsValid) {
                if (user.Id > 0)
                {
                    User = userRepository.Update(user);
                }
                else
                {
                    User = userRepository.Add(user);
                }
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
