using System;
using System.Collections.Generic;
using System.Text;
using TadbirPardazPreTest.Domain.Base;

namespace TadbirPardazPreTest.Persistance.Core.Base
{
    public interface IRepository<TDomain, TIdentifier>: IDisposable
        where TDomain : DomainBase<TIdentifier>
    {
        void Add(TDomain domain);
        void Edit(TDomain domain);
        TDomain Get(TIdentifier id);
        IList<TDomain> GetAll();
    }
}
