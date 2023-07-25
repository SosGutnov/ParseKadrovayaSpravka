using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseKadrovayaSpravka.models
{
    class Edu_plan
    {
        public string Subject { get; set; }
        public Title_plan Title_plan { get; set; }

        public Edu_plan(string subject, Title_plan title_plan)
        {
            Subject = subject;
            Title_plan = title_plan;
        }
    }
}
