using System;

namespace Symphony.TicketService.Models
{
    public record Driver (string Name, Gender Gender, int Age) : Entity(Guid.NewGuid());
}