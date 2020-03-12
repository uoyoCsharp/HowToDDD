using System.Collections.Generic;

namespace DomainEventDemo
{
    public interface IDomainEventProvider
    {
        /// <summary>
        /// Get All DomainEvents
        /// </summary>
        List<IDomainEvent> GetDomainEvents();
    }
}
