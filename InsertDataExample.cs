using DocumentFormat.OpenXml.Office.Word;
using DocumentFormat.OpenXml.Wordprocessing;
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
        public static void InsertDataEmpl(List<string> fio)
        {
            try
            {
                foreach (var item in fio)
                {

                    string sql = "SELECT `id` FROM `employees` WHERE `surname`= '" + item.Split()[0] + "' AND `name`= '"
                                    + item.Split()[1] + "' AND `patronimyc`= '" + item.Split()[2] + "'";

                    MySqlCommand cmd = new MySqlCommand(sql, Form1.connection);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        reader.Close();
                        sql = "Insert into employees (surname, name, patronimyc) "
                                                     + " values (@surname, @name, @patronimyc) ";
                        MySqlCommand cmd1 = Form1.connection.CreateCommand();
                        cmd1.CommandText = sql;

                        cmd1.Parameters.Add("@surname", MySqlDbType.VarChar).Value = item.Split()[0];
                        cmd1.Parameters.Add("@name", MySqlDbType.VarChar).Value = item.Split()[1];  
                        cmd1.Parameters.Add("@patronimyc", MySqlDbType.VarChar).Value = item.Split()[2];

                        // Выполнить Command (использованная для  delete, insert, update).
                        int rowCount = cmd1.ExecuteNonQuery();
                    }
                    reader.Close();
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
                    int id_spec = 0;

                    if (ReferenceData.EmployeeDegrees.ContainsKey(empl_d))
                    {
                        empl_d_t = ReferenceData.EmployeeDegrees[empl_d].Item1;
                        empl_d_st = ReferenceData.EmployeeDegrees[empl_d].Item2;

                        sql = "SELECT `id` FROM `degrees` WHERE `title`= '" + empl_d_t + "'";
                        MySqlCommand cmd = new MySqlCommand(sql, Form1.connection);

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
                            MySqlCommand cmd1 = new MySqlCommand(sql, Form1.connection);
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

                    id_employees = MySqlFunctions.GetEmployeesID(Form1.connection, fio[i].Split()[0], fio[i].Split()[1], fio[i].Split()[2]);
                    Console.WriteLine(id_employees);

                    sql = "SELECT `employee_id` FROM `empl_degrees`";
                    MySqlCommand cmd3 = new MySqlCommand(sql, Form1.connection);
                    MySqlDataReader reader2 = cmd3.ExecuteReader();
                    bool cont = false;
                    if (reader2.HasRows)
                    {
                        while (reader2.Read())
                        {
                            if (Convert.ToInt32(reader2.GetValue(0)) == id_employees)
                            {
                                cont = true;
                            }
                        }

                        reader2.Close();
                    }
                    if (!cont)
                    {
                        reader2.Close();
                        sql = "INSERT INTO `empl_degrees` (`employee_id`, `spec_id`, `degree_id`, `date`)"
                                                         + " VALUES (@employee_id, @spec_id, @degree_id, @date) ";
                        MySqlCommand cmd4 = new MySqlCommand(sql, Form1.connection);

                        cmd4.Parameters.Add("@employee_id", MySqlDbType.Int32).Value = id_employees;
                        cmd4.Parameters.Add("@spec_id", MySqlDbType.Int32).Value = id_spec;
                        cmd4.Parameters.Add("@degree_id", MySqlDbType.Int32).Value = id_degrees;
                        cmd4.Parameters.Add("@date", MySqlDbType.Date).Value = new System.DateTime();

                        cmd4.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Выберите файл");
            }
            /*finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }*/

            Console.Read();

        }
    }
}
