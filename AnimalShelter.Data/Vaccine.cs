using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Data
{
    public class Vaccine
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string CommonName { get; set; }
        public List<string> ApplicableAnimals { get; set; }
        [Required]
        public string VaccinationSchedule { get; set; }
    }
}
