using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customers
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name ="Subscribed to Newsletter?")]
        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Date of Birth")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }

        [ForeignKey("MembershipTypeId")]
        public MembershipType MembershipType { get; set; }

    }
}