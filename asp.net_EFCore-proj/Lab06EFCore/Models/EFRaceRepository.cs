using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06EFCore.Models
{
    public class EFRaceRepository : IRaceRepository
    {
        private RaceEventsDbContext context;
        public IEnumerable<Race> Races => context.Races
            .Include(s => s.Sponsor)
            .Include(rl => rl.RunList)
            .ThenInclude(r => r.Runner);
            //.ThenInclude(v => v.Volunteer);
  
        //Don't know how Volunteer should fit in- added FK in volunteer table manually
        public EFRaceRepository(RaceEventsDbContext context)
        {
            this.context = context;
        }
    }
}
