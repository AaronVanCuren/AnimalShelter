using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class ProfileRUD
    {
        [Required]
        public int ProfileId { get; set; }

        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(30, ErrorMessage = "There are too many charcters in this field. Must have less than 30 characters.")]
        public string FirstName { get; set; }

        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(30, ErrorMessage = "There are too many charcters in this field. Must have less than 30 characters.")]
        public string LastName { get; set; }

        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(200, ErrorMessage = "There are too many charcters in this field. Must have less than 200 characters.")]
        public string Address { get; set; }
    }
}
