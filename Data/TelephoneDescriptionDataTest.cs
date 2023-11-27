
using ASP_с_бд.Entities;
using ASP_с_бд.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_с_бд.Data
{
    public class TelephoneDescriptionDataTest: ITelephoneDescriptionData
    {
        static List<TelephoneDescription> data;
        static TelephoneDescriptionDataTest()
        {
            data = new List<TelephoneDescription>()
            {
                new TelephoneDescription(){ID=1,LastName="Цепелева",Name="Наталья",MiddleName="Владимировна",NumberTelephone="89054657314",Adress="Ковров Грибоедова дом 22 квартира 1" },
                new TelephoneDescription(){ID=1,LastName="Цепелева",Name="Нина",MiddleName="Владимировна",NumberTelephone="89054657314",Adress="Ковров Грибоедова дом 22 квартира 1" },
                new TelephoneDescription(){ID=1,LastName="Цепелева",Name="Натель",MiddleName="Владимировна",NumberTelephone="89054657314",Adress="Ковров Грибоедова дом 22 квартира 1" }
            }; ;
        }

        public void AddTelephoneDescription(TelephoneDescription telephone)
        {
            data.Add(telephone);
        }

        public IEnumerable<TelephoneDescription> GetTelephoneDescriptions()
        {
            return data;
        }
    }
}
