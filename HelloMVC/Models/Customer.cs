using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HelloMVC.Models
{
    public class Customer
    {
        public string Id { get; set; }
        [Required]
        [StringLength (30, ErrorMessage ="Your string is to long!")]
        [DisplayName("Enter your name")]
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}