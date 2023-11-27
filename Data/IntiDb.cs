
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_с_бд.ContextData;
using ASP_с_бд.Entities;

namespace ASP_с_бд.Data
{
    public class DbInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();
            if (context.telephoneDescriptions.Any()) return;
            var sections = new List<TelephoneDescription>()
            {
                new TelephoneDescription(){ID=1,LastName="Соцкова",Name="Екатерина",MiddleName="Владимировна",NumberTelephone="89003574312",Adress="г.Нижний Новгород ул.Планерная д.3 кв.32",Description=" 1 г.Нижний Новгород ул.Планерная д.3 кв.32"},
                new TelephoneDescription(){ID=2,LastName="Илюшина",Name="Елена",MiddleName="Викторовна",NumberTelephone="8900309912",Adress="г.Великий Новгород ул.Ленина д.5 кв.11",Description=" 2 г.Великий Новгород ул.Ленина д.5 кв.11"}
            };
            using(var trans=context.Database.BeginTransaction())
            {
                foreach(var section in sections)
                {
                    context.telephoneDescriptions.Add(section);
                }

                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[telephoneDescriptions] ON");
                context.SaveChanges();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[telephoneDescriptions] OFF");
                trans.Commit();
            }
        }
    }
}
