using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab06EFCore.Models;

namespace Lab06EFCore.Models
{
    public class RaceEventsDbContext : DbContext
    {
        public RaceEventsDbContext(DbContextOptions<RaceEventsDbContext> options) : base(options)
        {

        }

        public DbSet<Race> Races { get; set; }
        public DbSet<Run> Runs { get; set; }
        public DbSet<Runner> Runners { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Volunteer> Volunteers { get; set; }
    }
}

