using System;
using System.Collections.Generic;
using System.Text;

namespace BAYSOFT.Abstractions.Core.Domain.Entities
{
    public class DomainEntity<TIdType> : DomainEntity
    {
        public TIdType Id { get; set; }
    }

    public class DomainEntity
    {

    }
}
