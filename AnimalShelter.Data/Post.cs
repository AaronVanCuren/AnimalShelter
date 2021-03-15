using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Data
{
    public class Post : Animal
    {
        [Required]
        public Guid UserId { get; set; }

        [Key]
        public int PostId { get; set; }

        public int ProfileId { get; set; }
        [ForeignKey(nameof(ProfileId))]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}
