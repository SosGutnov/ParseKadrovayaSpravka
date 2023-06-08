using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ParseKadrovayaSpravka
{
    internal class InsertEducation
    {
        public static void InsertEdu1(List<string> fio, List<string> data)
        {
            try
            {
                string[] sep = { "специальность", "квалификация", "направление подготовки" };
                for (int i = 0; i < fio.Count(); i++)
                {
                    string edu_lvl = "";
                    int id_employee = 0;
                    int id_edu_lvl = 0;
                    string spec = "";
                    string qf = "";
                    DateTime date = new DateTime();
                    string serial = "";

                    string[] a = data[i].Split(';');
                    if (a[0] == "")
                    {
                        break;
                    }
                    for (int j = 0; j < a.Length; j++)
                    {
                        edu_lvl = a[0].Split(',')[0];
                        List<string> spc = new List<string>();
                        List<string> qfs = new List<string>();
                        string[] temp = a[j].Split(sep, StringSplitOptions.None);
                        for (int z = 0; z < temp.Length; z++)
                        {
                            temp[z] = temp[z].Trim();
                            temp[z] = temp[z].Trim(',');
                            temp[z] = temp[z].Trim();
                            temp[z] = temp[z].Replace("-", "");
                            temp[z] = temp[z].Replace("–", "");//другой знак(
                            temp[z] = temp[z].Replace("—", "");//другой знак(
                            temp[z] = temp[z].Trim();
                        }
                        edu_lvl = temp[0];
                        spc.AddRange(temp[1].Split(','));
                        qfs.AddRange(temp[2].Split(','));

                        if (edu_lvl == "Высшее") edu_lvl = "специалитет";
                        InsertEdu2(fio[i], edu_lvl, spc, qfs);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Выберите файл");
            }
        }

        public static void InsertEdu2(string fio, string edu_lvl, List<string> spc, List<string> qfs)
        {
            try
            {
                int id_employee = 0;
                int id_edu_lvl = 0;
                string spec = "";
                string qf = "";
                DateTime date = new DateTime();
                string serial = "";

                id_employee = MySqlFunctions.GetEmployeesID(Form1.connection, fio.Split()[0], fio.Split()[1], fio.Split()[2]);

                string sql = "SELECT `id` FROM `edu_levels` WHERE `title`= '" + edu_lvl + "'";
                MySqlCommand cmd = new MySqlCommand(sql, Form1.connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id_edu_lvl = Convert.ToInt32(reader.GetValue(0));
                    }
                }
                reader.Close();

                for (int j = 0; j < qfs.Count; j++)
                {
                    qf = qfs[j].Trim();
                    if (qf == "")
                    {
                        break;
                    }
                    for (int k = 0; k < spc.Count; k++)
                    {
                        spec = spc[k].Trim();

                        sql = "SELECT `id` FROM `empl_education` WHERE `employee_id`= '" + id_employee + "'" +
                            " AND `edu_level_id`= '" + id_edu_lvl + "'" +
                            " AND `speciality`= '" + spec + "'" +
                            " AND `qualification`= '" + qf + "'";
                        MySqlCommand cmd1 = new MySqlCommand(sql, Form1.connection);

                        MySqlDataReader reader1 = cmd1.ExecuteReader();
                        if (reader1.HasRows)
                        {
                            while (reader1.Read())
                            {
                            }
                            reader1.Close();
                        }
                        else
                        {
                            reader1.Close();
                            sql = "INSERT INTO `empl_education` (`employee_id`, `edu_level_id`, `speciality`, `qualification`, `date`, `serial`)"
                                                     + " VALUES (@employee_id, @edu_level_id, @speciality, @qualification, @date, @serial) ";
                            MySqlCommand cmd2 = new MySqlCommand(sql, Form1.connection);

                            cmd2.Parameters.Add("@employee_id", MySqlDbType.Int32).Value = id_employee;
                            cmd2.Parameters.Add("@edu_level_id", MySqlDbType.Int32).Value = id_edu_lvl;
                            cmd2.Parameters.Add("@speciality", MySqlDbType.VarChar).Value = spec;
                            cmd2.Parameters.Add("@qualification", MySqlDbType.VarChar).Value = qf;
                            cmd2.Parameters.Add("@date", MySqlDbType.Date).Value = date;
                            cmd2.Parameters.Add("@serial", MySqlDbType.VarChar).Value = serial;

                            cmd2.ExecuteNonQuery();
                        }
                    }
                }



            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Выберите файл");
            }
        }
    }
}
