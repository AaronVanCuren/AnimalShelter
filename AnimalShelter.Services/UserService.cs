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
        private readonly string _userId;

        public UserService(string userId)
        {
            _userId = userId;
        }

        public IEnumerable<ApplicationUserListItem> GetCustomers()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Users.Where(e => e.UserType == UserType.customer)
                    .Select(e => new ApplicationUserListItem
                    {
                        FullName = e.FullName,
                        Address = e.Address,
                        PhoneNumber = e.PhoneNumber
                    });

                return query.ToArray();
            }
        }

        public IEnumerable<ApplicationUserListItem> GetCompanies()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Users.Where(e => e.UserType == UserType.company)
                    .Select(e => new ApplicationUserListItem
                    {
                        CompanyName = e.CompanyName,
                        Address = e.Address,
                        PhoneNumber = e.PhoneNumber,
                        Posts = e.Posts,
                        Ratings = e.Ratings
                    });

                return query.ToArray();
            }
        }

        public IEnumerable<ApplicationUserListItem> GetVets()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Users.Where(e => e.UserType == UserType.vet)
                    .Select(e => new ApplicationUserListItem
                    {
                        FullName = e.FullName,
                        Address = e.Address,
                        PhoneNumber = e.PhoneNumber,
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
                        .Single(e => e.UserName == userName && e.Id == _userId);
                return new ApplicationUser
                {
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

        public ApplicationUserListItem GetUserByType(UserType userType)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Users
                        .Single(e => e.UserType == userType && e.Id == _userId);
                return new ApplicationUserListItem
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
                        .Single(e => e.Email == model.Email && e.Id == _userId);

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
                        .Single(e => e.Email == email && e.Id == _userId);

                db.Users.Remove(entity);

                return db.SaveChanges() == 1;
            }
        }
    }
}