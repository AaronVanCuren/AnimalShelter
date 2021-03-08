using AnimalShelter.Data;
using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class AnimalServices
    {
        private readonly Guid _userId;

        public AnimalServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateAnimal(DogCreate dog)
        {
            var entity = new Dog()
            {
                Name = dog.Name,
                Species = dog.Species,
                Breed = dog.Breed,
                Sex = dog.Sex,
                Fixed = dog.Fixed,
                HasShots = dog.HasShots,
                Age = dog.Age,
                Description = dog.Description,
                AdoptionPrice = dog.AdoptionPrice,
                IsHouseTrained = dog.IsHouseTrained
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Animals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool CreateAnimal(CatCreate cat)
        {
            var entity = new Cat()
            {
                Name = cat.Name,
                Species = cat.Species,
                Breed = cat.Breed,
                Sex = cat.Sex,
                Fixed = cat.Fixed,
                HasShots = cat.HasShots,
                Age = cat.Age,
                Description = cat.Description,
                AdoptionPrice = cat.AdoptionPrice,
                IsDeclawed = cat.IsDeclawed
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Animals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool CreateAnimal(BunnyCreate bunny)
        {
            var entity = new Bunny()
            {
                Name = bunny.Name,
                Species = bunny.Species,
                Breed = bunny.Breed,
                Sex = bunny.Sex,
                Fixed = bunny.Fixed,
                HasShots = bunny.HasShots,
                Age = bunny.Age,
                Description = bunny.Description,
                AdoptionPrice = bunny.AdoptionPrice,
                IsEdible = bunny.IsEdible
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Animals.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<AnimalRUD> GetAnimals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Animals
                        .Where(e => e.User == _userId)
                        .Select(
                            e => new AnimalRUD
                            {
                                AnimalId = e.AnimalId,
                                Species = e.Species,
                            });

                return query.ToArray();
            }
        }
        public IEnumerable<AnimalRUD> GetAnimalsByCompanyId(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Animals
                    .Where(e => e.Company.CompanyId == id && e.User == _userId)
                    .Select(
                    e =>
                    new AnimalRUD
                    {
                        AnimalId = e.AnimalId,
                        Species = e.Species
                    }
                    );

                return entity.ToArray();
            }
        }
        
    }
}
