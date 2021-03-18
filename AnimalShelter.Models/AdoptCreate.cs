using AnimalShelter.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalShelter.Models
{
    public class AdoptCreate
    {
        //[Display(Post = "User type")]
        public int PostId { get; set; }

        public UserType UserType { get; set; }
    }
}
