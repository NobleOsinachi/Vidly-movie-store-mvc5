using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movies
    {
        public int id { get; set; }
        public string name { get; set; }


        public List<Movies> movies {
            get {
                return
                 new List<Movies>
                 {
                    new Movies { id = 1, name = "BlackList" },
                    new Movies { id = 2, name = "Grasshopper" },
                    new Movies { id = 3, name = "Avengers" }
                 };
                }
        }

    }
}