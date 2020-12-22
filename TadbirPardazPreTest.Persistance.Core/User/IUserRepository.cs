using System;
using System.Collections.Generic;
using System.Text;
using TadbirPardazPreTest.Domain;
using TadbirPardazPreTest.Persistance.Core.Base;

namespace TadbirPardazPreTest.Persistance.Core
{
    public interface IUserRepository:IRepository<User,Guid>
    {
        User GetUserWithUsername(string username);
    }
}
