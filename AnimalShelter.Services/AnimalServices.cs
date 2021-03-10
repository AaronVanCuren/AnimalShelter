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
                Name = animal.Name,
                Species = animal.Species,
                Breed = animal.Breed,
                Sex = animal.Sex,
                Fixed = animal.Fixed,
                HasShots = animal.HasShots,
                Age = animal.Age,
                Description = animal.Description,
                AdoptionPrice = animal.AdoptionPrice,
                IsHouseTrained = animal.IsHouseTrained,
                IsDeclawed = animal.IsDeclawed,
                IsEdible = animal.IsEdible
            };
            using (var db = new ApplicationDbContext())
            {
                db.Animals.Add(entity);
                return db.SaveChanges() == 1;
            }
        }

        public IEnumerable<AnimalRUD> GetAnimals()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Animals
                        .Select(
                            e => new AnimalRUD
                            {
                                AnimalId = e.AnimalId,
                                Name = e.Name,
                                Species = e.Species,
                                Breed = e.Breed,
                                Sex = e.Sex,
                                Fixed = e.Fixed,
                                HasShots = e.HasShots,
                                Age = e.Age,
                                Description = e.Description,
                                AdoptionPrice = e.AdoptionPrice,
                                IsHouseTrained = e.IsHouseTrained,
                                IsDeclawed = e.IsDeclawed,
                                IsEdible = e.IsEdible
                            });

                return query.ToArray();
            }
        }

        public AnimalRUD GetAnimalById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Animals
                        .Single(e => e.AnimalId == id);
                return new AnimalRUD
                {
                    AnimalId = entity.AnimalId,
                    Name = entity.Name,
                    Species = entity.Species,
                    Breed = entity.Breed,
                    Sex = entity.Sex,
                    Fixed = entity.Fixed,
                    HasShots = entity.HasShots,
                    Age = entity.Age,
                    Description = entity.Description,
                    AdoptionPrice = entity.AdoptionPrice,
                    IsHouseTrained = entity.IsHouseTrained,
                    IsDeclawed = entity.IsDeclawed,
                    IsEdible = entity.IsEdible
                };
            }
        }

        public bool UpdateAnimal(AnimalRUD animal)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Animals
                        .Single(e => e.AnimalId == animal.AnimalId);
                entity.AnimalId = animal.AnimalId;
                entity.Name = animal.Name;
                entity.Species = animal.Species;
                entity.Breed = animal.Breed;
                entity.Sex = animal.Sex;
                entity.Fixed = animal.Fixed;
                entity.HasShots = animal.HasShots;
                entity.Age = animal.Age;
                entity.Description = animal.Description;
                entity.AdoptionPrice = animal.AdoptionPrice;
                entity.IsHouseTrained = animal.IsHouseTrained;
                entity.IsDeclawed = animal.IsDeclawed;
                entity.IsEdible = animal.IsEdible;

                return db.SaveChanges() == 1;
            }
        }

        public bool DeleteAnimal(int animalId)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Animals
                        .Single(e => e.AnimalId == animalId);

                db.Animals.Remove(entity);

                return db.SaveChanges() == 1;
            }
        }
    }
}