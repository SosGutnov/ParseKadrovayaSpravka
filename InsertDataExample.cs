using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
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

                    if (empl_d == "ученая степень отсутствует") empl_d = "";
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
                        empl_d = "";//??
                    }


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
