using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseKadrovayaSpravka.models
{
    class Load_temp
    {
        public Load Load { get; set; }
        public Employee Empl { get; set; }
        public int Semester { get; set; }
        public int hourly_fund { get; set; }
        public Group Group { get; set; }
        public string Subject { get; set; }
        public string Subject_form { get; set; }
        public double Hours_other { get; set; }
        public double Hours_contact { get; set; }

        public Load_temp(Load load, Employee empl, int semester, int hourly_fund, Group group, string subject, string subject_form, double hours_other, double hours_contact)
        {
            Load = load;
            Empl = empl;
            Semester = semester;
            this.hourly_fund = hourly_fund;
            Group = group;
            Subject = subject;
            Subject_form = subject_form;
            Hours_other = hours_other;
            Hours_contact = hours_contact;
        }
    }
}
