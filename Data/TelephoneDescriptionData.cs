using ASP_с_бд.ContextData;
using ASP_с_бд.Entities;
using ASP_с_бд.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_с_бд.Data
{
    public class TelephoneDescriptionData: ITelephoneDescriptionData
    {
        private readonly DataContext context;

        public TelephoneDescriptionData(DataContext Context)
        {
            this.context = Context;
        }

        public void AddTelephoneDescription(TelephoneDescription telephoneDescription)
        {
            context.telephoneDescriptions.Add(telephoneDescription);
            context.SaveChanges();
        }

        public IEnumerable<TelephoneDescription> GetTelephoneDescriptions()
        {
            return this.context.telephoneDescriptions;
        }
    }
}
