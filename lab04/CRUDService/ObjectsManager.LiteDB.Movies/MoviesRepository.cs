using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using ObjectsManager.Model;
using ObjectsManager.LiteDB.Movies.Model;
using ObjectsManager.Interfaces.Movies;

namespace ObjectsManager.LiteDB.Movies
{
    public class MoviesRepository : IMovieRepository
    {
        private readonly string _moviesConnection = DatabaseConnections.MovieConnection;

        public List<Movie> GetAll()
        {
            using (var db = new LiteDatabase(this._moviesConnection))
            {
                var repository = db.GetCollection<MovieDB>("movie");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public int Add(Movie movie)
        {
            using (var db = new LiteDatabase(this._moviesConnection))
            {
                var dbObject = InverseMap(movie);


                var repository = db.GetCollection<MovieDB>("movie");
                repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public Movie Get(int id)
        {
            using (var db = new LiteDatabase(this._moviesConnection))
            {
                var repository = db.GetCollection<MovieDB>("movie");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public Movie Update(Movie movie)
        {
            using (var db = new LiteDatabase(this._moviesConnection))
            {
                var dbObject = InverseMap(movie);

                var repository = db.GetCollection<MovieDB>("movie");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._moviesConnection))
            {
                var repository = db.GetCollection<MovieDB>("movie");
                return repository.Delete(id);
            }
        }

        private Movie Map(MovieDB dbMovie)
        {
            if (dbMovie == null)
                return null;

            return new Movie() { Id = dbMovie.Id, Title = dbMovie.Title, ReleaseYear = dbMovie.ReleaseYear };
        }

        private MovieDB InverseMap(Movie movie)
        {
            if (movie == null)
                return null;
            return new MovieDB()
            {
                Id = movie.Id,
                Title = movie.Title,
                ReleaseYear = movie.ReleaseYear
            };
        }
    }
}
