using ConsoleApp1.Domain.OneBoundContext.Aggregates;
using DomainEventDemo.EventDispatch;
using DomainEventDemo.Registrar;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddSingleton<IEventDispatcher, EventDispatcher>();

            var needScanAsm = new Assembly[1] { typeof(Program).Assembly };
            DomainEventHandlerRegistrar.ResigterDomainEventHandler(services, needScanAsm);

            var shoppingCart = new ShoppingCart();

            //添加一些商品
            shoppingCart.AddProductToCart(Guid.NewGuid(), "no info");

            //该处操作一般放置在工作单元保存之前，比如EF Core 的 savechanges 之前
            var dispatcher = services.BuildServiceProvider().GetService<IEventDispatcher>();
            foreach (var @event in shoppingCart.GetDomainEvents())
            {
                dispatcher.Dispatch(@event);
            }
        }
    }
}
