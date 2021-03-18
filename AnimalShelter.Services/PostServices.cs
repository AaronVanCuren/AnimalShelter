using AnimalShelter.Data;
using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Services
{
    public class PostServices
    {
        private readonly string _userId;

        public PostServices(string userId)
        {
            _userId = userId;
        }
        public bool CreatePost(PostCreate model)
        {
            if (model.UserType == UserType.company)
            {
                var entity = new Post()
                {
                    UserId = _userId,
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

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Posts
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e => new PostListItem
                            {
                                PostId = e.PostId,
                                AnimalId = db.Animals
                                    .Where(a => a.AnimalId == e.AnimalId)
                                    .Select(
                                    a => new AnimalRUD
                                    {
                                        AnimalId = a.AnimalId,
                                        Name = a.Name,
                                        Species = a.Species,
                                        Breed = a.Breed,
                                        Sex = a.Sex,
                                        Fixed = a.Fixed,
                                        Vaccines = a.Vaccines,
                                        Age = a.Age,
                                        Description = a.Description,
                                        AdoptionPrice = a.AdoptionPrice,
                                        IsHouseTrained = a.IsHouseTrained,
                                        IsDeclawed = a.IsDeclawed,
                                        IsEdible = a.IsEdible
                                    })
                            });

                return query.ToArray();
            }

        }


        public PostListItem GetPostById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Posts
                        .Single(e => e.PostId == id);
                return new PostListItem
                {
                    PostId = entity.PostId,
                    AnimalId = db.Animals
                        .Where(a => a.AnimalId == entity.AnimalId)
                        .Select(
                        a => new AnimalRUD
                        {
                            AnimalId = a.AnimalId,
                            Name = a.Name,
                            Species = a.Species,
                            Breed = a.Breed,
                            Sex = a.Sex,
                            Fixed = a.Fixed,
                            Vaccines = a.Vaccines,
                            Age = a.Age,
                            Description = a.Description,
                            AdoptionPrice = a.AdoptionPrice,
                            IsHouseTrained = a.IsHouseTrained,
                            IsDeclawed = a.IsDeclawed,
                            IsEdible = a.IsEdible
                        })
                };
            }
        }

        public bool UpdatePost(PostRUD model)
        {
            if (model.UserType == UserType.company)
            {
                using (var db = new ApplicationDbContext())
                {
                    var entity = db.Posts
                            .Single(e => e.PostId == model.PostId && e.UserId == _userId);
                    // Need property of animals that are editable
                    entity.AnimalId = model.AnimalId;

                    return db.SaveChanges() == 1;
                }
            }
            else
            {
                Console.WriteLine("Would you like to make a company account?");
            }
            return false;
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