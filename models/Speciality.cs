using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseKadrovayaSpravka.models
{
    class Speciality
    {
        public string Title { get; set; }
        public string Code { get; set; }

        public Speciality(string title, string code)
        {
            Title = title;
            Code = code;
        }
    }
}
