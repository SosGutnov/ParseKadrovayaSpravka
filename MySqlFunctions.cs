using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseKadrovayaSpravka
{
    internal class MySqlFunctions
    {
        public static int GetEmployeesID(MySqlConnection connection, string surname, string name, string patronimyc)
        {
            int id = 0;

            string sql = "SELECT `id` FROM `employees` WHERE `surname`= '" + surname + "' AND `name`= '"
                                    + name + "' AND `patronimyc`= '" + patronimyc + "'";

            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader.GetValue(0));
                }
            }
            reader.Close();
            return id;
        }
    }
}
