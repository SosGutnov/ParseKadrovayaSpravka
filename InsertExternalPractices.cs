using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseKadrovayaSpravka
{
    class InsertExternalPractices
    {
        public static void InsertExtP(List<string[]> data)
        {
            try
            {
                for (int i = 0; i < data.Count; i++)
                {
                    string fio = data[i][0];
                    string organization = data[i][1];
                    string position = data[i][2];
                    string date = data[i][3];

                    int id_employee = MySqlFunctions.GetEmployeesID(Form1.connection, fio.Split()[0], fio.Split()[1], fio.Split()[2]);
                    DateTime date_from;
                    DateTime date_to;
                    int education = Convert.ToInt32(data[i][4].Split()[0]);

                    if (!date.Contains("по"))
                    {
                        string[] temp = date.Split('-')[0].Split('.');
                        if (temp.Length != 3) date_from =new  DateTime(0,0,Convert.ToInt32(temp[0]));
                        else date_from = new DateTime(Convert.ToInt32(temp[2]), Convert.ToInt32(temp[1]), Convert.ToInt32(temp[0]));
                        if (date.Split('-')[1] == "настоящее время")
                        {
                            date_to = DateTime.Now;
                        }
                        else
                        {
                            temp = date.Split('-')[1].Split('.');
                            date_to = new DateTime(Convert.ToInt32(temp[2]), Convert.ToInt32(temp[1]), Convert.ToInt32(temp[0]));
                        }
                    }
                    else
                    {
                        string[] temp = date.Split(new string[1]{"по"}, StringSplitOptions.None);
                        temp[0] = temp[0].Trim('С').Trim();
                        temp[1] = temp[0].Trim();
                        string[] temp1 = temp[0].Split('.');
                        date_from = new DateTime(Convert.ToInt32(temp1[2]), Convert.ToInt32(temp1[1]), Convert.ToInt32(temp1[0]));
                        if (temp[1] == "настоящее время")
                        {
                            date_to = DateTime.Now;
                        }
                        else
                        {
                            temp = temp[1].Split('.');
                            date_to = new DateTime(Convert.ToInt32(temp[2]), Convert.ToInt32(temp[1]), Convert.ToInt32(temp[0]));
                        }
                    }

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
                Console.WriteLine("external_practice - good");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Выберите файл");
            }
            Console.Read();

        }
    }
}
