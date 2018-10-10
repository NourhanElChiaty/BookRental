﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookRental.Models
{
    public class Rental
    {
        public int Id { get; set; }

        public Customer Customer { get; set; }

    
        
        public Book Book { get; set; }

      
        public DateTime? DateRented { get; set; }

    }
}