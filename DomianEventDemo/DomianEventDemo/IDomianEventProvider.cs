using System.Collections.Generic;

namespace DomianEventDemo
{
    public interface IDomianEventProvider
    {
        /// <summary>
        /// Get All DomainEvents
        /// </summary>
        List<IDomainEvent> GetDomainEvents();
    }
}
