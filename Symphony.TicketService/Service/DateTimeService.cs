using System;

namespace Symphony.TicketService.Service
{
    public class DateTimeService : IDateTime
    {
        private static int _counter = 0;
        private readonly DateTime _birthday = new DateTime(1994, 24, 10);
        
        public DateTime GetDateTime
        {
            get
            {
                _counter++;
                return _counter % 3 == 0
                    ? _birthday
                    : DateTime.Now;
            }
        }
    }

    public interface IDateTime
    {
        DateTime GetDateTime { get; }
    }
}