using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParseKadrovayaSpravka
{
    internal class InsertDataExample
    {
        public static void InsertData()
        {

            // Получить соединение к базе данных.
            MySqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            try
            {
                // Команда Insert.
                string sql = "Insert into employees (surname, name, patronimyc) "
                                                 + " values (@surname, @name, @patronimyc) ";

                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;

                cmd.Parameters.Add("@surname", MySqlDbType.VarChar).Value = "Гутнова";
                cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = "Алина";
                cmd.Parameters.Add("@patronimyc", MySqlDbType.VarChar).Value = "Казбековна";

                // Выполнить Command (использованная для  delete, insert, update).
                int rowCount = cmd.ExecuteNonQuery();

                Console.WriteLine("Row Count affected = " + rowCount);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
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
