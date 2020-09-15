using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace Lab06EFCore.Models
{
    public class Runner
    {
        public int RunnerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Category { get; set; }

        /**Associations**/
        
        [JsonIgnore]
        [IgnoreDataMember]
        public List<Run> RunList { get; set; }
    }
}
