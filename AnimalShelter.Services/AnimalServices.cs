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
        public bool CreateAnimal(AnimalCreate animal)
        {
            var entity = new Animal()
            {
                Species = animal.Species,
            };


            int species = (int)animal.Species;
            switch (species)
            {
                case 0:
                    var dog = new DogCreate();
                    CreateDog(dog);
                    break;
                case 1:
                    var cat = new CatCreate();
                    CreateCat(cat);
                    break;
                case 2:
                    var bunny = new BunnyCreate();
                    CreateBunny(bunny);
                    break;
            }
            return default;
        }
        public bool CreateDog(DogCreate dog)
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
        public bool CreateCat(CatCreate cat)
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
        public bool CreateBunny(BunnyCreate bunny)
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
                        .Select(
                            e => new AnimalRUD
                            {
                                AnimalId = e.AnimalId,
                                Species = e.Species,
                            });

                return query.ToArray();
            }
        }
        public bool DeleteAnimal(int animalId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Animals
                        .Single(e => e.AnimalId == animalId);

                ctx.Animals.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
