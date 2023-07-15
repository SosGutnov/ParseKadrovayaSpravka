using MySql.Data.MySqlClient;
using ParseKadrovayaSpravka.models;
using System;

namespace ParseKadrovayaSpravka
{
    class InsertReferenceTables
    {
        //subject_forms
        //loads
        public static void InsertLoads(Load load)
        {
            int department_id = InsertEmpl_load.GetIdDepartment(load.Department);
            string sql = "SELECT `id` FROM `loads`" +
                            " WHERE `current_year`= '" + load.Current_year + "'" +
                            " AND `department_id`= '" + department_id + "'";
            MySqlCommand cmd1 = new MySqlCommand(sql, MainForm.connection);

            MySqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    int id_ = Convert.ToInt32(reader1.GetValue(0));
                }
                reader1.Close();
            }
            else
            {
                reader1.Close();
                sql = "INSERT INTO `loads` (`current_year`, `department_id`)"
                                         + " VALUES (@current_year, @department_id) ";
                MySqlCommand cmd2 = new MySqlCommand(sql, MainForm.connection);

                cmd2.Parameters.Add("@current_year", MySqlDbType.Int32).Value = load.Current_year;
                cmd2.Parameters.Add("@department_id", MySqlDbType.Int32).Value = department_id;

                cmd2.ExecuteNonQuery();
            }
            reader1.Close();
        }

        public static void InsertSubjectForms(string subject_form)
        {
            string sql = "SELECT `id` FROM `subject_forms`" +
                        " WHERE `title`= '" + subject_form + "'";
            MySqlCommand cmd1 = new MySqlCommand(sql, MainForm.connection);

            MySqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    int id_ = Convert.ToInt32(reader1.GetValue(0));
                }
                reader1.Close();
            }
            else
            {
                reader1.Close();
                sql = "INSERT INTO `subject_forms` (`title`)"
                                         + " VALUES (@title) ";
                MySqlCommand cmd2 = new MySqlCommand(sql, MainForm.connection);

                cmd2.Parameters.Add("@title", MySqlDbType.VarChar).Value = subject_form;

                cmd2.ExecuteNonQuery();
            }
            reader1.Close();
        }
    }
}
