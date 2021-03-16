using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Data
{
    public enum SpeciesType { Dog, Cat, Bunny}
    public class Animal
    {
        [Key]
        public int AnimalId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public SpeciesType Species { get; set; }

        [Required]
        public string Breed { get; set; }

        [Required]
        public bool Sex { get; set; }

        [Required]
        public bool Fixed { get; set; }

        public virtual List<Vaccine> Vaccines { get; set; }

        [Required]
        public string Age { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal AdoptionPrice { get; set; }

        public bool IsHouseTrained { get; set; }

        public bool IsDeclawed { get; set; }

        public bool IsEdible { get; set; }
    }
}
