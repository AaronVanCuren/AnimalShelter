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
                IsEdible = animal.IsEdible,
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
