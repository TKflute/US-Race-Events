using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06EFCore.Models
{
    public interface IRaceRepository
    {
        IEnumerable<Race> Races { get; }
        void SaveRace(Race race);
        Race DeleteRace(int raceId);
    }
}
