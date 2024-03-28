using Aspose.Cells;
using ClosedXML.Excel;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using ParseKadrovayaSpravka.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace ParseKadrovayaSpravka
{
    class ParseInfo
    {
        public static List<string> fio = new List<string>();
        public static List<string> degrees = new List<string>();
        public static List<string> for_education = new List<string>();
        public static List<string[]> external_practice = new List<string[]>();
        public static List<Load_temp> Listloads;

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
            column[7].HeaderText = "Срок трудового договора или договора ГПХ, или Дата и номер  приказа об увольнении";
            column[8].HeaderText = "Избран по конкурсу ";
            data.Columns.AddRange(column);

            var book = new XLWorkbook(ConnectXMLfile.XlPath[0]);
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
                        fio.Add(data.Rows[i - a].Cells[0].Value.ToString());
                        degrees.Add(data.Rows[i - a].Cells[2].Value.ToString());
                        for_education.Add(data.Rows[i - a].Cells[3].Value.ToString());
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
            var book = new XLWorkbook(ConnectXMLfile.XlPath[0]);

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
                        external_practice.Add(
                            new string[5] { data.Rows[i - a].Cells[0].Value.ToString(),
                            data.Rows[i - a].Cells[1].Value.ToString(),
                            data.Rows[i - a].Cells[2].Value.ToString(),
                            data.Rows[i - a].Cells[3].Value.ToString(),
                            data.Rows[i - a].Cells[4].Value.ToString()});
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
            var book = new XLWorkbook(ConnectXMLfile.XlPath[0]);

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
            var book = new XLWorkbook(ConnectXMLfile.XlPath[0]);

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

        public static void ParseLoads(ProgressBar progressBar)
        {
            try
            {
                Console.WriteLine("Загрузка файла - начало");

                string path = ConnectXMLfile.XlPath[0]; // файл нагрузок

                Workbook wb = new Workbook(path);
                Listloads = new List<Load_temp>();

                progressBar.Value = 0;
                progressBar.Minimum = 0;
                progressBar.Step = 1;
                progressBar.Maximum = wb.Worksheets.Count - 4; // Полоска прогресса по количеству спарсенных листов

                for (int i = 4; i < wb.Worksheets.Count; i++)
                {
                    var sheet = wb.Worksheets[i];
                    //System.Console.WriteLine(sheet.Cells.MaxDataRow);
                    for (int j = 1; j <= sheet.Cells.MaxDataRow; j++)
                    {
                        Department dep = new Department(sheet.Cells[j, 20].Value.ToString(), sheet.Cells[j, 19].Value.ToString());
                        Load load = new Load(int.Parse(sheet.Cells[j, 25].Value.ToString()), dep);
                        string[] emp = sheet.Cells[j, 11].Value.ToString().Replace("  ", " ").Split();
                        if (sheet.Cells[j, 11].Value.ToString().Contains("Вакансия"))
                        {
                            break;
                        }
                        Employee empl = new Employee(emp[0], emp[1][0].ToString(), emp[1][2].ToString());

                        int semester = int.Parse(sheet.Cells[j, 6].Value.ToString());
                        int hourly_fund = 0;

                        string subject = sheet.Cells[j, 3].Value.ToString();
                        string subject_form = sheet.Cells[j, 8].Value.ToString();
                        double hours_other = 0;
                        double hours_contact = 0;

                        if (sheet.Cells[j, 11].Value.ToString().Contains("поч"))
                        {
                            hourly_fund = 1;
                        }

                        if (subject_form == "Экзамен" || subject_form == "Зачет" || subject_form.Contains("Консульт")
                            || subject_form == "Курсовая работа" || subject_form.Contains("Практические")
                            || subject_form == "Лабораторная" || subject_form.Contains("практика"))
                        {
                            hours_other = Convert.ToDouble(sheet.Cells[j, 13].Value.ToString());
                        }
                        else
                        {
                            hours_contact = Convert.ToDouble(sheet.Cells[j, 13].Value.ToString());
                        }
                        if (sheet.Cells[j, 31].Value == null)
                        {
                            break;
                        }
                        string spec_title = GetSpecTitle(sheet.Cells[j, 31].Value.ToString().Split());
                        //Console.WriteLine(spec_title + " " + sheet.Cells[j, 21].Value.ToString());
                        Speciality spec = new Speciality(spec_title, sheet.Cells[j, 21].Value.ToString());
                        Title_plan title_plan = new Title_plan(spec, int.Parse(sheet.Cells[j, 24].Value.ToString()));
                        Group group = new Group(sheet.Cells[j, 18].Value.ToString(), 0, int.Parse(sheet.Cells[j, 24].Value.ToString()), spec);
                        Edu_plan edu_plan = new Edu_plan(subject, title_plan);
                        Edu_semester edu_sem = new Edu_semester(edu_plan, semester);

                        Load_temp loaaad = new Load_temp(load, empl, semester, hourly_fund, edu_sem, group, subject, subject_form, hours_other, hours_contact);
                        Listloads.Add(loaaad);

                        
                    }
                    progressBar.PerformStep();
                }
                Console.WriteLine("Загрузка файла - конец");

                /*if (true)
                {
                    foreach (var load in Listloads)
                    {
                        InsertReferenceTables.InsertLoads(load.Load);
                        InsertReferenceTables.InsertSubjectForms(load.Subject_form);
                        InsertReferenceTables.InsertGroups(load.Group);
                    }
                    System.Console.WriteLine("loads - OK");
                    System.Console.WriteLine("groups - OK");
                    foreach (var load in Listloads)
                    {
                        InsertEmpl_load.Insert(load);
                    }
                    System.Console.WriteLine("empl_loads - OK");
                }
                /*Department dep = new Department("Кафедра прикладной математики и информатики", "Факультет математики и компьютерных наук");
                Load load = new Load(2022, dep);

                Employee empl = new Employee("Циунчик","С","А");

                Subject sb = new Subject(0, "ИВТ(б)-21-1-ОФО", "Современные языки программирования", "Лабораторная", 36, 0);
                Subject sb1 = new Subject(0, "ИВТ(б)-21-1-ОФО", "Современные языки программирования", "Лекция", 36, 0);

                List<Subject> listsb = new List<Subject>();
                listsb.Add(sb);
                listsb.Add(sb1);

                Semester sem = new Semester(1, listsb);
                Semester sem1 = new Semester(2, listsb);

                List<Semester> listsm = new List<Semester>();
                listsm.Add(sem);
                listsm.Add(sem1);

                Empl_load empl_load = new Empl_load(load, empl, listsm);

                JsonSerializer serializer = new JsonSerializer();

                using (StreamWriter sw = new StreamWriter("loads1.json"))
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, empl_load);
                }*/
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Выберите файл");
            }
        }

        public static string GetSpecTitle(string[] s)
        {
            string r = "";
            for (int i = 2; i < s.Length; i++)
            {
                r += s[i] + " ";
            }
            return r.Trim();
        }
    }
}
