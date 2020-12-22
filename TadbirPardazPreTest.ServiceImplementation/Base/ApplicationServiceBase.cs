using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadbirPardazPreTest.Domain.Base;
using TadbirPardazPreTest.Service.Core.Base;
using TadbirPardazPreTest.ServiceContract.Base;

namespace TadbirPardazPreTest.ServiceImplementation.Base
{
    public class ApplicationServiceBase<TDomain, TDomainDto, TDomainService, TIdentitfier> : IApplicationServiceBase<TDomain, TDomainDto, TDomainService, TIdentitfier>
          where TDomain : DomainBase<TIdentitfier>
         where TDomainService : IDomainService<TDomain, TIdentitfier>
    {
        public ApplicationServiceBase(TDomainService domainService, IEntityMapper<TDomain, TDomainDto> mapper)
        {
            DomainService = domainService;
            Mapper = mapper;
        }

        TDomainService DomainService {get; }
        public  IEntityMapper<TDomain,TDomainDto> Mapper { get;protected set; }
        public TDomainDto Find(TIdentitfier id)
        {
            var result = DomainService.Find(id);
            return Mapper.MappTo(result);
        }

        public IList<TDomainDto> GetAll()
        {
            var list = DomainService.GetAll();
            return list.Select(t => Mapper.MappTo(t)).ToList();
        }

        public TDomainDto Save(TDomainDto domain)
        {
            return Mapper.MappTo(DomainService.Save(Mapper.CreateFrom(domain)));
        }
    }
}
