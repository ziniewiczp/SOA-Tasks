using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ObjectsManager.LiteDB.ReviewPerson;
using ObjectsManager.Intefaces.RevPer;

namespace CRUDService.ReviewPerson
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        private readonly IPersonRepository _personRepository;
        private readonly IReviewRepository _reviewRepository;

        public Service1()
        {
            this._personRepository = new PersonRepository();
            this._reviewRepository = new ReviewRepository();
        }
        public int AddReview(ObjectsManager.Model.Review review)
        {
            return this._reviewRepository.Add(review);
        }

        public ObjectsManager.Model.Review GetReview(int id)
        {
            return this._reviewRepository.Get(id);
        }

        public List<ObjectsManager.Model.Review> GetAllReviews()
        {
            return this._reviewRepository.GetAll();
        }

        public ObjectsManager.Model.Review UpdateReview(ObjectsManager.Model.Review review)
        {
            return this._reviewRepository.Update(review);
        }

        public bool DeleteReview(int id)
        {
            return this._reviewRepository.Delete(id);
        }

        public int AddPerson(ObjectsManager.Model.Person person)
        {
            return this._personRepository.Add(person);
        }

        public ObjectsManager.Model.Person GetPerson(int id)
        {
            return this._personRepository.Get(id);
        }

        public List<ObjectsManager.Model.Person> GetAllPersons()
        {
            return this._personRepository.GetAll();
        }

        public ObjectsManager.Model.Person UpdatePerson(ObjectsManager.Model.Person person)
        {
            return this._personRepository.Update(person);
        }
    }
}
