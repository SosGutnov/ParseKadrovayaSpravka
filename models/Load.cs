using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseKadrovayaSpravka.models
{
    class Load
    {
        public int Current_year { get; set; }
        public Department Department { get; set; }

        public Load(int current_year, Department department)
        {
            Current_year = current_year;
            Department = department;
        }
    }
}
