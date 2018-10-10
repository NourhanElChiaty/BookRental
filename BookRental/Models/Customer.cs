using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookRental.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public ApplicationUser customer { get; set; }

        [Required]
        public string CustomerId { get; set; }

        [Display(Name = "First Name")]
        public string Cust_FName { get; set; }

        [Display(Name = "Last Name")]
        public string Cust_LName { get; set; }

        [Display(Name = "Date Of Birth")]
        public string Cust_BOD { get; set; }

       

    }
}