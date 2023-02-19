using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParseKadrovayaSpravka
{
    class ParseTeacherInfo
    {
        public static void ParseTacherInfo()
        {
            var book = new XLWorkbook(ConnectFile.XlPath);

            var lists = book.Worksheets;

            foreach (var list in lists)
            {
                if (list.Name == "Сведения о преподавателях")
                {
                    var a = list.Cell(1,1).Value;
                    MessageBox.Show(a.ToString());
                }
            }

        }
    }
}
