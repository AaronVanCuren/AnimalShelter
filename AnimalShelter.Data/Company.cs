using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Data
{
    public class Company
    {
        [Required]
        public Guid UserId { get; set; }

        [Key]
        public int CompanyId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        public virtual List<Animal> Animals { get; set; }

        public virtual List<Post> Posts { get; set; }

        public virtual List<CompanyRating> Ratings { get; set; }

        public double Rating
        {
            get
            {
                double TotalAverageRating = 0;
                foreach (var rating in Ratings)
                {
                    TotalAverageRating += rating.AverageScore;
                }
                return (Ratings.Count > 0) ? TotalAverageRating / Ratings.Count : 0;
            }
        }
    }
}
