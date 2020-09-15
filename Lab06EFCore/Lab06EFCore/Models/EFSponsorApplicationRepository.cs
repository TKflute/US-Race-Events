using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06EFCore.Models
{
    public class EFSponsorApplicationRepository : ISponsorApplicationRepository
    {
        private RaceEventsDbContext context;

        public EFSponsorApplicationRepository(RaceEventsDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<SponsorApplication> SponsorApplications => context.SponsorApplications
            .Include(l => l.Race);

        public void SaveSponsorApplication(SponsorApplication sponsorApplication)
        {
            //not sure I need a line like this since there aren't muliple lines - just one order form
            //but how do I connect to Race; will it do so automatically?
            //context.AttachRange(sponsorApplication.Lines.Select(l => l.Race));
            if (sponsorApplication.SponsorApplicationID == 0)
            {
                context.SponsorApplications.Add(sponsorApplication);
            }
            context.SaveChanges();
        }
    }
}

