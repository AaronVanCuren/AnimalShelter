using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class UserRatingListItem
    {
        public int RatingId { get; set; }

        public string CompanyName { get; set; }

        public double AverageRating { get; set; }
    }
}
