using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using ObjectsManager.Model;
using ObjectsManager.LiteDB.ReviewPerson.Model;
using ObjectsManager.Intefaces.RevPer;

namespace ObjectsManager.LiteDB.ReviewPerson
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly string _reviewConnection = DatabaseConnections.ReviewConnection;

        public List<Review> GetAll()
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var repository = db.GetCollection<ReviewDB>("review");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public int Add(Review review)
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var dbObject = InverseMap(review);


                var repository = db.GetCollection<ReviewDB>("review");
                repository.Insert(dbObject);

                return dbObject.Id;
            }
        }

        public Review Get(int id)
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var repository = db.GetCollection<ReviewDB>("review");
                var result = repository.FindById(id);
                return Map(result);
            }
        }

        public Review Update(Review review)
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var dbObject = InverseMap(review);

                var repository = db.GetCollection<ReviewDB>("review");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._reviewConnection))
            {
                var repository = db.GetCollection<ReviewDB>("review");
                return repository.Delete(id);
            }
        }

        private Review Map(ReviewDB dbReview)
        {
            if (dbReview == null)
                return null;
            
            return new Review() { Id = dbReview.Id, Content = dbReview.Content, Score = dbReview.Score, Author = dbReview.Author, MovieId = dbReview.MovieId };
        }

        private ReviewDB InverseMap(Review review)
        {
            if (review == null)
                return null;

            return new ReviewDB()
            {
                Id = review.Id,
                Content = review.Content,
                Score = review.Score,
                Author = review.Author,
                MovieId = review.MovieId
            };
        }
    }
}
