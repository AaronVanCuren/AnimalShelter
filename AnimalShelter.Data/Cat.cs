using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Data
{
    public class Cat :Animal
    {
        [Required]
        public bool IsDeclawed { get; set; }
    }
}
