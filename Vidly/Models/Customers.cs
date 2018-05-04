using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customers
    {
        public int id { get; set; }
        public string name { get; set; }


        public List<Customers> customers
        {
            get
            {
                return
                 new List<Customers>
                 {
                    new Customers {id = 1, name = "Cynthia O'Reilley" },
                    new Customers {id = 2, name = "HJames Smith" },
                    new Customers {id = 3, name = "Nadine Johnson" }
                 };
            }
        }

    }
}