using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Lab06EFCore.Models
{   
    /*one to many w/ Volunteer*/
    public class Race
    {
        public int RaceId { get; set; }

        [Required(ErrorMessage = "Please enter a product name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a description")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Please enter a date")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Cause { get; set; }
        [Required(ErrorMessage = "Please enter a distance in miles")]
        public double DistanceInMiles { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a positive value")]
        public decimal RegistrationFee { get; set; }

        [Required(ErrorMessage = "Please specify a category")]
        public string Category { get; set; }

        /**Associations**/
        /*
        public int SponsorId { get; set; }
        public Sponsor Sponsor { get; set; }*/
        
        [JsonIgnore]
        [IgnoreDataMember]
        public List<Run> RunList { get; set; }
    }
}
