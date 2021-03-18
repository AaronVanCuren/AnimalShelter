using AnimalShelter.Data;
using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class UserRatingService
    {
        public bool CreateUserRating(UserRatingCreate model)
        {

            if (model.UserType == UserType.customer)
            {
                var entity = new UserRating()
                {
                    Id = model.UserId,
                    AdoptingProcessScore = model.AdoptingProcessScore,
                    FriendlinessScore = model.FriendlinessScore
                };
                using (var db = new ApplicationDbContext())
                {
                    db.Ratings.Add(entity);
                    return db.SaveChanges() == 1;
                }
            }
            else
            {
                Console.WriteLine("Would you like to make a customer account?");
            }
            return false;
        }

        public IEnumerable<UserRatingListItem> GetUserRatings()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Ratings
                        .Select(
                            e => new UserRatingListItem
                            {
                                RatingId = e.RatingId,
                                CompanyName = e.ApplicationUser.CompanyName,
                                AverageRating = e.AverageRating
                            });

                return query.ToArray();
            }
        }

        public UserRatingListItem GetUserRatingById(string id)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Ratings
                        .Single(e => e.Id == id);
                return
                    new UserRatingListItem
                    {
                        RatingId = entity.RatingId,
                        CompanyName = entity.ApplicationUser.CompanyName,
                        AverageRating = entity.AverageRating
                    };
            }
        }
    }
}
