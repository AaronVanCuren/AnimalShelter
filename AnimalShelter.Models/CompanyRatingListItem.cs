using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class CompanyRatingListItem
    {
        public int RatingId { get; set; }

        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public double AverageScore { get; set; }
    }
}
