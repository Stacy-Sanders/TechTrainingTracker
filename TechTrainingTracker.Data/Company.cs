﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTrainingTracker.Data
{
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }

        [Required, Display(Name = "Company Name")]
        public string CompanyName { get; set; }


    }
}
