using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Data
{
    public class Company : ApplicationUser
    {
        [Required]
        public int CompanyId { get; set; }
        [Required]
        public string Name { get; set; }
        //public virtual List<Post> Posts { get; set; }
        public virtual ICollection<Post> Post { get; set; } = new List<Post>();
    }
}
