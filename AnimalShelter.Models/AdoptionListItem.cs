using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class AdoptionListItem
    {
        public int AdoptionId { get; set; }
        public IQueryable PostId { get; set; }
    }
}