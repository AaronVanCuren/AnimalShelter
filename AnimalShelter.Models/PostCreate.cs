using AnimalShelter.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace AnimalShelter.Models
{
    public class PostCreate
    {
        public int AnimalId { get; set; }
        public int CompanyId { get; set; }
    }
}
