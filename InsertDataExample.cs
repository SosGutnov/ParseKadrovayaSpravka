using MySql.Data.MySqlClient;
using ParseKadrovayaSpravka.Справочные_данные;
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

                    int id_degrees = 0;
                    int id_employees = 0;

                    if (ReferenceData.EmployeeDegrees.ContainsKey(empl_d))
                    {
                        empl_d_t = ReferenceData.EmployeeDegrees[empl_d].Item1;
                        empl_d_st = ReferenceData.EmployeeDegrees[empl_d].Item2;

                        sql = "SELECT `id` FROM `degrees` WHERE `title`= '" + empl_d_t + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, connection);

                        MySqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                id_degrees = Convert.ToInt32(reader.GetValue(0));
                            }
                            reader.Close();
                        }
                        else
                        {
                            reader.Close();
                            sql = "Insert into degrees (title, short_title) values (@title, @short_title) ";
                            MySqlCommand cmd1 = new MySqlCommand(sql, connection);
                            cmd1.Parameters.Add("@title", MySqlDbType.VarChar).Value = empl_d_t;
                            cmd1.Parameters.Add("@short_title", MySqlDbType.VarChar).Value = empl_d_st;

                            int rowCount = cmd1.ExecuteNonQuery();
                            id_degrees = Convert.ToInt32(cmd1.LastInsertedId);
                        }
                    }
                    else
                    {
                        //empl_d_t = empl_d;
                    }
                    
                    /*sql = "SELECT `id` FROM `employees` WHERE `surname`= '" + fio[i].Split()[0] + "' AND `name`= '"
                                    + fio[i].Split()[1] + "' AND `patronimyc`= '" + fio[i].Split()[2] + "'";
                    MySqlCommand cmd2 = new MySqlCommand(sql, connection);
                    id_employees = Convert.ToInt32(cmd2.ExecuteScalar());
                    Console.WriteLine(id_employees);

                    sql = "Insert into empl_degrees (employee_id, degree_id) "
                                                     + " values (@employee_id, @degree_id) ";
                    MySqlCommand cmd3 = new MySqlCommand(sql, connection);
                    cmd3.CommandText = sql;
                    cmd3.Parameters.Add("@employee_id", MySqlDbType.Int32).Value = id_employees;
                    cmd3.Parameters.Add("@degree_id", MySqlDbType.Int32).Value = id_degrees;
                    */
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
