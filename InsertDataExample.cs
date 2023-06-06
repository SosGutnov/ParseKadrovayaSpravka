using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace ParseKadrovayaSpravka
{
    internal class InsertDataExample
    {
        private static MySqlConnection connection = DBUtils.GetDBConnection();

        public static void InsertDataEmpl(List<string> fio)
        {
            // Получить соединение к базе данных.
            connection.Open();
            try
            {
                foreach (var item in fio)
                {
                    string sql = "Insert into employees (surname, name, patronimyc) "
                                                     + " values (@surname, @name, @patronimyc) ";

                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = sql;

                    cmd.Parameters.Add("@surname", MySqlDbType.VarChar).Value = item.Split()[0];
                    cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = item.Split()[1];
                    cmd.Parameters.Add("@patronimyc", MySqlDbType.VarChar).Value = item.Split()[2];

                    // Выполнить Command (использованная для  delete, insert, update).
                    int rowCount = cmd.ExecuteNonQuery();

                    Console.WriteLine("Row Count affected = " + rowCount);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Выберите файл");
            }
            Console.Read();

        }

        public static void InsertDataEmpl_Degrees(List<string> fio, List<string> degrees)
        {
            // Получить соединение к базе данных.
            connection.Open();
            try
            {
                for (int i = 0; i < fio.Count; i++)
                {
                    string sql = "";

                    string empl_d = degrees[i].Split(',')[1].Trim();

                    string empl_d_t = "";
                    string empl_d_st = "";

                    if (empl_d == "ученая степень отсутствует") empl_d_t = "-";
                    else if (empl_d == "канд. физ.-мат. наук")
                    {
                        empl_d_t = "кандидат физико-математических наук";
                        empl_d_st = "к.ф.-м.н.";
                    }
                    else if (empl_d == "докт. физ.-мат. наук" || empl_d == "док. физ.-мат. наук" || empl_d == "доктор физико-математических наук" || empl_d == "д. ф.-м. н.")
                    {
                        empl_d_t = "доктор физико-математических наук";
                        empl_d_st = "д.ф.-м.н.";
                    }
                    else
                    {
                        sql = "SELECT `id` FROM `degrees` WHERE `title`= '" + empl_d_t + "'";
                        MySqlCommand cmd4 = new MySqlCommand(sql, connection);

                        MySqlDataReader reader = cmd4.ExecuteReader();

                        if (!reader.Read())
                        {
                            sql = "Insert into degrees (title) "
                                                     + " values (@title) ";
                            MySqlCommand cmd2 = new MySqlCommand(sql, connection);
                            cmd2.Parameters.Add("@title", MySqlDbType.VarChar).Value = empl_d_t;
                        }

                    }

                    sql = "SELECT `id` FROM `employees` WHERE `surname`= '" + fio[i].Split()[0] + "' AND `name`= '"
                                    + fio[i].Split()[1] + "' AND `patronimyc`= '" + fio[i].Split()[2] + "'";
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    var id_employees = Convert.ToInt32(cmd.ExecuteScalar());
                    Console.WriteLine(id_employees);

                    var id_degrees = 0;
                    if (empl_d_t == "-")
                    {
                        id_degrees = 0;
                    }
                    else
                    {
                        sql = "SELECT `id` FROM `degrees` WHERE `title`= '" + empl_d_t + "'";
                        MySqlCommand cmd2 = connection.CreateCommand();
                        cmd2.CommandText = sql;
                        id_degrees = Convert.ToInt32(cmd2.ExecuteScalar());
                        Console.WriteLine(id_degrees);
                    }


                    sql = "Insert into empl_degrees (employee_id, spec_id, degree_id, date) "
                                                     + " values (@employee_id, @spec_id, @degree_id, @date) ";
                    MySqlCommand cmd3 = new MySqlCommand(sql, connection);
                    cmd3.CommandText = sql;
                    cmd3.Parameters.Add("@employee_id", MySqlDbType.Int32).Value = id_employees;
                    cmd3.Parameters.Add("@spec_id", MySqlDbType.Int32).Value = 0;
                    cmd3.Parameters.Add("@degree_id", MySqlDbType.Int32).Value = id_degrees;
                    cmd3.Parameters.Add("@date", MySqlDbType.Date).Value = "0000-00-00";
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Выберите файл");
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }

            Console.Read();

        }
    }
}
