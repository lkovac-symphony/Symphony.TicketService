using System;

namespace Symphony.TicketService.Models
{
    public record Ride(Guid BusDriverId,
        Guid BusId,
        DateTime StartTime,
        TimeSpan Duration,
        string From,
        string To) : Entity(Guid.NewGuid());
}