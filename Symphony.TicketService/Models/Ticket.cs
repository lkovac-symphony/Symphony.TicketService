using System;

namespace Symphony.TicketService.Models
{
    public class Ticket : Entity
    {
        public double Price { get; set; }
        
        public Guid RideId { get; set; }
        
        public Ticket(Guid rideId, double price)
            : base(Guid.NewGuid())
        {
            RideId = rideId;
            Price = price;
        }
    };
}