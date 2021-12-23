using System.Collections.Generic;
using System.Linq;
using Blog.Models;
using Dapper;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class RoleRepository : Repository<Role>
    {
        private readonly SqlConnection _connection;

        public RoleRepository(SqlConnection connection) : base(connection)
            => _connection = connection;
    }
}