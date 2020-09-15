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
                        Location = "San Diego, CA",
                        Date = new DateTime(2020, 9, 25),
                        Cause = "breast cancer",
                        DistanceInMiles = 10
                    },
                    new Race
                    {
                        Location = "Madison, WI",
                        Date = new DateTime(2020, 8, 9),
                        Cause = "brain cancer",
                        DistanceInMiles = 13
                    },
                    new Race
                    {
                        Location = "New York, NY",
                        Date = new DateTime(2020, 7, 12),
                        Cause = "US Schools",
                        DistanceInMiles = 5
                    },
                    new Race
                    {
                        Location = "Los Angeles, CA",
                        Date = new DateTime(2020, 6, 25),
                        Cause = "animal shelter",
                        DistanceInMiles = 8
                    },
                    new Race
                    {
                        Location = "Chicago, IL",
                        Date = new DateTime(2020, 10, 01),
                        Cause = "fire department",
                        DistanceInMiles = 10
                    },
                    new Race
                    {
                        Location = "Philadelphia, PA",
                        Date = new DateTime(2020, 10, 15),
                        Cause = "HIV research",
                        DistanceInMiles = 13
                    },
                    new Race
                    {
                        Location = "San Francisco, CA",
                        Date = new DateTime(2020, 11, 01),
                        Cause = "police department",
                        DistanceInMiles = 8
                    },
                    new Race
                    {
                        Location = "Austin, TX",
                        Date = new DateTime(2020, 12, 01),
                        Cause = "family charities",
                        DistanceInMiles = 13
                    },
                    new Race
                    {
                        Location = "New York, NY",
                        Date = new DateTime(2020, 9, 11),
                        Cause = "9/11 memorial",
                        DistanceInMiles = 26.2
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
                        RunnerId = 1
                    },
                    new Run
                    {
                        RunTime = 104,
                        AvgSpeedInMiles = 7.5,
                        RaceId = 2,
                        RunnerId = 2
                    },
                    new Run
                    {
                        RunTime = 52,
                        AvgSpeedInMiles = 5.7,
                        RaceId = 3,
                        RunnerId = 3
                    },
                    new Run
                    {
                        RunTime = 104,
                        AvgSpeedInMiles = 6.2,
                        RaceId = 4,
                        RunnerId = 4
                    },
                    new Run
                    {
                        RunTime = 70,
                        AvgSpeedInMiles = 6.8,
                        RaceId = 5,
                        RunnerId = 5
                    },
                    new Run
                    {
                        RunTime = 98,
                        AvgSpeedInMiles = 8.0,
                        RaceId = 6,
                        RunnerId = 6
                    },
                    new Run
                    {
                        RunTime = 62,
                        AvgSpeedInMiles = 7.7,
                        RaceId = 7,
                        RunnerId = 7
                    },
                    new Run
                    {
                        RunTime = 135,
                        AvgSpeedInMiles = 5.8,
                        RaceId = 8,
                        RunnerId = 8
                    },
                    new Run
                    {
                        RunTime = 280,
                        AvgSpeedInMiles = 5.6,
                        RaceId = 9,
                        RunnerId = 9
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
