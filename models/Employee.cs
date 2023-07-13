using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseKadrovayaSpravka.models
{
    class Employee
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronimyc { get; set; }

        public Employee(string surname, string name, string patronimyc)
        {
            Surname = surname;
            Name = name;
            Patronimyc = patronimyc;
        }
    }
}
