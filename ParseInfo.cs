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
    class ParseInfo
    {
        public static void ParseTacherInfo(DataGridView data)
        {
            int n = 9; // columns
            int y = 119; // rows in excel
            int a = 3; // marg

            data.Columns.Clear();
            DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[n];

            for (int i = 0; i < n; i++)
            {
                column[i] = new DataGridViewTextBoxColumn();
            }
            column[0].HeaderText = "ФИО";
            column[1].HeaderText = "Условия привлечения";
            column[2].HeaderText = "Должность, ученая степень, ученое звание";
            column[3].HeaderText = "Уровень образования, наименование специальности, направления подготовки, наименование присвоенной квалификации";
            column[4].HeaderText = "Сведения о дополнительном профессиональном образовании";
            column[5].HeaderText = "Трудовой стаж работы в организациях, осуществляющих образовательную деятельность, на должностях педагогических (научно-педагогических) работников";
            column[6].HeaderText = "Трудовой стаж работы в иных организациях, осуществляющих деятельность в профессиональной сфере, соответствующей профессиональной деятельности, к которой готовится выпускник";
            column[7].HeaderText = "Срок трудового договораили договора ГПХ, или Дата и номер  приказа об увольнении";
            column[8].HeaderText = "Избран по конкурсу ";

            data.Columns.AddRange(column);

            var book = new XLWorkbook(ConnectFile.XlPath);

            var lists = book.Worksheets;
            for (int i = 0; i <= y-a; i++)
            {
                data.Rows.Add();
            }
            foreach (var list in lists)
            {
                if (list.Name == "Сведения о преподавателях")
                {
                    for (int i = a; i <= y; i++)
                    {
                        for (int j = 1; j <= n; j++)
                        {
                            data.Rows[i - a].Cells[j - 1].Value = list.Cell(i, j).Value.ToString();
                        }
                    }
                    break;
                }
            }

        }

        public static void ParseSpecialPractices(DataGridView data)
        {
            int n = 5;
            int y = 21;
            int a = 4;
            data.Columns.Clear();
            DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[n];
            for (int i = 0; i < n; i++)
            {
                column[i] = new DataGridViewTextBoxColumn();
            }
            column[0].HeaderText = "ФИО";
            column[1].HeaderText = "Наименование организации";
            column[2].HeaderText = "Занимаемая должность";
            column[3].HeaderText = "Период работы в организации";
            column[4].HeaderText = "Общий трудовой стаж";
            data.Columns.AddRange(column);
            var book = new XLWorkbook(ConnectFile.XlPath);

            var lists = book.Worksheets;
            for (int i = 0; i <= y-a; i++)
            {
                data.Rows.Add();
            }
            foreach (var list in lists)
            {
                if (list.Name == "Спецпрактики")
                {
                    for (int i = a; i <= y; i++)
                    {
                        for (int j = 1; j <= n; j++)
                        {
                            data.Rows[i - a].Cells[j-1].Value = list.Cell(i, j+1).Value.ToString();
                        }
                    }
                    break;
                }
            }

        }
    }
}
