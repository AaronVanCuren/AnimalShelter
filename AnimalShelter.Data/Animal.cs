using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Data
{
    public enum SpeciesType { Cat, Dog, Bunny}
    public class Animal
    {
        [Key]
        [Required]
        public int AnimalId { get; set; }
        public string Name { get; set; }
        [Required]
        public SpeciesType Species { get; set; }
        public string Breed { get; set; }
        [Required]
        public bool Sex { get; set; }
        [Required]
        public bool Fixed { get; set; }
        public bool HasShots { get; set; }
        [Required]
        public string Age { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal AdoptionPrice { get; set; }
    }
}
