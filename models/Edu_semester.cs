using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseKadrovayaSpravka.models
{
    class Edu_semester
    {
        public Edu_plan Edu_plan { get; set; }
        public int Semester { get; set; }

        public Edu_semester(Edu_plan edu_plan, int semester)
        {
            Edu_plan = edu_plan;
            Semester = semester;
        }
    }
}
