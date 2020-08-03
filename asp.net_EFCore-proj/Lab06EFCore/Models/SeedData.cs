using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06EFCore.Models
{
    public class SeedData
    {
        public static void EnsurePopulated(RaceEventsDbContext context)
        {
            //if the database doesn't have any Runners
            if (!context.Runners.Any())
            {
                context.AddRange(

                    new Runner
                    {
                        FirstName = "George",
                        LastName = "White",
                        Gender = "male",
                        Age = 42
                    },
                    new Runner
                    {
                        FirstName = "Susie",
                        LastName = "Pearson",
                        Gender = "female",
                        Age = 37
                    },
                    new Runner
                    {
                        FirstName = "Bob",
                        LastName = "Wilson",
                        Gender = "male",
                        Age = 62
                    },
                    new Runner
                    {
                        FirstName = "Jane",
                        LastName = "Johnson",
                        Gender = "female",
                        Age = 53
                    },
                    new Runner
                    {
                        FirstName = "Joseph",
                        LastName = "Daniels",
                        Gender = "male",
                        Age = 28
                    },
                    new Runner
                    {
                        FirstName = "Sharon",
                        LastName = "Norris",
                        Gender = "female",
                        Age = 29
                    },
                    new Runner
                    {
                        FirstName = "David",
                        LastName = "Reed",
                        Gender = "male",
                        Age = 47
                    },
                    new Runner
                    {
                        FirstName = "Sarah",
                        LastName = "Vaughn",
                        Gender = "female",
                        Age = 45
                    },
                    new Runner
                    {
                        FirstName = "Arthur",
                        LastName = "Jones",
                        Gender = "male",
                        Age = 35
                    },
                    new Runner
                    {
                        FirstName = "Nora",
                        LastName = "Madison",
                        Gender = "female",
                        Age = 38
                    }
                );
                context.SaveChanges();
            }

            if (!context.Sponsors.Any())
            {
                context.AddRange(

                    new Sponsor
                    {
                        Name = "Western Bank",
                        Address = "123 Main St.",
                        City = "San Diego",
                        State = "CA",
                        Zip = "92103"
                    },
                    new Sponsor
                    {
                        Name = "Wisconsin Hospital",
                        Address = "345 State St.",
                        City = "Madison",
                        State = "WI",
                        Zip = "52703"
                    }
                );
                context.SaveChanges();
            }

            if (!context.Races.Any())
            {
                context.AddRange(

                    new Race
                    {
                        Location = "San Diego",
                        Date = new DateTime(2020, 9, 25),
                        Cause = "breast cancer",
                        DistanceInMiles = 10,
                        SponsorId = 1
                    },
                    new Race
                    {
                        Location = "Madison",
                        Date = new DateTime(2020, 8, 9),
                        Cause = "brain cancer",
                        DistanceInMiles = 13,
                        SponsorId = 2
                    }
                );
                context.SaveChanges();
            }

            if (!context.Runs.Any())
            {
                context.AddRange(

                    new Run
                    {
                        RunTime = 90,
                        AvgSpeedInMiles = 6.7,
                        RaceId = 1,
                        RunnerId = 2
                    },
                    new Run 
                    {
                        RunTime = 104,
                        AvgSpeedInMiles = 7.5,
                        RaceId = 2,
                        RunnerId = 3
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
