using AnimalShelter.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class CompanyCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(100, ErrorMessage = "There are too many charcters in this field. Must have less than 100 characters.")]
        public string Name { get; set; }

        [Required]
        [MinLength(12, ErrorMessage = "Please enter a 12 digit number in the following format: XXX-XXX-XXXX")]
        [MaxLength(12, ErrorMessage = "Please enter a 12 digit number in the following format: XXX-XXX-XXXX")]
        public string PhoneNumber { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Please enter at least 2 characters")]
        [MaxLength(200, ErrorMessage = "There are too many charcters in this field. Must have less than 200 characters.")]
        public string Address { get; set; }

        public virtual List<Animal> Animals { get; set; }

        public virtual List<Post> Posts { get; set; }

        public virtual List<CompanyRating> Ratings { get; set; }
    }
}
