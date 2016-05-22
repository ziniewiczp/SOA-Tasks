using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class GamesInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GamesContext>
    {
        protected override void Seed(GamesContext context)
        {
            var games = new List<Game>
            {
                new Game() {Title = "Battlefield 1", CreatorCompany = "EA", Year = 2016, AgeRate = 1},
                new Game() {Title = "DOTA2", CreatorCompany = "Valve", Year = 2013, AgeRate = 1},
                new Game() {Title = "Diablo II", CreatorCompany = "Blizzard", Year = 2000, AgeRate = 1},
                new Game() {Title = "Jagged Alliance 2", CreatorCompany = "Sir-Tech", Year = 1999, AgeRate = 1},
                new Game() {Title = "Baldur's Gate", CreatorCompany = "BioWare", Year = 1998, AgeRate = 1},

            };
            games.ForEach(i => context.Games.Add(i));
            context.SaveChanges();

            var stores = new List<Store>()
            {
                new Store() {Name = "Store1", Address = "Address1"},
                new Store() {Name = "Store2", Address = "Address2"},
                new Store() {Name = "Store3", Address = "Address3"},
                new Store() {Name = "Store4", Address = "Address4"},
                new Store() {Name = "Store5", Address = "Address5"},
            };
            stores.ForEach(g => context.Stores.Add(g));
            context.SaveChanges();

            var cardShirts = new List<CardShirt>()
            {
                new CardShirt() {Name = "Card Shirt1" },
                new CardShirt() {Name = "Card Shirt2" },
                new CardShirt() {Name = "Card Shirt3" },
                new CardShirt() {Name = "Card Shirt4" },
                new CardShirt() {Name = "Card Shirt5" },
            };
            cardShirts.ForEach(g => context.CardShirts.Add(g));
            context.SaveChanges();
        }
    }
}
