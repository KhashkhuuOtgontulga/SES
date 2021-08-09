using System;
using System.Collections.Generic;
using System.Linq;
using RazorPages.Models;

namespace RazorPages.Services
{
    public class MockUserRepository: IUserRepository
    {
        private List<User> _userList;

        public MockUserRepository()
        {
            _userList = new List<User>()
            {
                new User() {Id = 1, FirstName="Sara", LastName="Jones", Sex="Female", Birthday="3/23/1994"},
                new User() {Id = 2, FirstName="Mike", LastName="Lee", Sex="Male", Birthday="4/14/1999"},
                new User() {Id = 3, FirstName="Ashley", LastName="James", Sex="Female", Birthday="7/3/1996"},
                new User() {Id = 4, FirstName="John", LastName="Barthalomew", Sex="Male", Birthday="8/28/1995"}
            };
        }

        public User Add(User newUser)
        {
            newUser.Id = _userList.Max(u => u.Id) + 1;
            _userList.Add(newUser);
            return newUser;
        }

        public User Delete(int id)
        {
            var userToDelete = _userList.FirstOrDefault(u => u.Id == id);

            if (userToDelete != null)
            {
                _userList.Remove(userToDelete);
            }

            return userToDelete;
        }

        public List<User> FilterAll(string sex)
        {
            return _userList;
        }

        public List<User> Filter(string sex)
        {
            return _userList.FindAll(u => u.Sex == sex);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userList;
        }

        public User GetUser(int id)
        {
            return _userList.FirstOrDefault(e => e.Id == id);
        }

        public User Update(User updatedUser)
        {
            User user = _userList.FirstOrDefault(u => u.Id == updatedUser.Id);
            if (user != null)
            {
                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.Sex = updatedUser.Sex;
                user.Birthday = updatedUser.Birthday;
            }
            return user;
        }
    }
}
