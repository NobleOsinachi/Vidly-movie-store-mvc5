using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public short SignUpFee { get; set; } //We used short because the value we are storing isnt much
        public byte DurationInMonth { get; set; } //byte because we want to store only up to 12 value
        public byte DiscountRate { get; set; }
    }
}