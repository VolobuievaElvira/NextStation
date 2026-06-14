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
    public class Staff : User
    {
        [JsonInclude] private Role role;

        [JsonConstructor]
        public Staff(string name, string email, string password, string photo, Role role) : base(name, email, password, photo) 
        {
            this.role = role;
        }

        public Role GetRole() { return this.role; } //Add!!
        public void PromoteToTrainOperator() { this.role = Role.TrainOperator; }
        public void PromoteToConductor() { this.role = Role.Conductor; }
        public void PromoteToNetworkManager() { this.role = Role.NetworkManager; }
        public void PromoteToStationManager() { this.role = Role.StationManager; }
        
        public bool ValidateTicket(Ticket ticket)
        {
            throw new Exception("Ticket validation");
        }
    }
}