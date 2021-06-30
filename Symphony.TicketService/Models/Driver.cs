using System;

namespace Symphony.TicketService.Models
{
    public class Driver : Entity
    {
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        
        public Driver(string name, Gender gender, int age)
            : base(Guid.NewGuid())
        {
            Name = name;
            Gender = gender;
            Age = age;
        }
    }
}