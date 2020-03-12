using System.Threading;
using System.Threading.Tasks;

namespace DomainEventDemo
{
    public interface IDomainEventHandler<in TDomainEvent>
        where TDomainEvent : IDomainEvent
    {
        Task HandleAysnc(TDomainEvent domainEvent, CancellationToken cancellationToken = default);
    }
}
