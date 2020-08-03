using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06EFCore.Models.ViewModels
{
    public class RunnersListViewModel
    {
        public IEnumerable<Runner> Runners { get; set; }
        public PagingInfo PagingInfo { get; set; }

    }
}
