using AnimalShelter.Data;
using AnimalShelter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Services
{
    public class CompanyService
    {
        private readonly Guid _userId;

        public CompanyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCompany(CompanyCreate model)
        {
            var entity = new Company()
            {
                CompanyUser = _userId,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address
            };

            using (var db = new ApplicationDbContext())
            {
                db.Companies.Add(entity);
                return db.SaveChanges() == 1;
            }
        }

        public IEnumerable<CompanyRUD> GetCompanies()
        {
            using (var db = new ApplicationDbContext())
            {
                var query = db.Companies
                        .Where(e => e.CompanyUser == _userId)
                        .Select(
                            e => new CompanyRUD
                            {
                                Name = e.Name,
                                PhoneNumber = e.PhoneNumber,
                                Address = e.Address
                            });

                return query.ToArray();
            }
        }

        public CompanyRUD GetCompanyById(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Companies
                        .Single(e => e.CompanyId == id && e.CompanyUser == _userId);
                return
                    new CompanyRUD
                    {
                        CompanyId = entity.CompanyId,
                        Name = entity.Name,
                        PhoneNumber = entity.PhoneNumber,
                        Address = entity.Address
                    };
            }
        }

        public bool UpdateCompany(CompanyRUD model)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Companies
                        .Single(e => e.CompanyId == model.CompanyId && e.CompanyUser == _userId);

                entity.Name = model.Name;
                entity.PhoneNumber = model.PhoneNumber;
                entity.Address = model.Address;

                return db.SaveChanges() == 1;
            }
        }

        public bool DeleteCompany(int companyId)
        {
            using (var db = new ApplicationDbContext())
            {
                var entity = db.Companies
                        .Single(e => e.CompanyId == companyId && e.CompanyUser == _userId);

                db.Companies.Remove(entity);

                return db.SaveChanges() == 1;
            }
        }
    }
}
