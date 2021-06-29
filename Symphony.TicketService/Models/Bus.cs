using System;

namespace Symphony.TicketService.Models
{
    public record Bus(string registrationNumber, string modelName) : Entity(Guid.NewGuid());
}