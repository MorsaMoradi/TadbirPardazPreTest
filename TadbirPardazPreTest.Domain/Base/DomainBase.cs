using System;
using System.Collections.Generic;
using System.Text;

namespace TadbirPardazPreTest.Domain.Base
{
   public abstract class DomainBase<TIdentifier> : IDomain<TIdentifier>
    {
        public TIdentifier Id { get; protected set; }
        public void SetId(TIdentifier id)
        {
            Id = id;
        }

    }
}
