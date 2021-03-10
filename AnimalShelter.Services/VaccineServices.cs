using AnimalShelter.Data;
using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class VaccineServices
    {

        private readonly Guid _userId;

        public VaccineServices(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateVaccine(VaccineCreate vaccine)
        {
            var entity = new Vaccine()
            {
                Id = vaccine.Id,
                Name = vaccine.Name,
                CommonName = vaccine.CommonName,
                ApplicableAnimals = vaccine.ApplicableAnimals,
                VaccinationSchedule = vaccine.VaccinationSchedule
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Vaccines.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<VaccineRUD> GetVaccines()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Vaccines
                        .Select(
                            e => new VaccineRUD
                            {
                                Id = e.Id,
                                CommonName = e.CommonName
                            });

                return query.ToArray();
            }
        }
        public bool UpdateVaccine(VaccineRUD model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Vaccines
                        .Single(e => e.Id == model.Id);

                entity.Name = model.Name;
                entity.CommonName = model.CommonName;
                entity.ApplicableAnimals = model.ApplicableAnimals;
                entity.VaccinationSchedule = model.VaccinationSchedule;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteVaccine(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Vaccines
                        .Single(e => e.Id == id);

                ctx.Vaccines.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
