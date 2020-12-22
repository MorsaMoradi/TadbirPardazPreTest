using System;
using System.Collections.Generic;
using System.Text;

namespace TadbirPardazPreTest.Service.Core.Base
{
   public interface IDomainService<TDomain,TIdentifier>
    {
        TDomain Save(TDomain domain);
        IList<TDomain> GetAll();
        TDomain Find(TIdentifier id);
    }
}
