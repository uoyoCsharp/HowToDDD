using DomianEventDemo;
using System;

namespace ConsoleApp1.Domian.OneBoundContext.Aggregates
{
    public class RecommendProduct : Entity<Guid>
    {
        public RecommendProduct()
        {
        }

        public void UpdateRecommendProduct(Guid productID)
        {
            //do something

            Console.WriteLine($"根据ID :{productID},推荐一些奇奇怪怪的商品");
        }
    }
}
