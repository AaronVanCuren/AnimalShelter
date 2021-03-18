using AnimalShelter.Data;
using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class AdoptService
    {
        private readonly string _userId;

        public AdoptService(string userId)
        {
            _userId = userId;
        }

        public bool CreateAdoption(AdoptCreate model)
        {
            if (model.UserType == UserType.customer)
            {
                var entity = new Adoption()
                {
                    PostId = model.PostId,
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Adoptions.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
            else
            {
                Console.WriteLine("Would you like to make a customer account?");
            }
            return false;
        }



        public IEnumerable<AdoptionListItem> GetAdoptions()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Adoptions
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e => new AdoptionListItem
                            {
                                AdoptionId = e.AdoptionId,
                                PostId = db.Posts
                                    .Where(a => a.PostId == e.PostId)
                                    .Select(
                                    a => new PostListItem
                                    {
                                        PostId = a.PostId,
                                        AnimalId = db.Animals
                                        .Where(b => b.AnimalId == a.AnimalId)
                                        .Select(
                                        b => new AnimalRUD
                                        {
                                            AnimalId = b.AnimalId,
                                            Name = b.Name,
                                            Species = b.Species,
                                            Breed = b.Breed,
                                            Sex = b.Sex,
                                            Fixed = b.Fixed,
                                            Vaccines = b.Vaccines,
                                            Age = b.Age,
                                            Description = b.Description,
                                            AdoptionPrice = b.AdoptionPrice,
                                            IsHouseTrained = b.IsHouseTrained,
                                            IsDeclawed = b.IsDeclawed,
                                            IsEdible = b.IsEdible,
                                        })
                                    })
                            });

                return query.ToArray();
            }
        }

        public AdoptionRUD GetAdoptionById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Adoptions
                        .Single(e => e.AdoptionId == id && e.UserId == _userId);
                return
                    new AdoptionRUD
                    {
                        AdoptionId = entity.AdoptionId,
                        PostId = entity.PostId
                    };
            }
        }

        public bool UpdateAdoption(AdoptionRUD model)
        {
            if (model.UserType == UserType.customer)
                using (var db = new ApplicationDbContext())
                {
                    var entity = db.Adoptions
                            .Single(e => e.AdoptionId == model.AdoptionId && e.UserId == _userId);

                    entity.PostId = model.PostId;

                    return db.SaveChanges() == 1;
                }
            else
            {
                Console.WriteLine("Would you like to make a customer account?");
            }
            return false;
        }

        public bool DeleteAdoption(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Adoptions
                        .Single(e => e.AdoptionId == id && e.UserId == _userId);

                db.Adoptions.Remove(entity);

                return db.SaveChanges() == 1;
            }
        }
    }
}
