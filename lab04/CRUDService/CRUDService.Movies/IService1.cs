using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ObjectsManager.Model;

namespace CRUDService.Movies
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        int AddMovie(Movie movie);

        [OperationContract]
        Movie GetMovie(int id);

        [OperationContract]
        List<Movie> GetAllMovies();

        [OperationContract]
        Movie UpdateMovie(Movie movie);

        [OperationContract]
        bool DeleteMovie(int id);
    }
}
