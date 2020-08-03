using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06EFCore.Models
{
    public interface IRunRepository
    {
        IEnumerable<Run> Runs {get;}
    }
}
