using System;
using System.Collections.Generic;
using System.Text;
using TadbirPardazPreTest.Domain.Base;
using TadbirPardazPreTest.Service.Core.Base;

namespace TadbirPardazPreTest.ServiceContract.Base
{
    public interface IApplicationServiceBase<TDomain, TDomainDto, TDomainService, TIdentitfier>
         where TDomain : DomainBase<TIdentitfier>
        where TDomainService : IDomainService<TDomain, TIdentitfier>
    {
        TDomainDto Find(TIdentitfier id);
        TDomainDto Save(TDomainDto domain);
        IList<TDomainDto> GetAll();
    }
}
