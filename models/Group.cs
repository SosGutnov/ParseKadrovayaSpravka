using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseKadrovayaSpravka.models
{
    class Group
    {
        public string Title { get; set; }
        public int Galactika_number { get; set; }
        public int Year { get; set; }
        public string Speciality_code { get; set; }

        public Group(string title, int galactika_number, int year, string speciality_code)
        {
            Title = title;
            Galactika_number = galactika_number;
            Year = year;
            Speciality_code = speciality_code;
        }
    }
}
