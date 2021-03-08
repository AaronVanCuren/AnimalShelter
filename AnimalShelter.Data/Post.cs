using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        [ForeignKey(nameof(AnimalId))]
        public virtual Animal Animal { get; set; }
        [Required]
        public int CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public virtual Company Company { get; set; }
    }
}
