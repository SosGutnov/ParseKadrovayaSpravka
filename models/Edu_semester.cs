using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseKadrovayaSpravka.models
{
    class Edu_semester
    {
        public int Semester { get; set; }
        public int Lecture { get; set; }
        public int Practice { get; set; }
        public int Laboratory { get; set; }
        public int Ind_work { get; set; }

        public Edu_semester()
        {
        }
    }
}
