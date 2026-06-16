using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;
using System.Net;
using System.Reflection.Emit;
using ClassLibrary.Trains;

namespace ClassLibrary.Users
{
    /**
    ** @brief Stores the staff role, allows changing the user role to change the permission level
    */
    public class Staff : User
    {
        /// <summary>The staff's role</summary>
        [JsonInclude] private Role role;

        /**
        ** @brief Initialize a new instance of the Staff class
        **
        ** @param name The staff's name
        ** @param email The staff's email
        ** @param password The staff's password
        ** @param photo The staff's photo
        ** @param role The staff's role
        */

        [JsonConstructor]
        public Staff(string name, string email, string password, string photo, Role role) : base(name, email, password, photo) 
        {
            this.role = role;
        }

        /**
        ** @brief Returns the staff's role
        **
        ** @return The staff's role
        */
        public Role GetRole() { return this.role; }

        /**
        ** @brief Sets the role to TrainOperator
        */
        public void PromoteToTrainOperator() { this.role = Role.TrainOperator; }

        /**
        ** @brief Sets the role to Conductor
        */
        public void PromoteToConductor() { this.role = Role.Conductor; }

        /**
        ** @brief Sets the role to NetworkManager
        */
        public void PromoteToNetworkManager() { this.role = Role.NetworkManager; }

        /**
        ** @brief Sets the role to StationManager
        */
        public void PromoteToStationManager() { this.role = Role.StationManager; }

        /**
        ** @brief Returns if the ticket is valid for a specific trip
        **
        ** @return Whether the ticket is valid for a specific trip
        */
        public bool ValidateTicket(Ticket ticket)
        {
            throw new Exception("Ticket validation");
        }
    }
}