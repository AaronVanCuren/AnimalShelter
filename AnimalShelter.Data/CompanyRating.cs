using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//change

namespace AnimalShelter.Data
{
    public class CompanyRating
    {
        //change
        [Key]
        public int RatingId { get; set; }

        // Score for assessing the companies process of adopting an animal
        [Required]
        public double AdoptingProcessScore { get; set; }

        // Score for assessing the friendliness of the companies employees during the adoption process
        [Required]
        public double FriendlinessScore { get; set; }

        public double AverageScore
        {
            get
            {
                return ((AdoptingProcessScore + FriendlinessScore) / 2);
            }
        }

        [Required]
        public UserType UserType { get; set; }
        [ForeignKey(nameof(UserType))]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
