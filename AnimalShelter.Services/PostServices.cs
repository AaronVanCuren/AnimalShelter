using AnimalShelter.Data;
using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class PostServices
    {
        private readonly Guid _userId;

        public PostServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity = new Post()
            {
                AnimalId = model.AnimalId,
                CompanyId = model.CompanyId
            };

            using (var db = new ApplicationDbContext())
            {
                db.Posts.Add(entity);
                return db.SaveChanges() == 1;
            }
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
                                AnimalId = e.AnimalId,
                                CompanyId = e.CompanyId
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
                        AnimalId = entity.AnimalId,
                        CompanyId = entity.CompanyId
                };
            }
        }

        public bool UpdatePost(PostRUD model)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Posts
                        .Single(e => e.PostId == model.PostId && e.UserId == _userId);

                entity.AnimalId = model.AnimalId;
                entity.CompanyId = model.CompanyId;

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