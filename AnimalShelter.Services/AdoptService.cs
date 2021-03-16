using AnimalShelter.Data;
using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class AdoptService
    {
        private readonly Guid _userId;
        private readonly UserType _userType;

        public AdoptService(Guid userId, UserType userType)
        {
            _userId = userId;
            _userType = userType;
        }

        public bool CreateAdoption(AdoptCreate model)
        {
            UserService customerService = new UserService(_userId);
            var c = customerService.GetUserByType(_userType);
            if (c.UserType == UserType.customer)
            {
                var entity = new Adoption()
                {
                    PostId = model.PostId,
                    ProfileId = model.ProfileId
                };

                using (var ctx = new ApplicationDbContext())
                {
                    ctx.Adoptions.Add(entity);
                    return ctx.SaveChanges() == 1;
                }
            }
            else
            {
                Console.WriteLine("Would you like to make a customer account?");
            }
            return false;
        }



        public IEnumerable<AdoptionRUD> GetAdoptions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Adoptions
                        .Where(e => e.UserId == _userId)
                        .Select(
                            e => new AdoptionRUD
                            {
                                AdoptionId = e.AdoptionId,
                                PostId = e.PostId,
                                ProfileId = e.ProfileId,

                            });

                return query.ToArray();
            }
        }

        public AdoptionRUD GetAdoptionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Adoptions
                        .Single(e => e.AdoptionId == id && e.UserId == _userId);
                return
                    new AdoptionRUD
                    {
                        AdoptionId = entity.AdoptionId,
                    };
            }
        }

        public bool UpdateAdoption(AdoptionRUD model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Adoptions
                        .Single(e => e.AdoptionId == model.AdoptionId && e.UserId == _userId);

                entity.ProfileId = model.ProfileId;
                entity.PostId = model.PostId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteAdoption(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Adoptions
                        .Single(e => e.AdoptionId == id && e.UserId == _userId);

                ctx.Adoptions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
