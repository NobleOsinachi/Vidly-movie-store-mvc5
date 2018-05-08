using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movies
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name ="Release Date")]
        public DateTime ReleasedDate { get; set; }

        public DateTime DateAdded { get; set; }

        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }

    }
}