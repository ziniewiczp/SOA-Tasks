using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Museum.Interfaces;
using Museum.Models;
using Museum.DAL;

namespace Museum.Repositories
{
    class PaintingsRepositoryPostgreSQL : IPaintingsRepository
    {
        private MuseumContext db = new MuseumContext();

        public int Add(Painting painting)
        {
            db.Paintings.Add(painting);
            db.SaveChanges();

            return painting.ID;
        }

        public bool Delete(int id)
        {
            Painting painting = db.Paintings.Find(id);
            if (painting == null)
            {
                return false;
            }
            db.Paintings.Remove(painting);
            db.SaveChanges();
            return true;
        }

        public Painting Get(int id)
        {
            Painting painting = db.Paintings.Find(id);
            if (painting == null)
            {
                return null;
            }
            return painting;
        }

        public List<Painting> GetAll()
        {
            List<Painting> paintings = db.Paintings.ToList();
            if (!paintings.Any())
                return null;
            return paintings;
        }

        public Painting Update(Painting painting)
        {
            Painting p = db.Paintings.Find(painting.ID);
            if (p == null)
                return null;
            p.Title = painting.Title;
            p.Year = painting.Year;
            db.SaveChanges();
            return painting;
        }
    }
}