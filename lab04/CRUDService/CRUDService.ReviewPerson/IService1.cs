using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ObjectsManager.Model;

namespace CRUDService.ReviewPerson
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        int AddReview(Review review);

        [OperationContract]
        Review GetReview(int id);

        [OperationContract]
        List<Review> GetAllReviews();

        [OperationContract]
        Review UpdateReview(Review review);

        [OperationContract]
        bool DeleteReview(int id);


        [OperationContract]
        int AddPerson(Person person);

        [OperationContract]
        Person GetPerson(int id);

        [OperationContract]
        List<Person> GetAllPersons();

        [OperationContract]
        Person UpdatePerson(Person person);
    }
}
