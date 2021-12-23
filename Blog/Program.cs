using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = "Server=DESKTOP-BKLEGIN\\SQLEXPRESS2019;Database=Blog;User ID=sa;Password=sa123";

        static void Main(string[] args)
        {
            // CreateUser(repository);
            // UpdateUser(repository);
            // DeleteUser(repository);
            // ReadUser(repository);
            ReadUsers(new SqlConnection(CONNECTION_STRING));
            ReadRoles(new SqlConnection(CONNECTION_STRING));
            // ReadWithRoles(connection);
        }

        private static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var users = repository.Read();

            foreach (var user in users)
                Console.WriteLine(user.Name);
        }
        private static void ReadUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var user = repository.Read(1);
            Console.WriteLine(user.Name);
        }

        private static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var roles = repository.Read();

            foreach (var role in roles)
                Console.WriteLine(role.Name);
        }
        private static void ReadRole(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var role = repository.Read(1);
            Console.WriteLine(role.Name);
        }

        private static void CreateUser()
        {
            var user = new User
            {
                Bio = "Equipe balta.io",
                Email = "hello@balta.io",
                Image = "https://...",
                Name = "Equipe balta.io",
                PasswordHash = "HASH",
                Slug = "equipe-balta"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var rows = connection.Insert<User>(user);

                Console.WriteLine("Cadastro Realizado com sucesso!");
            }

        }

        private static void UpdateUser()
        {
            var user = new User
            {
                Id = 2,
                Bio = "Equipe | balta.io",
                Email = "hello@balta.io",
                Image = "https://...",
                Name = "Equipe de suporte balta.io",
                PasswordHash = "HASH",
                Slug = "equipe-balta"
            };

            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var rows = connection.Update<User>(user);

                Console.WriteLine("Cadastro Atualizado com sucesso!");
            }
        }

        private static void DeleteUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(1);

                connection.Delete<User>(user);

                Console.WriteLine("Deletado com sucesso!");
            }
        }
    }
}
