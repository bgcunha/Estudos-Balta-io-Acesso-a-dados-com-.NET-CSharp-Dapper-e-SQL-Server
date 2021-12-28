using System;
using Blog.Models;
using Blog.Repositories;
using Microsoft.Data.SqlClient;

namespace Blog.Screens
{

    public class Geral
    {

        public static void ReadUsers()
        {
            var repository = new Repository<User>();
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

        private static void ReadUsersWithRoles()
        {
            var repository = new UserRepository();
            var items = repository.ReadWithRole();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
                foreach (var role in item.Roles)
                    Console.WriteLine($" - {role.Name}");
            }
        }

        private static void ReadRoles()
        {
            var repository = new Repository<Role>();
            var items = repository.Read();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        private static void ReadTags()
        {
            var repository = new Repository<Tag>();
            var items = repository.Read();

            foreach (var item in items)
                Console.WriteLine(item.Name);
        }

        private static void CreateUser()
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

            var repository = new Repository<User>();
            repository.Create(user);
        }


        private static void UpdateUser()
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

            var repository = new Repository<User>();
            repository.Update(user);
        }

        private static void DeleteUser()
        {
            var repository = new Repository<User>();
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