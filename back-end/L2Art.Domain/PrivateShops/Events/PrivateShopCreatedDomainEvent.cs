using L2Art.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Art.Domain.PrivateShops.Events
{
    public record PrivateShopCreatedDomainEvent(Guid NewItemId) : IDomainEvent;
}
