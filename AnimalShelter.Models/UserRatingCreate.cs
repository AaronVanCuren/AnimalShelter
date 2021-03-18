using AnimalShelter.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class UserRatingCreate
    {
        public string CompanyName { get; set; }

        public string UserId { get; set; }

        public UserType UserType { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "Rating must be a number between the range of 0 and 10.")]
        public double AdoptingProcessScore { get; set; }

        [Required]
        [Range(0, 10, ErrorMessage = "Rating must be a number between the range of 0 and 10.")]
        public double FriendlinessScore { get; set; }
    }
}
