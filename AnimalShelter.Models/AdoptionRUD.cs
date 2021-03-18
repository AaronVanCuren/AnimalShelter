using AnimalShelter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class AdoptionRUD
    {
        public int AdoptionId { get; set; }
        public int PostId { get; set; }

        public UserType UserType { get; set; }
    }
}