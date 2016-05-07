using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ObjectsManager.Interfaces.Movies;
using ObjectsManager.LiteDB.Movies;

namespace CRUDService.Movies
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        private readonly IMovieRepository _movieRepository;

        public Service1()
        {
            this._movieRepository = new MoviesRepository();
        }
        public int AddMovie(ObjectsManager.Model.Movie movie)
        {
            return this._movieRepository.Add(movie);
        }

        public ObjectsManager.Model.Movie GetMovie(int id)
        {
            return this._movieRepository.Get(id);
        }

        public List<ObjectsManager.Model.Movie> GetAllMovies()
        {
            return this._movieRepository.GetAll();
        }

        public ObjectsManager.Model.Movie UpdateMovie(ObjectsManager.Model.Movie movie)
        {
            return this._movieRepository.Update(movie);
        }

        public bool DeleteMovie(int id)
        {
            return this._movieRepository.Delete(id);
        }
    }
}
