using System;
using Symphony.TicketService.Models;

namespace Symphony.TicketService
{
    class Program
    {
        static void Main(string[] args)
        {
            var busDriver = new Driver("Nikola", Gender.Male);
            
            var bus = new Bus("NS 105 XS", "Fiat");
            
            var ride = new Ride(busDriver.Id,
                bus.Id,
                DateTime.Now,
                TimeSpan.FromHours(1),
                "Novi Sad",
                "Beograd");
            
            var ticket = new Ticket(ride.Id, 50);
            
        }
    }
}