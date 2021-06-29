using System;
using Symphony.TicketService.Models;

namespace Symphony.TicketService.Visitor
{
    public class BaseVisitor<T> : BaseVisitor where T : Entity
    {
        private readonly Func<T, (bool, int)> _evaluate;

        public BaseVisitor(Func<T, (bool, int)> evaluate)
        {
            _evaluate = evaluate ?? throw new ArgumentNullException();
        }

        public override (bool applicableDiscount, int discount) Visit(VisitorContext context) 
            => context.Entity is T typedContext ? 
                _evaluate?.Invoke(typedContext) ?? (false, 0)
                : (false, 0);
    }

    public abstract class BaseVisitor
    {
        public virtual (bool applicableDiscount, int discount) Visit(VisitorContext context) => (false, 0);
    }
}