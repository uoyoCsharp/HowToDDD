using DomainEventDemo;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Domain.OneBoundContext.DomainEvents
{
    public class ProductAddedEvent:IDomainEvent
    {
        public Guid ProductID { get; set; }

        public string SomeInfo { get; set; }
    }
}
