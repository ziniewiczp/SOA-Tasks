using SpaceClient.ServiceReference1;
using System;
using System.Linq;


namespace SpaceClient
{
    class Program
    {
        static void Main(string[] args)
        {
            BlackHoleClient bhc = new BlackHoleClient();

            Starship ship1 = new Starship() { Name = "Statek mocy", Captain = new Person() { Name = "Piotr", Age = 35 } };
            ship1.Crew = new Person[] { new Person() { Name = "Maciej", Age = 25 }, new Person() { Name = "Diana", Age = 26 }, new Person() { Name = "Łukasz", Age = 20 }, new Person() { Name = "Stanisław", Age = 50 }, new Person() { Name = "Aleksandra", Age = 33 } };

            Console.WriteLine("Przed PullStarship:");
            PresentCrew(ship1);

            Starship ship2 = bhc.PullStarship(ship1);

            Console.WriteLine("Po PullStarship:");
            PresentCrew(ship2);

            Console.WriteLine("Ultimate answer: {0}", bhc.UltimateAnswer());

            Console.ReadLine();
        }

        public static void PresentCrew(Starship starship)
        {
            Console.WriteLine("Kapitan:");
            Console.WriteLine("Imię: {0}, Wiek: {1}", starship.Captain.Name, starship.Captain.Age);
            Console.WriteLine();
            Console.WriteLine("Załoga:");
            
            foreach (Person pers in starship.Crew)
            {
                Console.WriteLine("Imię: {0}, Wiek: {1}", pers.Name, pers.Age);
            }
            Console.WriteLine();
        }
    }
}
