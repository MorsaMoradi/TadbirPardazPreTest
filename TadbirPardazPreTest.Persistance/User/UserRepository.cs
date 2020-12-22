using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TadbirPardazPreTest.Domain;
using TadbirPardazPreTest.Persistance.Base;
using TadbirPardazPreTest.Persistance.Core;

namespace TadbirPardazPreTest.Persistance
{
    public class UserRepository : RepositoryBase<User, Guid>, IUserRepository
    {
        public UserRepository(IConfiguration config) : base(config,"Users")
        {
        }

        public override void Add(User domain)
        {
            var sql = "AddUser ";
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@id", domain.Id);
            parameter.Add("@Username", domain.Username);
            parameter.Add("@FirstName", domain.FirstName);
            parameter.Add("@LastName", domain.LastName);
            parameter.Add("@Email", domain.Email);
            parameter.Add("@PhoneNumber", domain.PhoneNumber);


            _connection.Execute(sql,
                parameter,
                commandType: CommandType.StoredProcedure);

        }
        public override void Edit(User domain)
        {
            var sql = "EditUser ";
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@id", domain.Id);
            parameter.Add("@Username", domain.Username);
            parameter.Add("@FirstName", domain.FirstName);
            parameter.Add("@LastName", domain.LastName);
            parameter.Add("@Email", domain.Email);
            parameter.Add("@PhoneNumber", domain.PhoneNumber);


            _connection.Execute(sql,
                parameter,
                commandType: CommandType.StoredProcedure);

        }
        public User GetUserWithUsername(string username)
        {
          return  _connection.QueryFirstOrDefault<User>($"select top 1 * from users where username='{username}'");
        }
    }
}
