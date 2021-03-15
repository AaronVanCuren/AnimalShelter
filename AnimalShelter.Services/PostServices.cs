using AnimalShelter.Data;
using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class PostServices
    {
        private readonly Guid _userId;
        private readonly UserType _userType;

        public PostServices(Guid userId, UserType userType)
        {
            _userId = userId;
            _userType = userType;
        }
        public bool CreatePost(PostCreate model)
        {
            UserService companyService = new UserService(_userId);

            //UserType userType = _userType;

            var c = companyService.GetUserByType(_userType);

            if (c.UserType == UserType.company)
            {
                var entity = new Post()
                {
                    ProfileId = model.ProfileId,
                    AnimalId = model.AnimalId
                };

                using (var db = new ApplicationDbContext())
                {
                    db.Posts.Add(entity);
                    return db.SaveChanges() == 1;
                }
            }
            else
            {
                Console.WriteLine("Would you like to make a company account?");
            }
            return false;

        }

        public IEnumerable<PostRUD> GetPosts()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Posts
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e => new PostRUD
                            {
                                PostId = e.PostId,
                                ProfileId = e.ProfileId,
                                AnimalId = e.AnimalId,
                                Name = e.Name,
                                Species = e.Species,
                                Breed = e.Breed,
                                Sex = e.Sex,
                                Fixed = e.Fixed,
                                HasShots = e.HasShots,
                                Age = e.Age,
                                Description = e.Description,
                                AdoptionPrice = e.AdoptionPrice,
                                IsHouseTrained = e.IsHouseTrained,
                                IsDeclawed = e.IsDeclawed,
                                IsEdible = e.IsEdible
                            });

                return query.ToArray();
            }
        }

        public PostRUD GetPostById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Posts
                        .Single(e => e.PostId == id);
                return new PostRUD
                {
                    PostId = entity.PostId,
                    ProfileId = entity.ProfileId,
                    AnimalId = entity.AnimalId,
                    Name = entity.Name,
                    Species = entity.Species,
                    Breed = entity.Breed,
                    Sex = entity.Sex,
                    Fixed = entity.Fixed,
                    HasShots = entity.HasShots,
                    Age = entity.Age,
                    Description = entity.Description,
                    AdoptionPrice = entity.AdoptionPrice,
                    IsHouseTrained = entity.IsHouseTrained,
                    IsDeclawed = entity.IsDeclawed,
                    IsEdible = entity.IsEdible
                };
            }
        }

        public bool UpdatePost(PostRUD model)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Posts
                        .Single(e => e.PostId == model.PostId && e.UserId == _userId);
                // Need property of animals that are editable
                entity.ProfileId = model.ProfileId;
                entity.AnimalId = model.AnimalId;

                return db.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int postId)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Posts
                        .Single(e => e.PostId == postId && e.UserId == _userId);

                db.Posts.Remove(entity);

                return db.SaveChanges() == 1;
            }
        }
    }
}