using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string serviceUri = "http://localhost:65284/";
            var container = new xConsoleApplication.Default.Container(new Uri(serviceUri));

            Console.WriteLine("Lista wszystkich gier:");
            foreach (var game in container.Games)
            {
                Console.WriteLine("{0} (by {1} {2})", game.Title, game.CreatorCompany, game.Year);
            }

            Console.WriteLine("Dodanie nowej gry");
            container.AddToGames(new xConsoleApplication.Library.Game() { Title = "GTA San Andreas", CreatorCompany = "Rockstar", ID = 1 });
            var serviceResponse = container.SaveChanges();

            Console.WriteLine("Lista wszystkich gier:");
            foreach (var game in container.Games)
            {
                Console.WriteLine("{0} (by {1} {2})", game.Title, game.CreatorCompany, game.Year);
            }

            //kody odpowiedzi
            foreach (var operationResponse in serviceResponse)
            {
                Console.WriteLine("Response: {0}", operationResponse.StatusCode);
            }
            Console.WriteLine();

            Console.WriteLine("Lista wszystkich koszulek na karty:");
            foreach (var cardShirt in container.GetAvailableCardShirts().ToList())
            {
                Console.WriteLine("{0} : {1}", cardShirt.ID, cardShirt.Name);
            }
            Console.WriteLine();

            Console.WriteLine("Lista wszystkich sklepów:");
            foreach (var store in container.Stores)
            {
                Console.WriteLine("{0} ({1})", store.Name, store.Address);
            }
            Console.WriteLine();

            Console.WriteLine("Usuwanie sklepu o ID = 3:");
            container.Stores.Where(x => x.ID == 3).ToList().ForEach(x => container.DeleteObject(x));
            serviceResponse = container.SaveChanges();
            foreach (var operationResponse in serviceResponse)
            {
                Console.WriteLine("Response: {0}", operationResponse.StatusCode);
            }
            Console.WriteLine();

            Console.WriteLine("Lista wszystkich sklepów:");
            foreach (var store in container.Stores)
            {
                Console.WriteLine("{0} ({1})", store.Name, store.Address);
            }
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
