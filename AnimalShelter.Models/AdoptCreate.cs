using AnimalShelter.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class AdoptCreate
    {
        public int ProfileId { get; set; }

        public int PostId { get; set; }

    }
}
