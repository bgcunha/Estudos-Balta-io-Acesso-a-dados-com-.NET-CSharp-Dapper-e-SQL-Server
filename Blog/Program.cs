using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System;

namespace Blog
{
    class Program
    {
        private readonly static string CONNECTION_STRING = "Server=DESKTOP-BKLEGIN\\SQLEXPRESS2019;Database=Blog;User ID=sa;Password=sa123";

        static void Main(string[] args)
        {
            DeleteUser();
        }

        private static void ReadUsers()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.GetAll<User>();

                foreach (var item in users)
                    Console.WriteLine(item.Email);
            }

        }
        private static void ReadUser()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var user = connection.Get<User>(1);
                Console.WriteLine(user.Email);
            }
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
