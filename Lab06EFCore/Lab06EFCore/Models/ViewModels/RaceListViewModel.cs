using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06EFCore.Models.ViewModels
{
    public class RaceListViewModel
    {
        public IEnumerable<Race> Races { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
    }
}
