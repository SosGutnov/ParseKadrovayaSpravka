using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseKadrovayaSpravka.models
{
    class Title_plan
    {
        public Speciality Spec { get; set; }
        public int Date_enter { get; set; }

        public Title_plan(Speciality spec, int date_enter)
        {
            Spec = spec;
            Date_enter = date_enter;
        }
    }
}
