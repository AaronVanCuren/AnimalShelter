using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Data
{
    public class Bunny : Animal
    {
        [Required]
        public bool IsEdible { get; set; }
    }
}
