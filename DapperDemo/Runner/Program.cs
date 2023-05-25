using DataLayer;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace Runner
{
    internal class Program
    {
        private static IConfigurationRoot config;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        static void Get_all_should_return_6_results()
        {
            //arrange
            var repository = CreateRepository();

            //act
            var Contacts = repository.GetAll();

            //asset
            Console.WriteLine($"Count: {Contacts.Count}");
            Debug.Assert( Contacts.Count == 6 );
            Contacts.Output();
        }

        private static void Initialize()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettigns.json", optional: true, reloadOnChange: true);
            config = builder.Build();
        }

        private static IContactRepository CreateRepository()
        {
            return new ContactRepository (config.GetConnectionString("DefaultConnection"));
        }
    }
}