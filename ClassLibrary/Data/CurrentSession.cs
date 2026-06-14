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
        private static Guid id;
        private static User? user;

        public CurrentSession()
        {
            id = new Guid();
        }

        public static string GetId() { return id.ToString(); }
        public static User? GetUser() { return user; }

        public static void Logout() { user = null; }

        public static User? Login(List<User> users, string email, string password) 
        {
            return users.FirstOrDefault(u => u.GetEmail() == email && u.GetPassword() == password, null);
        }

        public static User? LoginWithGoogle(List<User> users, string googleProviderId)
        {
            throw new Exception("Login with Google");
        }

        public static void RetrievePassword(List<User> users, string email)
        {
            throw new Exception("Retrieve Password");
        }

        public static void SetUser(User _user) // Add
        {
            user = _user;
        }
    }
}