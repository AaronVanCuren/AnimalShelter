using AnimalShelter.Data;
using AnimalShelter.Models;
using System.Collections.Generic;
using System.Linq;

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
                        Email = e.Email,
                        PhoneNumber = e.PhoneNumber,
                        Address = e.Address,
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
                        Email = e.Email,
                        PhoneNumber = e.PhoneNumber,
                        Address = e.Address,
                        Posts = e.Posts,

                        //Check with Andrew
                        //AverageRating = e.AverageRating
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
                        Email = e.Email,
                        PhoneNumber = e.PhoneNumber,
                        Address = e.Address,
                        Vaccines = e.Vaccines,
                    });

                return query.ToArray();
            }
        }

        public ApplicationUserListItem GetUserByEmail(string email)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Users
                        .Single(e => e.Email == email);
                    return new ApplicationUserListItem
                    {
                        Id = entity.Id,
                        UserName = entity.UserName,
                        CompanyName = entity.CompanyName,
                        FullName = entity.FullName,
                        PhoneNumber = entity.PhoneNumber,
                        Address = entity.Address,
                        AverageRating = entity.AverageRating,
                        Vaccines = entity.Vaccines
                    };
            }
        }

        public ApplicationUserListItem GetUserByType()
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Users
                        .Single(e => e.Id == _userId);
                return new ApplicationUserListItem
                {
                    UserType = entity.UserType
                };
            }
        }

        public bool UpdateUser(UserUpdate model)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Users
                        .Single(e => e.Id == model.Id);
                if (model.UserType == UserType.customer)
                {
                    {
                        entity.UserName = model.UserName;
                        entity.FullName = model.FullName;
                        entity.Email = model.Email;
                        entity.PhoneNumber = model.PhoneNumber;
                        entity.Address = model.Address;
                    };
                }
                else if (model.UserType == UserType.company)
                {
                    {
                        entity.UserName = model.UserName;
                        entity.CompanyName = model.CompanyName;
                        entity.Email = model.Email;
                        entity.PhoneNumber = model.PhoneNumber;
                        entity.Address = model.Address;
                    };
                }
                else if (model.UserType == UserType.vet)
                {
                    {
                        entity.UserName = model.UserName;
                        entity.FullName = model.FullName;
                        entity.Email = model.Email;
                        entity.PhoneNumber = model.PhoneNumber;
                        entity.Address = model.Address;
                    };
                }

                return db.SaveChanges() == 1;
            }
        }

        public bool DeleteUser(string email)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Users
                        .Single(e => e.Email == email);

                db.Users.Remove(entity);

                return db.SaveChanges() == 1;
            }
        }
    }
}