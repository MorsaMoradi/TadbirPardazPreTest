using System;
using System.Collections.Generic;
using System.Text;
using TadbirPardazPreTest.Domain;
using TadbirPardazPreTest.Service.Core.Base;

namespace TadbirPardazPreTest.Service.Core
{
   public interface IUserService : IDomainService<User,Guid>
    {
        User GetUserWithUserName(string username);
    }
}
