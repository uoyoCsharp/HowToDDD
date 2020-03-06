using ConsoleApp1.Domian.OneBoundContext.Aggregates;
using ConsoleApp1.Domian.OneBoundContext.DomianEvents;
using DomianEventDemo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1.Domian.OneBoundContext.DomianEventHandlers
{
    class ProductAddedEventHandler : IDomainEventHandler<ProductAddedEvent>
    {
        public Task HandleAysnc(ProductAddedEvent domainEvent, CancellationToken cancellationToken = default)
        {
            //do something.......

            //此处您可能通过仓储来获取
            var recommendProduct = new RecommendProduct();

            recommendProduct.UpdateRecommendProduct(domainEvent.ProductID);

            return Task.CompletedTask;
        }
    }
}
