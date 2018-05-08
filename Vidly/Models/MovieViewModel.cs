using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MovieViewModel
    {
        public IEnumerable<Genre> genre { get; set; }

        public Movies movie { get; set;}
    }
}