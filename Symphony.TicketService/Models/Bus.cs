using System;

namespace Symphony.TicketService.Models
{
    public class Bus : Entity
    {
        public string RegistrationNumber { get; set; }
        public string ModelName { get; set; }
        
        public Bus(string registrationNumber, string modelName)
        : base(Guid.NewGuid())
        {
            RegistrationNumber = registrationNumber;
            ModelName = modelName;
        }
    }
}