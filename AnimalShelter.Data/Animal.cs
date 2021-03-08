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
        [ForeignKey(nameof(Company))]
        [Required]
        public Guid User { get; set; }
        public virtual Company Company { get; set; }
    }
}
