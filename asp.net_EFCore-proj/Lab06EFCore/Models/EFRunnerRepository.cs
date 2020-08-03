using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06EFCore.Models
{
    public class EFRunnerRepository : IRunnerRepository
    {
        //connection string
        private RaceEventsDbContext context;
        public IEnumerable<Runner> Runners => context.Runners
             .Include(r => r.RunList);

        public EFRunnerRepository(RaceEventsDbContext context)
        {
            this.context = context;
        }
    }
}
