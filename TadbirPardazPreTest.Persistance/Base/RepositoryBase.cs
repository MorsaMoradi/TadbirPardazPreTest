using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using TadbirPardazPreTest.Domain.Base;
using TadbirPardazPreTest.Persistance.Core.Base;

namespace TadbirPardazPreTest.Persistance.Base
{
    public abstract class RepositoryBase<TDomain, TIdentifier> : IRepository<TDomain, TIdentifier>
        where TDomain : DomainBase<TIdentifier>
    {
        private readonly IConfiguration _config;

       protected IDbConnection _connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        public void Dispose()
        {
            _connection.Dispose();
        }
        string tableName;

        public RepositoryBase(IConfiguration config,string tableName)
        {
            _config = config;
            this.tableName = tableName;
        }


        public abstract void Add(TDomain domain);


        public abstract void Edit(TDomain domain);

        public TDomain Get(TIdentifier id)
        {
            string sql = $"Select Top 1 * from {tableName} where id = '{id}'";
            return _connection.QueryFirstOrDefault<TDomain>(sql);
        }

        public IList<TDomain> GetAll()
        {
            string sql = $"Select  * from {tableName}";
            return _connection.Query<TDomain>(sql).ToList();
        }
    }
}
