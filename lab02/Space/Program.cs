using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Space
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri address = new Uri("http://localhost:9009/Space");

            ServiceHost selfHost = new ServiceHost(typeof(BlackHole), address);

            try
            {
                selfHost.AddServiceEndpoint(typeof(IBlackHole), new WSHttpBinding(), "SpaceServiceEndpoint");

                ServiceMetadataBehavior smd = new ServiceMetadataBehavior();
                smd.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smd);

                selfHost.Open();
                Console.WriteLine("Service is running!");
                Console.ReadLine();
                selfHost.Close();
            }

            catch (CommunicationException ex)
            {
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                selfHost.Abort();
            }
        }
    }

    public class Person
    {
        public string Name;
        public int Age;
    }

    public class Starship
    {
        public string Name;
        public Person Captain;
        public List<Person> Crew;
    }

    public class Planet
    {
        public string Name;
        public int Mass;
    }

    [ServiceContract]
    public interface IBlackHole
    {
        [OperationContract]
        Starship PullStarship(Starship ship);

        [OperationContract]
        string UltimateAnswer();
    }

    public class BlackHole : IBlackHole
    {
        public Starship PullStarship(Starship ship)
        {
            if( ship.Captain.Age < 40 )
            {
                foreach(Person pers in ship.Crew)
                {
                    pers.Age = pers.Age + 20;
                }
            }

            return ship;
        }

        public string UltimateAnswer()
        {
            return 42.ToString();
        }
    }
}
