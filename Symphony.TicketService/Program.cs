using System;
using System.Collections.Generic;
using Symphony.TicketService.Models;
using Symphony.TicketService.Visitor;

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

            var driverVisitor = new BaseVisitor<Driver>(x => x.Name == "Nikola"
                ? (true, 3)
                : (false, 0));
            
            var busVisitor = new BaseVisitor<Bus>(x => x.registrationNumber.EndsWith("XS")
                ? (true, 5)
                : (true, 1));

            var rideVisitor = new BaseVisitor<Ride>(x => x.From == "Novi Sad" ? 
                (true, 6) :
                (false, 0));
            
            var busAndDriverVisitor = new AndRuleVisitor(new List<BaseVisitor> {busVisitor, driverVisitor});
            var visitorContext = new VisitorContext(new List<Entity> {bus, busDriver});
            var busDriverDiscount = visitorContext.Accept(busAndDriverVisitor);
            
            var rideOrBusAndDriverVisitor = new OrRuleVisitor(new List<BaseVisitor> {rideVisitor, busAndDriverVisitor}); 
            visitorContext = new VisitorContext(new List<Entity> {bus, busDriver, ride});
            var rideOrBusAndDriverDiscount = visitorContext.Accept(rideOrBusAndDriverVisitor);

        }
    }
}