using ConsoleApp1.Domian.OneBoundContext.DomianEvents;
using DomianEventDemo;
using System;

namespace ConsoleApp1.Domian.OneBoundContext.Aggregates
{
    public class ShoppingCart : Entity<Guid>
    {
        public ShoppingCart()
        {

        }

        //此处参数可能是一个Product实体，但是为了简单此处只用了ID
        public void AddProductToCart(Guid productID, string ProductInfo)
        {
            // doing something.

            Console.WriteLine("商品已经被添加到了购物车");

            this.AddDomainEvent(new ProductAddedEvent() { ProductID = productID, SomeInfo = ProductInfo });
        }
    }
}
