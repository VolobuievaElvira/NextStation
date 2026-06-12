using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Text.RegularExpressions;

using System.Text.Json.Serialization;
using ClassLibrary.Trains;

namespace ClassLibrary.Users
{
    [JsonDerivedType(typeof(Passenger), typeDiscriminator: "Passenger")]
    [JsonDerivedType(typeof(Staff), typeDiscriminator: "Staff")]
    public abstract class User
    {
        [JsonInclude] static private int counter = 0;

        [JsonInclude] private int id;
        [JsonInclude] private string name;
        [JsonInclude] private string email;
        [JsonIgnore] private string password;
        [JsonInclude] private string? googleProviderId;
        [JsonInclude] private string photo;

        [JsonConstructor]
        public User(string name, string email, string password, string photo)
        {
            id = ++counter;
            this.name = name;
            this.email = email;
            Password = password;
            this.photo = photo;
        }

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

        public int GetId() { return id; }
        public string GetName() { return name; }
        public string GetEmail() { return email; }
        public string GetPassword() { return password; }
        public string GetPhoto() { return photo; }
        public void ChangeName(string name) { this.name = name; }
        public void ChangeEmail(string email) { this.email = email; }
        public void ChangePassword(string password) { this.Password = password; }
        public void ChangePhoto(string photo) { this.photo = photo; }
    }
}
