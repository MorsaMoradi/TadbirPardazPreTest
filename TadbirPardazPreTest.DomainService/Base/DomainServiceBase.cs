using System;
using System.Collections.Generic;
using System.Text;
using TadbirPardazPreTest.Domain.Base;
using TadbirPardazPreTest.Persistance.Core.Base;
using TadbirPardazPreTest.Service.Core.Base;

namespace TadbirPardazPreTest.DomainService.Base
{
    public class DomainServiceBase<TDomain, TIdentifier,TRepository> : IDomainService<TDomain, TIdentifier>
         where TDomain : DomainBase<TIdentifier>
        where TRepository:IRepository<TDomain,TIdentifier>
    {
        public DomainServiceBase(TRepository repository)
        {
            Repository = repository;
        }

        public TRepository Repository { get; protected set; }
        public TDomain Find(TIdentifier id)
        {
            return Repository.Get(id);
        }

        public IList<TDomain> GetAll()
        {
            return Repository.GetAll();
        }

        public virtual TDomain Save(TDomain domain)
        {
            if (Find(domain.Id) == null)
                Repository.Add(domain);
            else
                Repository.Edit(domain);
            return domain;
        }
    }
}
