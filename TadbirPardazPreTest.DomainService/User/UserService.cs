using System;
using System.Collections.Generic;
using System.Text;
using TadbirPardazPreTest.Domain;
using TadbirPardazPreTest.DomainService.Base;
using TadbirPardazPreTest.Persistance.Core;
using TadbirPardazPreTest.Service.Core;

namespace TadbirPardazPreTest.DomainService
{
    public class UserService : DomainServiceBase<User, Guid, IUserRepository>, IUserService
    {
        public UserService(IUserRepository userRepository) : base(userRepository)
        {

        }

        public User GetUserWithUserName(string username)
        {
            return Repository.GetUserWithUsername(username);
        }

        public override User Save(User domain)
        {
            var user = Repository.GetUserWithUsername(domain.Username);
            if (user != null && domain.Id != user.Id)
                throw new ArgumentException("User Duplicate");
            if (domain.Id == Guid.Empty)
                domain.SetId(Guid.NewGuid());
            return base.Save(domain);
        }
    }
}
