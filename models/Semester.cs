using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseKadrovayaSpravka.models
{
    class Semester
    {
        public int Number { get; set; }
        public List<Subject> Subjects { get; set; }

        public Semester(int number, List<Subject> subjects)
        {
            Number = number;
            Subjects = subjects;
        }
    }
}
