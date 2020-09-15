using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab06EFCore.Models
{
    public class EFRunRepository : IRunRepository
    {
        private RaceEventsDbContext context;

        public IEnumerable<Run> Runs => context.Runs
            .Include(ra => ra.Race)
            .Include(r => r.Runner);

        public EFRunRepository(RaceEventsDbContext context)
        {
            this.context = context;
        }
    }
}
