using AnimalShelter.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class AnimalRUD
    {
        public int AnimalId { get; set; }

        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(30, ErrorMessage = "There are too many charcters in this field. Must have less than 30 characters.")]
        public string Name { get; set; }

        public SpeciesType Species { get; set; }

        [MaxLength(20, ErrorMessage = "There are too many charcters in this field. Must have less than 20 characters.")]
        public string Breed { get; set; }

        public bool Sex { get; set; }

        public bool Fixed { get; set; }

        public List<Vaccine> Vaccines { get; set; }

        public string Age { get; set; }

        [MaxLength(1000, ErrorMessage = "Description must be less than 1,000 characters.")]
        public string Description { get; set; }

        [Range(0, 2500)]
        public decimal AdoptionPrice { get; set; }

        [Display(Name = "House trained: ")]
        public bool IsHouseTrained { get; set; } = false;

        [Display(Name = "Declawed: ")]
        public bool IsDeclawed { get; set; } = false;

        [Display(Name = "Edible: ")]
        public bool IsEdible { get; set; } = false;
    }
}
