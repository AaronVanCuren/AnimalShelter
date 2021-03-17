using AnimalShelter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class CommentService
    {
        private readonly string _userId;

        public CommentService(string userId)
        {
            _userId = userId;
        }

        public bool CreateComment(CommentCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                bool isValid = int.TryParse(model.PostId, out int id);
                if (!isValid)
                {
                    id = 0;
                }
                var entity = new Comment()
                {
                    Author = _userId,
                    Content = model.Content,
                    PostId = id,
                };
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentRUD> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.Author == _userId)
                        .Select(
                            e =>
                                new CommentRUD
                                {
                                    PostId = e.PostId,
                                    Content = e.Content,
                                    CommentId = e.CommentId
                                }
                        );

                return query.ToArray();

            }
        }

        public IEnumerable<CommentRUD> GetCommentByPostId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Comments
                    .Where(e => e.PostId == id && e.Author == _userId)
                    .Select(
                    e =>
                    new CommentRUD
                    {
                        Content = e.Content
                    }
                    );

                return entity.ToArray();
            }
        }

        public bool UpdateComment(CommentRUD model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Comments
                        .Single(e => e.CommentId == model.CommentId && e.Author == _userId);

                entity.Content = model.Content;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Comments
                        .Single(e => e.CommentId == commentId && e.Author == _userId);

                ctx.Comments.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
