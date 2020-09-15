using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06EFCore.Models
{
    public class EFRegistrationRepository : IRegistrationRepository
    {
        private RaceEventsDbContext context;

        public EFRegistrationRepository(RaceEventsDbContext ctx)
        {
            context = ctx;
        }
        
        public IEnumerable<Registration> Registrations => context.Registrations
            .Include(o => o.Lines)
            .ThenInclude(l => l.Race);

        public void SaveRegistration(Registration registration)
        {
            context.AttachRange(registration.Lines.Select(l => l.Race));
            if (registration.RegistrationID == 0)
            {
                context.Registrations.Add(registration);
            }
            context.SaveChanges();
        }
    }
}
