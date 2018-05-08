using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class CustomerStoreViewModel
    {

        public List<Customers> customers
        {
            get
            {
                return
                 new List<Customers>
                 {
                    new Customers {id = 1, Name = "Cynthia O'Reilley" },
                    new Customers {id = 2, Name = "HJames Smith" },
                    new Customers {id = 3, Name = "Nadine Johnson" }
                 };
            }
        }

        public List<Movies> movies
        {
            get
            {
                return
                 new List<Movies>
                 {
                    new Movies { id = 1, Name = "BlackList" },
                    new Movies { id = 2, Name = "Grasshopper" },
                    new Movies { id = 3, Name = "Avengers" }
                 };
            }
        }
    }
}