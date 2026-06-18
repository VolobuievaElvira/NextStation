using ClassLibrary.Users;

namespace ClassLibrary.Data
{
    /**
    ** @brief Stores information about the user who is working with the system. Allows the user to log in and out
    */
    public class CurrentSession
    {
        /// <summary>User who is working with the system</summary>
        private User? user;

        /**
        ** @brief Returns the user who is working with the system
        **
        ** @return The user who is working with the system
        */
        public User? GetUser() { return user; }

        /**
        ** @brief Allows the user to log out from the current session
        */
        public void Logout() { user = null; }
        
        
        /**
        ** @brief Sets the user who is working with the system
        **
        ** @param user The user who is working with the system
        */
        public void SetUser(User newUser)
        {
            user = newUser;
        }
        
        /**
        ** @brief Returns the user whose email and password matches the input parameters
        **
        ** @param users A list of users present in the database
        ** @param email An entered email
        ** @param password An entered password
        **
        ** @return The user whose email and password matches the input parameters
        */
        public User? Login(List<User> users, string email, string password) 
        {
            return users.FirstOrDefault(u => u?.GetEmail() == email && u.GetPassword() == password, null);
        }

        /**
        ** @brief Returns the user whose googleProviderId matches the input parameter
        **
        ** @param users A list of users present in the database
        ** @param googleProviderId The user's googleProviderId
        **
        ** @return The user whose googleProviderId matches the input parameter
        */
        public User? LoginWithGoogle(List<User> users, string googleProviderId)
        {
            throw new Exception("Login with Google");
        }

        /**
        ** @brief Retrieve the user's password
        **
        ** @param users A list of users present in the database
        ** @param email The user's email
        */
        public void RetrievePassword(List<User> users, string email)
        {
            throw new Exception("Retrieve Password");
        }
    }
}