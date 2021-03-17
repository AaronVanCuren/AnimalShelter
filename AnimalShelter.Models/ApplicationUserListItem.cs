using AnimalShelter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class ApplicationUserListItem
    {
        public UserType UserType { get; set; }

        public string FullName { get; set; }

        public string CompanyName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        //public virtual string Adoption { get; set; }

        public virtual List<Vaccine> Vaccines { get; set; }

        public virtual List<Animal> Animals { get; set; }

        public virtual List<Post> Posts { get; set; }

        public virtual List<UserRating> Ratings { get; set; }

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
