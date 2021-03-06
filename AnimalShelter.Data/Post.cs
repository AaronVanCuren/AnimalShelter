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
        [Required]
        public string UserId { get; set; }

        [Key]
        public int PostId { get; set; }

        public int AnimalId { get; set; }
        [ForeignKey(nameof(AnimalId))]
        public virtual Animal Animal { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
