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
        private readonly int _profileId;

        public PostServices(Guid userId, UserType userType, int profileId)
        {
            _userId = userId;
            _userType = userType;
            _profileId = profileId;
        }
        public bool CreatePost(PostCreate model)
        {
            if (_userType == UserType.company)
            {
                var entity = new Post()
                {
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


                                    })

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
                    AnimalId = entity.AnimalId
                };
            }
        }

        public bool UpdatePost(PostRUD model)
        {
            UserService companyType = new UserService(_userId);
            UserService companyId = new UserService(_userId);

            var type = companyType.GetUserByType(_userType);
            var id = companyId.GetUserByProfileId(_profileId);

            if (type.UserType == UserType.company && id.ProfileId == _profileId)
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
            UserService companyType = new UserService(_userId);
            UserService companyId = new UserService(_userId);

            var type = companyType.GetUserByType(_userType);
            var id = companyId.GetUserByProfileId(_profileId);

            if (type.UserType == UserType.company && id.ProfileId == _profileId)
            {
                using (var db = new ApplicationDbContext())
                {
                    var entity = db.Posts
                            .Single(e => e.PostId == postId && e.UserId == _userId);

                    db.Posts.Remove(entity);

                    return db.SaveChanges() == 1;
                }
            }
            else
            {
                Console.WriteLine("Would you like to make a company account?");
            }
            return false;
        }
    }
}