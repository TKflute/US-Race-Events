using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06EFCore.Models
{
    public class SponsorApplication
    {
        [BindNever]
        public int SponsorApplicationID { get; set; }
      
        [Required(ErrorMessage = "Please enter a Business name")]
        public string BusinessName { get; set; }

        [Required(ErrorMessage = "Please enter the first Business address line")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Please enter a city name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please enter a state name")]
        public string State { get; set; }
        public string Zip { get; set; }

        [Required(ErrorMessage = "Please enter a country name")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please enter a Point of Contact name")]
        public string POCName { get; set; }

        [Required(ErrorMessage = "Please enter a Point of Contact email")]
        public string POCEmail { get; set; }

        public string Budget { get; set; }

        [BindNever]
        public bool Processed { get; set; }

        //Association
        public int RaceId { get; set; }

        public Race Race { get; set; }
    }
}
