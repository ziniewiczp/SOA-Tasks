using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using CosmicAdventureDTO;

namespace Cosmos
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        private static List<SpaceSystem> _systems;

        public void InitializeGame()
        {
            _systems = new List<SpaceSystem>();

            SpaceSystem spaceSys1 = new SpaceSystem() { Name = "Space system #1" };
            SpaceSystem spaceSys2 = new SpaceSystem() { Name = "Space system #2" };
            SpaceSystem spaceSys3 = new SpaceSystem() { Name = "Space system #3" };
            SpaceSystem spaceSys4 = new SpaceSystem() { Name = "Space system #4" };

            Random rnd = new Random(DateTime.Now.Millisecond);

            spaceSys1.MinShipPower = rnd.Next(10, 40);
            spaceSys2.MinShipPower = rnd.Next(10, 40);
            spaceSys3.MinShipPower = rnd.Next(10, 40);
            spaceSys4.MinShipPower = rnd.Next(10, 40);

            spaceSys1.BaseDistance = rnd.Next(20, 120);
            spaceSys2.BaseDistance = rnd.Next(20, 120);
            spaceSys3.BaseDistance = rnd.Next(20, 120);
            spaceSys4.BaseDistance = rnd.Next(20, 120);

            spaceSys1.Gold = rnd.Next(3000, 7000);
            spaceSys2.Gold = rnd.Next(3000, 7000);
            spaceSys3.Gold = rnd.Next(3000, 7000);
            spaceSys4.Gold = rnd.Next(3000, 7000);

            _systems.Add(spaceSys1);
            _systems.Add(spaceSys2);
            _systems.Add(spaceSys3);
            _systems.Add(spaceSys4);
        }

        public Starship SendStarship(Starship starship, string systemName)
        {
            Boolean found = false;
            SpaceSystem system = new SpaceSystem();

            foreach (SpaceSystem sys in _systems)
            {
                if (sys.Name.Equals(systemName))
                {
                    system = sys;
                    found = true;
                }
            }

            if (found)
            {
                if (starship.ShipPower <= 20)
                {
                    foreach (Person pers in starship.Crew)
                    {
                        pers.Age = pers.Age + (2 * system.BaseDistance) / 12;

                        if (pers.Age > 90) starship.Crew.Remove(pers);
                    }
                }
                else if (starship.ShipPower > 20 && starship.ShipPower <= 30)
                {
                    foreach (Person pers in starship.Crew)
                    {
                        pers.Age = pers.Age + (2 * system.BaseDistance) / 6;

                        if (pers.Age > 90) starship.Crew.Remove(pers);
                    }
                }
                else if (starship.ShipPower > 30)
                {
                    foreach (Person pers in starship.Crew)
                    {
                        pers.Age = pers.Age + (2 * system.BaseDistance) / 4;

                        if (pers.Age > 90) starship.Crew.Remove(pers);
                    }
                }

                if (starship.ShipPower >= system.MinShipPower)
                {
                    starship.Gold = system.Gold;
                    _systems.Remove(system);
                }
            }
            else
            {
                foreach (Person pers in starship.Crew)
                {
                    starship.Crew.Remove(pers);
                }
            }

            return starship;
        }

        public SpaceSystem GetSystem()
        {
            return _systems.FirstOrDefault<SpaceSystem>();
        }

        public Starship GetStarship(int money)
        {
            Starship newShip = new Starship();
            newShip.Crew = new List<Person>();
            Random rnd = new Random(DateTime.Now.Millisecond);

            if (money > 1000 && money <= 3000) newShip.ShipPower = rnd.Next(10, 25);
            else if (money > 3000 && money <= 10000) newShip.ShipPower = rnd.Next(25, 35);
            else if (money > 10000) newShip.ShipPower = rnd.Next(35, 60);

            if (newShip.ShipPower < 25)
            {
                Person pers1 = new Person() { Name = "Adam", Nick = "NickAdama", Age = 20 };
                Person pers2 = new Person() { Name = "Łukasz", Nick = "NickŁukasza", Age = 20 };
                Person pers3 = new Person() { Name = "Damian", Nick = "NickDamiana", Age = 20 };
                Person pers4 = new Person() { Name = "Tomek", Nick = "NickTomka", Age = 20 };

                newShip.Crew.Add(pers1);
                newShip.Crew.Add(pers2);
                newShip.Crew.Add(pers3);
                newShip.Crew.Add(pers4);
            }
            else if( newShip.ShipPower < 35)
            {
                Person pers1 = new Person() { Name = "Marek", Nick = "NickMarka", Age = 20 };
                Person pers2 = new Person() { Name = "Sebastian", Nick = "NickSebastiana", Age = 20 };
                Person pers3 = new Person() { Name = "Ola", Nick = "NickOli", Age = 20 };
                Person pers4 = new Person() { Name = "Mateusz", Nick = "NickMateusza", Age = 20 };

                newShip.Crew.Add(pers1);
                newShip.Crew.Add(pers2);
                newShip.Crew.Add(pers3);
                newShip.Crew.Add(pers4);
            }
            else
            {
                Person pers1 = new Person() { Name = "Dawid", Nick = "NickDawid", Age = 20 };
                Person pers2 = new Person() { Name = "Borys", Nick = "NickBorysa", Age = 20 };
                Person pers3 = new Person() { Name = "Błażej", Nick = "NickBłażeja", Age = 20 };
                Person pers4 = new Person() { Name = "Piotrek", Nick = "NickPiotrka", Age = 20 };

                newShip.Crew.Add(pers1);
                newShip.Crew.Add(pers2);
                newShip.Crew.Add(pers3);
                newShip.Crew.Add(pers4);
            }

            newShip.Gold = 0;

            return newShip;
        }
    }
}
