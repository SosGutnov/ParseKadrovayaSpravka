using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseKadrovayaSpravka
{
    internal class InsertTitles
    {
        public static void InsertTitl(List<string> fio, List<string> data) 
        {
            try
            {
                for (int i = 0; i < fio.Count; i++)
                {
                    string title = "";
                    int id_title = 0;
                    int id_employee = 0;
                    DateTime date = new DateTime();

                    id_employee = MySqlFunctions.GetEmployeesID(Form1.connection, fio[i].Split()[0], fio[i].Split()[1], fio[i].Split()[2]);

                    title = data[i].Split(',')[2].Trim();
                    if (title != "ученое звание отсутствует")
                    {
                        string sql = "SELECT `id` FROM `titles` WHERE `title` ='" + title + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, Form1.connection);
                        MySqlDataReader reader = cmd.ExecuteReader();

                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                id_title = Convert.ToInt32(reader.GetValue(0));
                            }
                        }
                        reader.Close();

                        sql = "SELECT `id` FROM `empl_titles`" +
                            " WHERE `employee_id`= '" + id_employee + "'" +
                            " AND `title_id`= '" + id_title + "'" +
                            " AND `date`= '" + date + "'";
                        MySqlCommand cmd1 = new MySqlCommand(sql, Form1.connection);

                        MySqlDataReader reader1 = cmd1.ExecuteReader();
                        if (reader1.HasRows)
                        {
                            while (reader1.Read())
                            {
                                int id_ = Convert.ToInt32(reader.GetValue(0));
                            }
                            reader1.Close();
                        }
                        else
                        {
                            reader1.Close();
                            sql = "INSERT INTO `empl_titles` (`employee_id`, `title_id`, `date`)"
                                                     + " VALUES (@employee_id, @title_id, @date) ";
                            MySqlCommand cmd2 = new MySqlCommand(sql, Form1.connection);

                            cmd2.Parameters.Add("@employee_id", MySqlDbType.Int32).Value = id_employee;
                            cmd2.Parameters.Add("@title_id", MySqlDbType.Int32).Value = id_title;
                            cmd2.Parameters.Add("@date", MySqlDbType.Date).Value = date;

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
