using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Museum.Models;

namespace Museum.DAL
{
    class MuseumInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MuseumContext>
    {
        protected override void Seed(MuseumContext context)
        {
            var paintings = new List<Painting>
            {
                new Painting() {Title = "Dama z łasiczką", Year = 1490},
                new Painting() {Title = "Mona Lisa", Year = 1517}

            };
            paintings.ForEach(i => context.Paintings.Add(i));
            context.SaveChanges();

            var artists = new List<Artist>()
            {
                new Artist() {ArtistName = "Leonardo", ArtistSurname = "DaVinci"},
                new Artist() {ArtistName = "Vincent", ArtistSurname = "van Gogh"}
            };
            artists.ForEach(g => context.Artists.Add(g));
            context.SaveChanges();
        }
    }
}