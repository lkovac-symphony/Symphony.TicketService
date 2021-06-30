using System;

namespace Symphony.TicketService.Models
{
    public class Ride : Entity
    {
        public Guid BusDriverId { get; set; } 
        public Guid BusId { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public Ride(Guid busDriverId,
            Guid busId,
            DateTime startTime,
            TimeSpan duration,
            string from,
            string to)
            : base(Guid.NewGuid())
        {
            BusDriverId = busDriverId;
            BusId = busId;
            StartTime = startTime;
            Duration = duration;
            From = from;
            To = to;
        }
        
    }
    
}