using System;

namespace Symphony.TicketService.Models
{
    public record Ticket (Guid RideId, double Price) : Entity(Guid.NewGuid());
}