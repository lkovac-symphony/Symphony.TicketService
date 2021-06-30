using System;
using Symphony.TicketService.Models;

namespace Symphony.TicketService.Service
{
    public class TicketingService : ITicketingService
    {
        // You'll take it from here!
        public int CalculateTicketPrice(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }

    public interface ITicketingService
    {
        int CalculateTicketPrice(Ticket ticket);
    }
}