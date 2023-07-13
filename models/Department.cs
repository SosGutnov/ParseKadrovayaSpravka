using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseKadrovayaSpravka.models
{
    class Department
    {
        public string Title { get; set; }
        public string Faculty { get; set; }

        public Department(string title, string faculty)
        {
            Title = title;
            Faculty = faculty;
        }
    }
}
