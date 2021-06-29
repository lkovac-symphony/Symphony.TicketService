using Symphony.TicketService.Models;

namespace Symphony.TicketService.Visitor
{
    public class VisitorContext
    {
        public Entity Entity { get; }
        
        public VisitorContext(Entity entity)
        {
            Entity = entity;
        }

        public (bool applicable, int discount) Accept(BaseVisitor visitor) => visitor.Visit(this);
    }

    public class CompositeVisitorContext : VisitorContext
    {
        public CompositeVisitorContext(Entity entity)
            : base(entity)
        {
        }
    }
}