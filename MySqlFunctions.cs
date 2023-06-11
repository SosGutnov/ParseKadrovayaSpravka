﻿using MySql.Data.MySqlClient;
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

        public static void SetExtPractices(int id_employee, DateTime date_from, DateTime date_to, string organization, string position, int education)
        {
            string sql = "SELECT `id` FROM `external_practices` WHERE `empl_id`= @empl_id" +
                            " AND `date_from`= @date_from" +
                            " AND `date_to`= @date_to" +
                            " AND `organization`= @organization" +
                            " AND `position`= @position" +
                            " AND `education`= @education";
            MySqlCommand cmd1 = new MySqlCommand(sql, Form1.connection);
            cmd1.Parameters.Add("@empl_id", MySqlDbType.Int32).Value = id_employee;
            cmd1.Parameters.Add("@date_from", MySqlDbType.DateTime).Value = date_from;
            cmd1.Parameters.Add("@date_to", MySqlDbType.DateTime).Value = date_to;
            cmd1.Parameters.Add("@organization", MySqlDbType.VarChar).Value = organization;
            cmd1.Parameters.Add("@position", MySqlDbType.VarChar).Value = position;
            cmd1.Parameters.Add("@education", MySqlDbType.Int32).Value = education;

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
                sql = "INSERT INTO `external_practices` (`empl_id`, `date_from`, `date_to`, `organization`, `position`, `education`)"
                                         + " VALUES (@empl_id, @date_from, @date_to, @organization, @position, @education) ";
                MySqlCommand cmd2 = new MySqlCommand(sql, Form1.connection);

                cmd2.Parameters.Add("@empl_id", MySqlDbType.Int32).Value = id_employee;
                cmd2.Parameters.Add("@date_from", MySqlDbType.DateTime).Value = date_from;
                cmd2.Parameters.Add("@date_to", MySqlDbType.DateTime).Value = date_to;
                cmd2.Parameters.Add("@organization", MySqlDbType.VarChar).Value = organization;
                cmd2.Parameters.Add("@position", MySqlDbType.VarChar).Value = position;
                cmd2.Parameters.Add("@education", MySqlDbType.Int32).Value = education;

                cmd2.ExecuteNonQuery();

            }
        }
    }
}
