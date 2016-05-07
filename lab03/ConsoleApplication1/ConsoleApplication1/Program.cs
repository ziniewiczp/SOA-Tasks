using ConsoleApplication1.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static List<Starship> _starships = new List<Starship>();
        static bool _anySystem = true;
        static int _gold = 1000;
        static int _imperiumMoneyAskCount = 4;

        static void Main(string[] args)
        {
            //1st client added by service reference
            Service1Client cosmos = new Service1Client();
            //2nd client added by service reference
            FirstOrder.Service1Client firstOrder = new FirstOrder.Service1Client();

            cosmos.InitializeGame();

            bool gameEnd = false;

            do
            {
                Console.WriteLine("Ilość złota: {0}", _gold);
                Console.WriteLine("Ilość próśb o złoto do imperium: {0}", _imperiumMoneyAskCount);
                Console.WriteLine();
                Console.WriteLine("a) Poproś imperium o złoto");
                Console.WriteLine("b) Kup statek za złoto");
                Console.WriteLine("c) Wyślij statek do systemu");
                Console.WriteLine("d) Zakończ grę");

                var input = Console.ReadKey();

                switch (input.Key)
                {
                    case ConsoleKey.A:
                        if (_imperiumMoneyAskCount > 0)
                        {
                            _gold = _gold + firstOrder.GetMoneyFromImperium();
                            _imperiumMoneyAskCount--;
                        }

                        Console.WriteLine();
                        Console.WriteLine();

                        break;

                    case ConsoleKey.B:
                        Console.WriteLine();
                        Console.WriteLine("Aktualne złoto: {0}. Wpisz za ile złota chcesz kupić statek.", _gold);
                        int kwota = Convert.ToInt32(Console.ReadLine());

                        if (kwota <= _gold)
                        {
                            Starship newShip = cosmos.GetStarship(kwota);
                            _gold = _gold - kwota;
                            _starships.Add(newShip);
                        }
                        else Console.WriteLine("Wybrana kwota jest zbyt duża.");

                        Console.WriteLine();
                        Console.WriteLine();

                        break;

                    case ConsoleKey.C:
                        SpaceSystem system = cosmos.GetSystem();
                        if (system == null)
                        {
                            _anySystem = false;
                            Console.WriteLine();
                            Console.WriteLine("Brak systemów");

                            Console.WriteLine();
                            Console.WriteLine();
                        }
                        else if (_starships.Any())
                        {
                            Console.WriteLine();
                            Console.WriteLine("System {0}, odległość {1}", system.Name, system.BaseDistance);
                            Console.WriteLine("Statków gotowych do podróży: {0}", _starships.Count);
                            Console.WriteLine();
                            Console.WriteLine("Wybierz statek wpisując jego numer (lub naciśnij e aby wyjść)");

                            int i = 1;

                            foreach (Starship ship in _starships)
                            {
                                Console.Write("{0}. {1},", i, ship.ShipPower);
                                foreach( Person pers in ship.Crew)
                                {
                                    Console.Write(" {0} {1} {2},", pers.Name, pers.Nick, pers.Age);
                                }
                                i++;
                                Console.WriteLine();
                            }

                            Console.WriteLine();

                            input = Console.ReadKey();

                            if (!Char.IsNumber(input.KeyChar)) break;
                            else
                            {
                                int indeks = (int)Char.GetNumericValue(input.KeyChar);

                                Starship ship = cosmos.SendStarship(_starships.ElementAt(indeks-1), system.Name);
                                _starships.RemoveAt(indeks-1);

                                if( ship.Gold > 0 )
                                {
                                    _gold =+ ship.Gold;
                                    ship.Gold = 0;
                                }

                                if (ship.Crew.Any()) _starships.Add(ship);
                            }
                        }
                        break;

                    case ConsoleKey.D:
                        if (_anySystem)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Przegrałeś.");
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine("Wygrałeś, gratulacje!");
                        }

                        gameEnd = true;
                        break;

                    default:
                        Console.WriteLine("Nacisnąłeś zły klawisz...");
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                }

                
            } while (!gameEnd);

            Console.ReadKey();
        }
    }
}
