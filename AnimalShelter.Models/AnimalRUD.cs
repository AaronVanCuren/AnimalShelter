using AnimalShelter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class AnimalRUD
    {
        //--Testing purposes
        public int AnimalId { get; set; }
        public string Name { get; set; }
        public SpeciesType Species { get; set; }
        public string Breed { get; set; }
        public bool Sex { get; set; }
        public bool Fixed { get; set; }
        public bool HasShots { get; set; }
        public string Age { get; set; }
        public string Description { get; set; }
        public decimal AdoptionPrice { get; set; }
        public bool IsHouseTrained { get; set; }
        public bool IsDeclawed { get; set; }
        public bool IsEdible { get; set; }
    }
}
