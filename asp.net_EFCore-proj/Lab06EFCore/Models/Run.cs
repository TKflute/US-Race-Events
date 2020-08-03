using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06EFCore.Models
{  
    public class Run
    {
        public int RunId { get; set; }
        public double RunTime { get; set; }
        public double AvgSpeedInMiles { get; set; }

        /**Associations**/
        public int RaceId { get; set; }
        public Race Race { get; set; }
        public int RunnerId { get; set; }
        public Runner Runner { get; set; }
    }
}
