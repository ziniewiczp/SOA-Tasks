using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Museum.Interfaces;
using Museum.Models;
using LiteDB;

namespace Museum.Repositories
{
    class PaintingsRepositoryLiteDB : IPaintingsRepository
    {
        private readonly string _paintingsConnection = @"D:/paintings.db";

        public List<Painting> GetAll()
        {
            using (var db = new LiteDatabase(this._paintingsConnection))
            {
                var repository = db.GetCollection<Painting>("painting");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public int Add(Painting painting)
        {
            using (var db = new LiteDatabase(this._paintingsConnection))
            {
                var dbObject = InverseMap(painting);

                var repository = db.GetCollection<Painting>("painting");
                repository.Insert(dbObject);

                return dbObject.ID;
            }
        }

        public Painting Get(int id)
        {
            using (var db = new LiteDatabase(this._paintingsConnection))
            {
                var repository = db.GetCollection<Painting>("painting");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public Painting Update(Painting painting)
        {
            using (var db = new LiteDatabase(this._paintingsConnection))
            {
                var dbObject = InverseMap(painting);

                var repository = db.GetCollection<Painting>("painting");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._paintingsConnection))
            {
                var repository = db.GetCollection<Painting>("painting");
                return repository.Delete(id);
            }
        }

        private Painting Map(Painting dbPainting)
        {
            if (dbPainting == null)
                return null;

            return new Painting() { ID = dbPainting.ID, Title = dbPainting.Title, Year = dbPainting.Year };
        }

        private Painting InverseMap(Painting painting)
        {
            if (painting == null)
                return null;
            return new Painting()
            {
                ID = painting.ID,
                Title = painting.Title,
                Year = painting.Year
            };
        }
    }
}