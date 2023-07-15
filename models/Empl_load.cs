using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseKadrovayaSpravka.models
{
    class Empl_load
    {
        public Load Load { get; set; }
        public Employee Employee { get; set; }
        public List<Semester> Semesters { get; set; }

        public Empl_load(Load load, Employee employee, List<Semester> semesters)
        {
            Load = load;
            Employee = employee;
            Semesters = semesters;
        }
    }

}
