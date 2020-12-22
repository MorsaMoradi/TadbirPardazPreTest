using System;
using System.Collections.Generic;
using System.Text;
using TadbirPardazPreTest.DataContract;
using TadbirPardazPreTest.Domain;
using TadbirPardazPreTest.Service.Core;
using TadbirPardazPreTest.ServiceContract;
using TadbirPardazPreTest.ServiceContract.Base;
using TadbirPardazPreTest.ServiceImplementation.Base;

namespace TadbirPardazPreTest.ServiceImplementation
{
    public class UserApplicationService : ApplicationServiceBase<User, UserDto, IUserService, Guid>,IUserApplicationService
    {
        public UserApplicationService(IUserService domainService, IEntityMapper<User, UserDto> mapper) : base(domainService, mapper)
        {
        }
    }
}
