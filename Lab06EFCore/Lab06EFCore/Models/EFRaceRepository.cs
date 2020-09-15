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
            .Include(rl => rl.RunList)
            .ThenInclude(r => r.Runner);
   
        public EFRaceRepository(RaceEventsDbContext context)
        {
            this.context = context;
        }
        public void SaveRace(Race race)
        {
            if (race.RaceId == 0)
            {
                //add new Race to DB
                context.Races.Add(race);
            }
            else
            {
                //update existing Race
                Race dbEntry = context.Races.FirstOrDefault(p => p.RaceId == race.RaceId);
                if (dbEntry != null)
                {
                    dbEntry.Name = race.Name;
                    dbEntry.Location = race.Location;
                    dbEntry.RegistrationFee = race.RegistrationFee;
                    dbEntry.Category = race.Category;
                }
            }

            context.SaveChanges();
        }

        public Race DeleteRace(int raceId)
        {
            //first see if it exists
            Race efProd = context.Races.FirstOrDefault(p => p.RaceId == raceId);
            if (efProd != null)
            {
                context.Races.Remove(efProd);
                context.SaveChanges();
            }
            return efProd;
        }
    }
}
