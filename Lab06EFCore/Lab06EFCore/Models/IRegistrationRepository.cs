using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab06EFCore.Models
{
    public interface IRegistrationRepository
    {
        IEnumerable<Registration> Registrations { get; }
        void SaveRegistration(Registration registration);
    }
}
