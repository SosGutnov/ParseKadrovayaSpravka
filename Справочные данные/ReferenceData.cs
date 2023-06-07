using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseKadrovayaSpravka.Справочные_данные
{
    internal class ReferenceData
    {
        public static Dictionary<string, Tuple<string, string>> EmployeeDegrees = new Dictionary<string, Tuple<string, string>>()
        {
            { "канд. физ.-мат. наук", new Tuple<string, string>("кандидат физико-математических наук", "к.ф.-м.н.") },
            { "ученая степень - доктор физико-математических наук", new Tuple<string, string>("доктор физико-математических наук", "д.ф.-м.н.") },
            { "д-р физ.-мат. наук", new Tuple<string, string>("доктор физико-математических наук", "д.ф.-м.н.") },
            { "док. физ.-мат. наук", new Tuple<string, string>("доктор физико-математических наук", "д.ф.-м.н.") },
            { "докт. физ.-мат. наук", new Tuple<string, string>("доктор физико-математических наук", "д.ф.-м.н.") },
            { "доктор сельско-хозяйственных  наук", new Tuple<string, string>("доктор сельско-хозяйственных  наук", "") },
            { "д-р с.-х. н.", new Tuple<string, string>("доктор сельско-хозяйственных  наук", "") },
            { "канд. ист. наук", new Tuple<string, string>("кандидат исторических наук", "") },
            { "канд.пед.наук", new Tuple<string, string>("кандидат педагогических наук", "") },
            { "канд. пед. наук", new Tuple<string, string>("кандидат педагогических наук", "") },
            { "д-р пед. наук", new Tuple<string, string>("доктор педагогических наук", "") },
            { "д-р пед. наук (по специальности 13.00.02 Теория и методика обучения и воспитания (математика))", new Tuple<string, string>("доктор педагогических наук", "") },
            { "канд. филос. наук", new Tuple<string, string>("кандидат философских наук", "") },
            { "канд. технич. наук", new Tuple<string, string>("кандидат технических наук", "") },
            { "канд. техн. наук", new Tuple<string, string>("кандидат технических наук", "") },
            { "д-р технич. наук", new Tuple<string, string>("доктор технических наук", "") },
            { "д-р полит. наук", new Tuple<string, string>("доктор политехнических наук", "") },
            { "канд. экон. наук", new Tuple<string, string>("кандидат экономических наук", "") },
            { "д-р экон.  наук", new Tuple<string, string>("доктор экономических наук", "") },
            { "канд. социол. наук", new Tuple<string, string>("кандидат социологических наук", "") },
            { "канд. юрид. наук", new Tuple<string, string>("кандидат юридических наук", "") },
            { "д-р филол. наук", new Tuple<string, string>("доктор филологических наук", "") },
            { "канд. филол. наук", new Tuple<string, string>("кандидат филологических наук", "") },
            { "д-р ист. наук", new Tuple<string, string>("доктор исторических наук", "") }
        };
    }
}
