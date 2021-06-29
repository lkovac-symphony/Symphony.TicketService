using System;

namespace Symphony.TicketService.Models
{
    public record Driver (string Name, Gender Age) : Entity(Guid.NewGuid());
}