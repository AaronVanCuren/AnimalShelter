using AnimalShelter.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class UserUpdate
    {
        public string Id { get; set; }
        
        public UserType UserType { get; set; }

        public string FullName { get; set; }

        public string CompanyName { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }
}
