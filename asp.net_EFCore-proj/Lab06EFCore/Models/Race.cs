using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06EFCore.Models
{   
    /*one to many w/ Volunteer*/
    public class Race
    {
        public int RaceId { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Cause { get; set; }
        public double DistanceInMiles { get; set; }

        /**Associations**/
        public int SponsorId { get; set; }
        public Sponsor Sponsor { get; set; }
        public List<Run> RunList { get; set; }
    }
}
