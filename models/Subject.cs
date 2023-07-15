using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseKadrovayaSpravka.models
{
    class Subject
    {
        public int Hourly_fund { get; set; }
        public string Group_title { get; set; }
        public string Subj { get; set; }
        public string Subject_form { get; set; }
        public int Hours_other { get; set; }
        public int Hours_contact { get; set; }

        public Subject(int hourly_fund, string group_title, string subject, string subject_form, int hours_other, int hours_contact)
        {
            Hourly_fund = hourly_fund;
            Group_title = group_title;
            Subj = subject;
            Subject_form = subject_form;
            Hours_other = hours_other;
            Hours_contact = hours_contact;
        }
    }
}
