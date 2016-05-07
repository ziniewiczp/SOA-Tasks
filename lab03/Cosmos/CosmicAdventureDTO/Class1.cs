using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CosmicAdventureDTO
{
    [DataContract]
    public class SpaceSystem
    {
        [DataMember]
        public string Name;

        public int MinShipPower;

        [DataMember]
        public int BaseDistance;

        public int Gold;
    }

    [DataContract]
    public class Starship
    {
        [DataMember]
        public List<Person> Crew;

        [DataMember]
        public int Gold;

        [DataMember]
        public int ShipPower;
    }

    [DataContract]
    public class Person
    {
        [DataMember]
        public string Name;

        [DataMember]
        public string Nick;

        [DataMember]
        public float Age;
    }
}