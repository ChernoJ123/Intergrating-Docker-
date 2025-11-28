using System;
using System.Threading.Tasks;
using DBConnector;

namespace DBConnector.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to DB Connector REPL!");

            while (true)
            {
                Console.WriteLine("\nChoose a database (type 'exit' to quit):");
                Console.WriteLine("1 - MongoDB");
                Console.WriteLine("2 - PostgreSQL");
                Console.Write("Your choice: ");
                var choice = Console.ReadLine()?.Trim();

                if (choice?.ToLower() == "exit")
                    break;

                Console.Write("Enter your connection string: ");
                var connectionString = Console.ReadLine()?.Trim();

                IDBConnector connector;

                switch (choice)
                {
                    case "1":
                        connector = new MongoConnector(connectionString);
                        break;
                    case "2":
                        connector = new PostgresConnector(connectionString);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        continue;
                }

                try
                {
                    bool result = await connector.ping();
                    Console.WriteLine(result ? "Connection successful!" : "Connection failed.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            Console.WriteLine("Goodbye!");
        }
    }
}
