using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zametk
{
    public class Zametka
    {
        public string name;
        public string description;
        public string date;
        public string dateToComp;

        public Zametka(string name, string description, string date, string dateToComp)
        {
            this.name = name;
            this.description = description;
            this.date = date;
            this.dateToComp = dateToComp;
        }
    }
}
