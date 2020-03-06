using DomianEventDemo;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Domian.OneBoundContext.DomianEvents
{
    public class ProductAddedEvent:IDomainEvent
    {
        public Guid ProductID { get; set; }

        public string SomeInfo { get; set; }
    }
}
