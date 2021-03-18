using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class PostListItem
    {
        public int PostId { get; set; }
        public IQueryable AnimalId { get; set; }
    }
}
