using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Museum.Interfaces;
using Museum.Models;
using LiteDB;

namespace Museum.Repositories
{
    class ArtistsRepositoryLiteDB : IArtistsRepository
    {
        private readonly string _artistsConnection = @"D:/artists.db";

        public List<Artist> GetAll()
        {
            using (var db = new LiteDatabase(this._artistsConnection))
            {
                var repository = db.GetCollection<Artist>("artist");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public int Add(Artist artist)
        {
            using (var db = new LiteDatabase(this._artistsConnection))
            {
                var dbObject = InverseMap(artist);


                var repository = db.GetCollection<Artist>("artist");
                repository.Insert(dbObject);

                return dbObject.ID;
            }
        }

        public Artist Get(int id)
        {
            using (var db = new LiteDatabase(this._artistsConnection))
            {
                var repository = db.GetCollection<Artist>("artists");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public Artist Update(Artist artist)
        {
            using (var db = new LiteDatabase(this._artistsConnection))
            {
                var dbObject = InverseMap(artist);

                var repository = db.GetCollection<Artist>("artist");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._artistsConnection))
            {
                var repository = db.GetCollection<Artist>("artist");
                return repository.Delete(id);
            }
        }

        private Artist Map(Artist dbArtist)
        {
            if (dbArtist == null)
                return null;

            return new Artist() { ID = dbArtist.ID, ArtistName = dbArtist.ArtistName, ArtistSurname = dbArtist.ArtistSurname };
        }

        private Artist InverseMap(Artist artist)
        {
            if (artist == null)
                return null;
            return new Artist()
            {
                ID = artist.ID,
                ArtistName = artist.ArtistName,
                ArtistSurname = artist.ArtistSurname
            };
        }
    }
}