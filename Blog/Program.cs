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
            ReadUsers();

            Console.WriteLine("Hello World!");
        }

        private static void ReadUsers()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.GetAll<User>();

                 foreach (var item in users)
                 Console.WriteLine(item.Email);
            }

            // var users = repository.Read();
            
        }
    }
}
