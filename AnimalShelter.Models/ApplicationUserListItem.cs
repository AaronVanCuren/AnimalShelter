using AnimalShelter.Data;
using System.Collections.Generic;
using System.Linq;

namespace AnimalShelter.Models
{
    public class ApplicationUserListItem
    {
        public string Id { get; set; }

        public UserType UserType { get; set; }
        
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string CompanyName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public virtual List<Vaccine> Vaccines { get; set; }

        public virtual List<Animal> Animals { get; set; }

        public virtual List<Post> Posts { get; set; }

        public double Rating { get; set; }
    }
}
