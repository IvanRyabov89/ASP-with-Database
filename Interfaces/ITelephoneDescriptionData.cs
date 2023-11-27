using ASP_с_бд.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_с_бд.Interfaces
{
    public interface ITelephoneDescriptionData
    {
        IEnumerable<TelephoneDescription> GetTelephoneDescriptions();
        void AddTelephoneDescription(TelephoneDescription telephone);
    }
}
