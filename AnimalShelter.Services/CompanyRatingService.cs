using AnimalShelter.Data;
using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class CompanyRatingService
    {
        private readonly Guid _userId;

        public CompanyRatingService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCompanyRating(CompanyRatingCreate model)
        {
            var entity = new CompanyRating()
            {
                CompanyId = model.CompanyId,
                AdoptingProcessScore = model.AdoptingProcessScore,
                FriendlinessScore = model.FriendlinessScore
            };

            using (var db = new ApplicationDbContext())
            {
                db.Ratings.Add(entity);
                return db.SaveChanges() == 1;
            }
        }

        public IEnumerable<CompanyRatingListItem> GetCompanyRatings()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Ratings
                        .Select(
                            e => new CompanyRatingListItem
                            {
                                RatingId = e.RatingId,
                                CompanyId = e.CompanyId,
                                CompanyName = e.Company.Name,
                                AverageScore = e.AverageScore
                            });

                return query.ToArray();
            }
        }

        public CompanyRatingListItem GetCompanyRatingByCompanyId(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Ratings
                        .Single(e => e.CompanyId == id);
                        return
                            new CompanyRatingListItem
                            {
                                RatingId = entity.RatingId,
                                CompanyId = entity.CompanyId,
                                CompanyName = entity.Company.Name,
                                AverageScore = entity.AverageScore
                            };
            }
        }
    }
}
