using ClassLibrary.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Data
{
    public class CurrentSession
    {
        private Guid id;
        private User? user;

        public CurrentSession()
        {
            id = new Guid();
        }

        public string GetId() { return id.ToString(); }
        public User? GetUser() { return user; }

        public void Logout() { user = null; }

        public User? Login(List<User> users, string email, string password) 
        {
            return users.FirstOrDefault(u => u.GetEmail() == email && u.GetPassword() == password, null);
        }

        public User? LoginWithGoogle(List<User> users, string googleProviderId)
        {
            throw new Exception("Login with Google");
        }

        public void RetrievePassword(List<User> users, string email)
        {
            throw new Exception("Retrieve Password");
        }

        public void SetUser(User user) // Add
        {
            this.user = user;
        }
    }
}