﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Data
{
    public class CompanyRating
    {
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
        public int CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public virtual Company Company { get; set; }
    }
}