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
        public int Semester { get; set; }
        public int Hourly_fund { get; set; }
        public string Group_title { get; set; }
        public string Subject { get; set; }
        public string Subject_form { get; set; }
        public int Hours_other { get; set; }
        public int Hours_contact { get; set; }

        public Empl_load(Load load, Employee employee, int semester, int hourly_fund, string group_title, string subject, string subject_form, int hours_other, int hours_contact)
        {
            Load = load;
            Employee = employee;    
            Semester = semester;
            Hourly_fund = hourly_fund;
            Group_title = group_title;
            Subject = subject;
            Subject_form = subject_form;
            Hours_other = hours_other;
            Hours_contact = hours_contact;
        }
    }

}
