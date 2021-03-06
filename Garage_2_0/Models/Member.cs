﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Garage_2_0.Models
{
    public class Member
    {
        public int MemberId { get; set; }
        public string FullName {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Range(18, 100)]
        public int Age { get; set; }
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
    }
}