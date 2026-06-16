using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

using System.Text.Json.Serialization;
using ClassLibrary.Trains;

namespace ClassLibrary.Users
{
    /**
    ** @brief An abstract class, stores user information: id, name, email, password, and photo. Allows users to change their name, email password and photo
    */

    [JsonDerivedType(typeof(Passenger), typeDiscriminator: "Passenger")]
    [JsonDerivedType(typeof(Staff), typeDiscriminator: "Staff")]
    public abstract class User
    {
        /// <summary>The id of the last user in the database</summary>
        [JsonInclude] static private int counter = 0;

        /// <summary>The user's id</summary>
        [JsonInclude] private int id;

        /// <summary>The user's name</summary>
        [JsonInclude] private string name;

        /// <summary>The user's email</summary>
        [JsonInclude] private string email;

        /// <summary>The user's password</summary>
        [JsonIgnore] private string password;

        /// <summary>The user's googleProviderId</summary>
        [JsonInclude] private string? googleProviderId;

        /// <summary>The user's photo</summary>
        [JsonInclude] private string photo;

        /**
        ** @brief Initialize a new instance of the User base class
        **
        ** @param The user's name
        ** @param The user's email
        ** @param The user's password
        ** @param The user's photo
        */

        [JsonConstructor]
        public User(string name, string email, string password, string photo)
        {
            id = ++counter;
            this.name = name;
            this.email = email;
            Password = password;
            this.photo = photo;
        }

        /// <summary>Gets and sets the user's password, checks it for compliance with the requirements</summary>
        [JsonInclude]
        public string Password
        {
            get
            {
                return password;
            }
            private set
            {
                if (value.Length < 8) throw new RegisterError(RegisterErrorReason.PasswordLengthOutOfRange, "The password must contain at least 8 characters");
                if (!Regex.IsMatch(value, @"[a-z]")) throw new RegisterError(RegisterErrorReason.PasswordInsecure, "The password must contain at least 1 lowercase letter");
                if (!Regex.IsMatch(value, @"[A-Z]")) throw new RegisterError(RegisterErrorReason.PasswordInsecure, "The password must contain at least 1 uppercase letter");
                if (!Regex.IsMatch(value, @"[0-9]")) throw new RegisterError(RegisterErrorReason.PasswordInsecure, "The password must contain at least 1 digit");
                if (!Regex.IsMatch(value, @"[^a-zA-Z0-9]")) throw new RegisterError(RegisterErrorReason.PasswordInsecure, "The password must contain at least 1 special character");

                password = value;
            }
        }

        /**
        ** @brief Returns the user's ID
        **
        ** @return The user's ID
        */
        public int GetId() { return id; }

        /**
        ** @brief Returns the user's name
        **
        ** @return The user's name
        */
        public string GetName() { return name; }

        /**
        ** @brief Returns the user's email
        **
        ** @return The user's email
        */
        public string GetEmail() { return email; }

        /**
        ** @brief Returns the password's ID
        **
        ** @return The user's password
        */
        public string GetPassword() { return password; }

        /**
        ** @brief Returns the user's photo
        **
        ** @return The user's photo
        */
        public string GetPhoto() { return photo; }

        /**
        ** @brief Sets the user's name to the input parameter
        **
        ** @param The user's name
        */
        public void ChangeName(string name) { this.name = name; }

        /**
        ** @brief Sets the user's email to the input parameter
        **
        ** @param The user's email
        */
        public void ChangeEmail(string email) { this.email = email; }

        /**
        ** @brief Sets the user password for the input parameter if it meets the requirements
        **
        ** @param The user's password
        */
        public void ChangePassword(string password) { this.Password = password; }

        /**
        ** @brief Sets the user's photo to the input parameter
        **
        ** @param The user's photo
        */
        public void ChangePhoto(string photo) { this.photo = photo; }
    }
}
