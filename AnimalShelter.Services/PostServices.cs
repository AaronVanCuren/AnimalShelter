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
        private readonly int _userId;

        public PostServices(int companyId)
        {
            _userId = companyId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity = new Post()
            {
                AnimalId = model.AnimalId,
                CompanyId = model.CompanyId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostRUD> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Posts
                        .Where(e => e.CompanyId == _userId)
                        .Select(
                            e => new PostRUD
                            {
                                PostId = e.PostId,
                            });

                return query.ToArray();
            }
        }

        public PostRUD GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts
                        .Single(e => e.PostId == id && e.CompanyId == _userId);
                return
                    new PostRUD
                    {
                        PostId = entity.PostId,
                    };
            }
        }

        public bool UpdatePost(PostRUD model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts
                        .Single(e => e.PostId == model.PostId && e.CompanyId == _userId);

                entity.AnimalId = model.AnimalId;
                entity.CompanyId = model.CompanyId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts
                        .Single(e => e.PostId == postId && e.CompanyId == _userId);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
