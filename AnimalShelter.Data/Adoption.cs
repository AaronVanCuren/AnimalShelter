using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Data
{
    public class Adoption
    {
        [Key]
        public int AdoptionId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public int PostId { get; set; }
        [ForeignKey(nameof(PostId))]
        public virtual Post Post { get; set; }

        [Required]
        public int ProfileId { get; set; }
        [ForeignKey(nameof(ProfileId))]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
