using System.Collections.Generic;
using System.Linq;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repositories
{
    public class Repository<TModel> where TModel : class
    {
        // private readonly SqlConnection _connection;

        // public Repository(SqlConnection connection) => _connection = connection;

        public IEnumerable<TModel> Get() => Database.Connection.GetAll<TModel>();
        public void Create(TModel model) => Database.Connection.Insert(model);

        public List<TModel> Read() => Database.Connection.GetAll<TModel>().ToList();

        public TModel Read(int id) => Database.Connection.Get<TModel>(id);

        public void Update(TModel model) => Database.Connection.Update(model);

        public void Delete(TModel model) => Database.Connection.Delete(model);
        public void Delete(int id)
        {
            var model = Read(id);
            Database.Connection.Delete(model);
        }
    }
}