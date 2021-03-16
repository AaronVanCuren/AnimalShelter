using AnimalShelter.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class AnimalCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(30, ErrorMessage = "There are too many charcters in this field. Must have less than 30 characters.")]
        public string Name { get; set; }

        [Required]
        public SpeciesType Species { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "There are too many charcters in this field. Must have less than 20 characters.")]
        public string Breed { get; set; }

        [Required]
        public bool Sex { get; set; }

        [Required]
        public bool Fixed { get; set; }

        public List<Vaccine> Vaccines { get; set; }

        [Required]
        public string Age { get; set; }

        [Required]
        [MaxLength(1000, ErrorMessage = "Description must be less than 1,000 characters.")]
        public string Description { get; set; }

        [Required]
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
