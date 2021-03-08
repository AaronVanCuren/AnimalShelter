using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Data
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [Required]
        public int AnimalId { get; set; }
        [Required]
        public int CompanyId { get; set; }
    }
}
