using System;
using Symphony.TicketService.Models;
using Symphony.TicketService.Service;
using Symphony.TicketService.Storage;

namespace Symphony.TicketService
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IRepository repository = new Repository();

            var busDriver = new Driver("Nikola", Gender.Male, 51);
            repository.Add(busDriver);

            var bus = new Bus("NS 105 XS", "Fiat");
            repository.Add(bus);

            var ride = new Ride(busDriver.Id,
                bus.Id,
                DateTime.Now,
                TimeSpan.FromHours(1),
                "Novi Sad",
                "Beograd");
            repository.Add(ride);


            var ticket = new Ticket(ride.Id, 50);

            ITicketingService ticketingService = new TicketingService();
            ticketingService.CalculateTicketPrice(ticket);
        }
    }
}