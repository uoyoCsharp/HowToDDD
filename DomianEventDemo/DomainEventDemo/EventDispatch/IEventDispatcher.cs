﻿using System.Threading;
using System.Threading.Tasks;

namespace DomainEventDemo.EventDispatch
{
    public interface IEventDispatcher
    {
        void Dispatch<TDomainEvent>(TDomainEvent domainEvent) where TDomainEvent : IDomainEvent;

        Task DispatchAsync<TDomainEvent>(TDomainEvent domainEvent, CancellationToken cancellationToken = default) where TDomainEvent : IDomainEvent;
    }
}
