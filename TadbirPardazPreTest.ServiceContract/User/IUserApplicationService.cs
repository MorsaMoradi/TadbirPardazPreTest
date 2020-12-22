using System;
using System.Collections.Generic;
using System.Text;
using TadbirPardazPreTest.DataContract;
using TadbirPardazPreTest.Domain;
using TadbirPardazPreTest.Service.Core;
using TadbirPardazPreTest.ServiceContract.Base;

namespace TadbirPardazPreTest.ServiceContract
{
   public interface IUserApplicationService:IApplicationServiceBase<User,UserDto,IUserService,Guid>
    {
    }
}
