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
            using var connection = new SqlConnection(CONNECTION_STRING);

            // DeleteUser(connection);
            CreateUser(connection);
            // UpdateUser(connection);
            // ReadUsers(connection);
            // ReadRoles(connection);
            ReadUsersWithRoles(connection);
            // ReadTags(connection);
            // ReadWithRoles(connection);
        }

        private static void ReadUsers(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var items = repository.Read();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                {
                    Console.WriteLine($" - {role.Name}");
                }
            }


        }

        private static void ReadUsersWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var items = repository.ReadWithRole();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                    Console.WriteLine($" - {role.Name}");
            }
        }

        private static void ReadRoles(SqlConnection connection)
        {
            var repository = new Repository<Role>(connection);
            var items = repository.Read();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        private static void ReadTags(SqlConnection connection)
        {
            var repository = new Repository<Tag>(connection);
            var items = repository.Read();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        private static void CreateUser(SqlConnection connection)
        {
            var user = new User
            {
                Bio = "Equipe balta.io",
                Email = "equipe@balta.io",
                Image = "https://...",
                Name = "Equipe balta.io",
                PasswordHash = "HASH",
                Slug = "equipe-balta-io"
            };

            var repository = new Repository<User>(connection);
            repository.Create(user);
        }


        private static void UpdateUser(SqlConnection connection)
        {
            var user = new User
            {
                Id = 2,
                Bio = "Equipe balta.io",
                Email = "hello@balta.io",
                Image = "https://...",
                Name = "Equipe de sustentação balta.io",
                PasswordHash = "HASH",
                Slug = "equipe-balta"
            };

            var repository = new Repository<User>(connection);
            repository.Update(user);
        }

        private static void DeleteUser(SqlConnection connection)
        {
            var repository = new Repository<User>(connection);
            var item = repository.Read(3);

            repository.Delete(item);
        }


        // private static void CreateUser()
        // {
        //     var user = new User
        //     {
        //         Bio = "Equipe balta.io",
        //         Email = "hello@balta.io",
        //         Image = "https://...",
        //         Name = "Equipe balta.io",
        //         PasswordHash = "HASH",
        //         Slug = "equipe-balta"
        //     };

        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         var rows = connection.Insert<User>(user);

        //         Console.WriteLine("Cadastro Realizado com sucesso!");
        //     }

        // }

        // private static void UpdateUser()
        // {
        //     var user = new User
        //     {
        //         Id = 2,
        //         Bio = "Equipe | balta.io",
        //         Email = "hello@balta.io",
        //         Image = "https://...",
        //         Name = "Equipe de suporte balta.io",
        //         PasswordHash = "HASH",
        //         Slug = "equipe-balta"
        //     };

        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         var rows = connection.Update<User>(user);

        //         Console.WriteLine("Cadastro Atualizado com sucesso!");
        //     }
        // }

        // private static void DeleteUser()
        // {
        //     using (var connection = new SqlConnection(CONNECTION_STRING))
        //     {
        //         var user = connection.Get<User>(1);

        //         connection.Delete<User>(user);

        //         Console.WriteLine("Deletado com sucesso!");
        //     }
        // }
    }
}
