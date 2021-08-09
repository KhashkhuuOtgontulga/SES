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
    public class DetailsModel : PageModel
    {
        private readonly IUserRepository userRepository;

        public DetailsModel(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public User User { get; private set; }

        public void OnGet(int id)
        {
            User = userRepository.GetUser(id);
        }
    }
}
