using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Garage_2_0.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public int Age { get; set; }
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
    }
}