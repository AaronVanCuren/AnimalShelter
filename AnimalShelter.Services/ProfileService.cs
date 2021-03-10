using AnimalShelter.Data;
using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class ProfileService
    {
        private readonly Guid _userId;

        public ProfileService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProfile(ProfileCreate model)
        {
            var entity = new Profile()
            {
                UserId = _userId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Address = model.Address
            };

            using (var db = new ApplicationDbContext())
            {
                db.Profiles.Add(entity);
                return db.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProfileRUD> GetProfiles()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Profiles
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e => new ProfileRUD
                            {
                                ProfileId = e.ProfileId,
                                FirstName = e.FirstName,
                                LastName = e.LastName,
                                Address = e.Address
                            });

                return query.ToArray();
            }
        }

        public ProfileRUD GetProfileById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Profiles
                        .Single(e => e.ProfileId == id && e.UserId == _userId);
                return new ProfileRUD
                    {
                        ProfileId = entity.ProfileId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Address = entity.Address
                    };
            }
        }

        public bool UpdateProfile(ProfileRUD model)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Profiles
                        .Single(e => e.ProfileId == model.ProfileId && e.UserId == _userId);

                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Address = model.Address;

                return db.SaveChanges() == 1;
            }
        }

        public bool DeleteProfile(int profileId)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Profiles
                        .Single(e => e.ProfileId == profileId && e.UserId == _userId);

                db.Profiles.Remove(entity);

                return db.SaveChanges() == 1;
            }
        }
    }
}