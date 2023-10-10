using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_с_бд
{
    public class ModelSQL
    {
        
        public ModelSQL() { }
        public int ModelSQLID { get; set; }
        private string lastName;
        private string name;
        private string middleName;
        private string number;
        private string adress;
        private string description;
        public ModelSQL(string LastName, string Name, string MiddleName, string NumberTelephone, string Adress, string Description)
        {
            this.lastName = LastName;
            this.name = Name;
            this.middleName = MiddleName;
            this.number = NumberTelephone;
            this.adress = Adress;
            this.description = Description;
        }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string MiddleName { get { return middleName; } set { middleName = value; } }
        public string NumberTelephone { get { return number; } set { number = value; } }
        public string Adress { get { return adress; } set { adress = value; } }
        public string Description { get { return description; } set { description = value; } }

        public override string ToString()
        {
            return $"{LastName,15}{Name,15}{MiddleName,15}{NumberTelephone,15}{Adress,50}{Description,50}";
        }
    }
}
