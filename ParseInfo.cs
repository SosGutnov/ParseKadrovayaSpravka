using ClosedXML.Excel;
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
            //column[1].HeaderText = "Условия привлечения";
            column[1].HeaderText = "Должность, ученая степень, ученое звание";
            //column[3].HeaderText = "Уровень образования, наименование специальности, направления подготовки, наименование присвоенной квалификации";
            //column[4].HeaderText = "Сведения о дополнительном профессиональном образовании";
            //column[5].HeaderText = "Трудовой стаж работы в организациях, осуществляющих образовательную деятельность, на должностях педагогических (научно-педагогических) работников";
            //column[6].HeaderText = "Трудовой стаж работы в иных организациях, осуществляющих деятельность в профессиональной сфере, соответствующей профессиональной деятельности, к которой готовится выпускник";
            column[2].HeaderText = "Срок трудового договора или договора ГПХ, или Дата и номер  приказа об увольнении";
            column[3].HeaderText = "Избран по конкурсу ";
            data.Columns.AddRange(column);

            var book = new XLWorkbook(ConnectFile.XlPath);

            var lists = book.Worksheets;
            for (int i = 0; i <= y - a; i++)
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
            for (int i = 0; i <= y - a; i++)
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
                            data.Rows[i - a].Cells[j - 1].Value = list.Cell(i, j + 1).Value.ToString();
                        }
                    }
                    break;
                }
            }

        }

        public static void ParseAuditoriesInfo(DataGridView data)
        {
            int n = 2;
            int y = 27;
            int a = 2;
            data.Columns.Clear();
            DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[n];
            for (int i = 0; i < n; i++)
            {
                column[i] = new DataGridViewTextBoxColumn();
            }
            column[0].HeaderText = "Номер";
            column[1].HeaderText = "Описание";
            data.Columns.AddRange(column);
            var book = new XLWorkbook(ConnectFile.XlPath);

            var lists = book.Worksheets;
            for (int i = 0; i <= y - a; i++)
            {
                data.Rows.Add();
            }
            foreach (var list in lists)
            {
                if (list.Name == "Список аудиторий")
                {
                    for (int i = a; i <= y; i++)
                    {
                        for (int j = 0; j < n; j++)
                        {
                            data.Rows[i - a].Cells[j].Value = list.Cell(i, j + 1).Value.ToString();
                        }
                    }
                    break;
                }
            }

        }

        public static void ParseReferenceKO20_4(DataGridView data)
        {
            int n = 10;
            int y = 96;
            int a = 4;
            data.Columns.Clear();
            DataGridViewTextBoxColumn[] column = new DataGridViewTextBoxColumn[n];
            for (int i = 0; i < n; i++)
            {
                column[i] = new DataGridViewTextBoxColumn();
            }
            column[0].HeaderText = "Наименование учебных предметов";
            column[1].HeaderText = "Ф.И.О. педагогического (научно- педагогического) работника, участвующего в реализации образовательной программы";
            column[2].HeaderText = "Условия привлечения (по основному месту работы, на условиях внутреннего/ внешнего совместительства; на условиях договора гражданско- правового характера (далее - договор ГПХ)";
            column[3].HeaderText = "Должность, ученая степень, ученое звание";
            column[4].HeaderText = "Уровень образования, наименование специальности, направления подготовки, наименование присвоенной квалификации";
            column[5].HeaderText = "Сведения о дополнительном профессиональном образовании";
            column[6].HeaderText = "Объем учебной нагрузки, количество часов";
            column[7].HeaderText = "Объем учебной нагрузки, доля ставки";
            column[8].HeaderText = "Трудовой стаж работы, стаж работы в организациях, осуществляющих образовательную деятельность, на должностях педагогических (научно- педагогических) работников";
            column[9].HeaderText = "Трудовой стаж работы, стаж работы в иных организациях, осуществляющих деятельность в профессиональной сфере, соответствующей профессиональной деятельности, к которой готовится выпускник";


            data.Columns.AddRange(column);
            var book = new XLWorkbook(ConnectFile.XlPath);

            var lists = book.Worksheets;
            for (int i = 0; i <= y - a; i++)
            {
                data.Rows.Add();
            }
            foreach (var list in lists)
            {
                if (list.Name == "Справка КО 20-4")
                {
                    MessageBox.Show(list.Cell(3, 9).Value.ToString());
                    var last = "";
                    for (int i = a; i <= y; i++)
                    {
                        for (int j = 1; j < n; j++)
                        {
                            if (list.Cell(i, j + 1).IsEmpty() && j == 0)
                            {
                                data.Rows[i - a].Cells[j - 1].Value = last;
                            }
                            else
                            {
                                data.Rows[i - a].Cells[j - 1].Value = list.Cell(i, j + 1).Value.ToString();
                                if (j == 1)
                                {
                                    last = list.Cell(i, j + 1).Value.ToString();
                                }
                            }
                        }
                    }
                    break;
                }
            }

        }
    }
}
