using AnimalShelter.Data;
using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class UserService
    {
        public IEnumerable<ApplicationUser> GetCustomers()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Users.Where(e => e.UserType == UserType.customer)
                    .Select(e => new ApplicationUser
                    {
                        UserName = e.UserName,
                        FullName = e.FullName,
                        Address = e.Address
                    });

                return query.ToArray();
            }
        }

        public IEnumerable<ApplicationUser> GetCompanies()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Users.Where(e => e.UserType == UserType.company)
                    .Select(e => new ApplicationUser
                    {
                        UserName = e.UserName,
                        CompanyName = e.CompanyName,
                        Address = e.Address,
                        Posts = e.Posts,
                        Ratings = e.Ratings
                    });

                return query.ToArray();
            }
        }

        public IEnumerable<ApplicationUser> GetVets()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Users.Where(e => e.UserType == UserType.vet)
                    .Select(e => new ApplicationUser
                    {
                        UserName = e.UserName,
                        FullName = e.FullName,
                        Address = e.Address,
                        Vaccines = e.Vaccines
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