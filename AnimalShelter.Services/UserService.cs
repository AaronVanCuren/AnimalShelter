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
        private readonly Guid _userId;

        public UserService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<ApplicationUser> GetCustomers()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Users.Where(e => e.UserType == UserType.customer)
                    .Select(e => new ApplicationUser
                    {
                        ProfileId = e.ProfileId,
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
                        ProfileId = e.ProfileId,
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
                        ProfileId = e.ProfileId,
                        UserName = e.UserName,
                        FullName = e.FullName,
                        Address = e.Address,
                        Vaccines = e.Vaccines
                    });

                return query.ToArray();
            }
        }

        public ApplicationUser GetUserByUserName(string userName)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Users
                        .Single(e => e.UserName == userName && e.UserId == _userId);
                return new ApplicationUser
                {
                    ProfileId = entity.ProfileId,
                    UserName = entity.UserName,
                    FullName = entity.FullName,
                    CompanyName = entity.CompanyName,
                    PhoneNumber = entity.PhoneNumber,
                    Address = entity.Address,
                    Ratings = entity.Ratings,
                    Vaccines = entity.Vaccines
                };
            }
        }

        public ApplicationUser GetUserByProfileId(int profileId)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Users
                        .Single(e => e.ProfileId == profileId && e.UserId == _userId);
                return new ApplicationUser
                {
                    ProfileId = entity.ProfileId,
                };
            }
        }

        public ApplicationUser GetUserByType(UserType userType)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Users
                        .Single(e => e.UserType == userType && e.UserId == _userId);
                return new ApplicationUser
                {
                    UserType = entity.UserType
                };
            }
        }

        public bool UpdateUser(RegisterBindingModel model)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Users
                        .Single(e => e.Email == model.Email && e.UserId == _userId);

                entity.UserName = model.UserName;
                entity.Email = model.Email;
                entity.FullName = model.FullName;
                entity.CompanyName = model.CompanyName;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Address = model.Address;

                return db.SaveChanges() == 1;
            }
        }

        public bool DeleteUser(string email)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Users
                        .Single(e => e.Email == email && e.UserId == _userId);

                db.Users.Remove(entity);

                return db.SaveChanges() == 1;
            }
        }
    }
}