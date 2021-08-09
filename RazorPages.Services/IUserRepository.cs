using System;
using System.Collections.Generic;
using RazorPages.Models;

namespace RazorPages.Services
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUser(int id);
        User Update(User updatedUser);
        User Add(User newUser);
        User Delete(int id);
        List<User> Filter(string sex);
        List<User> FilterAll(string sex);
    }
}
