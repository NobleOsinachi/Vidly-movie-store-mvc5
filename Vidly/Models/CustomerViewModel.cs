using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class CustomerViewModel
    {
        public IEnumerable<MembershipType> membershipType { get; set; }
        public Customers customer { get; set; }
    }
}