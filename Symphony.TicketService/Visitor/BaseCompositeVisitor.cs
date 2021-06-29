using System;
using System.Collections.Generic;
using System.Linq;

namespace Symphony.TicketService.Visitor
{
    public abstract class BaseCompositeVisitor : BaseVisitor
    {
        protected readonly IEnumerable<BaseVisitor> _visitors;

        public BaseCompositeVisitor(IEnumerable<BaseVisitor> visitors)
        {
            _visitors = visitors ?? throw new ArgumentNullException();
        }
    }
    
    public class AndRuleVisitor : BaseCompositeVisitor
    {
        public AndRuleVisitor(IEnumerable<BaseVisitor> visitors)
            : base(visitors)
        {
        }

        public override (bool applicableDiscount, int discount) Visit(VisitorContext context) =>
            _visitors
                .Select(x => x.Visit(context))
                .Aggregate((current, next)
                    => (current.applicableDiscount && next.applicableDiscount, current.discount + next.discount));
    }
    
    public class OrRuleVisitor : BaseCompositeVisitor
    {
        public OrRuleVisitor(IEnumerable<BaseVisitor> visitors)
            : base(visitors)
        {
        }

        public override (bool applicableDiscount, int discount) Visit(VisitorContext context) =>
            _visitors
                .Select(x => x.Visit(context))
                .Aggregate((current, next)
                    => (current.applicableDiscount || next.applicableDiscount, current.discount + next.discount));
    }
}