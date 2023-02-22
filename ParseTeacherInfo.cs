using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
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
        public static void ParseTacherInfo(DataGridView data)
        {
            var book = new XLWorkbook(ConnectFile.XlPath);

            var lists = book.Worksheets;
            int n = 10;
            for (int i = 0; i <= 116; i++)
            {
                data.Rows.Add();
            }
            foreach (var list in lists)
            {
                if (list.Name == "Сведения о преподавателях")
                {
                    for (int i = 3; i < 120; i++)
                    {
                        for (int j = 1; j < n; j++)
                        {
                            data.Rows[i-3].Cells[j - 1].Value = list.Cell(i, j).Value;
                        }
                    }
                    break;
                }
            }

        }
    }
}
