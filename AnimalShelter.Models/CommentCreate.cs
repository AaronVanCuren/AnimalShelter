using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.WebPages.Html;

namespace AnimalShelter.Services
{
    public class CommentCreate
    {
        [Required]
        [MaxLength(280, ErrorMessage = "There are too many characters in this field.")]
        public string Content { get; set; }

        [Required]
        public string PostId { get; set; }

        [Required]
        public string Author { get; set; }
        
        public List<SelectListItem> Posts { get; set; }
    }
}
