using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ParseKadrovayaSpravka
{
    internal class InsertDataExample
    {
        public static void InsertDataEmpl(List<string> fio)
        {
            // Получить соединение к базе данных.
            MySqlConnection connection = DBUtils.GetDBConnection();
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

        public static void InsertDataEmpl_Contracts(List<string> fio)
        {
            // Получить соединение к базе данных.
            MySqlConnection connection = DBUtils.GetDBConnection();
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
    }
}
