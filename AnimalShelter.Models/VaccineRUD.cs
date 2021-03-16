using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class VaccineRUD
    {
        public int VaccineId { get; set; }
        public string Name { get; set; }
        public string CommonName { get; set; }
        public string VaccinationSchedule { get; set; }
    }
}
