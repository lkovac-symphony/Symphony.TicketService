using System;

namespace Symphony.TicketService.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public Entity(Guid id)
        {
            Id = id;
        }
    }
    
}