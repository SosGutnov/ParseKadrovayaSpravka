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
                        if (temp.Length != 3) date_from = new  DateTime(1, 1, Convert.ToInt32(temp[0]));
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

                    string[] organizations = organization.Split(new string[1] { "\n" }, StringSplitOptions.None);
                    int z = 0;
                    for (int j = 0; j < organizations.Length; j++)
                    {
                        string org = organizations[j];
                        string[] positions = position.Replace("\n\n", " ").Split();

                        if (positions.Length >= z + 1)
                        {
                            string pos = positions[z];
                            //MySqlFunctions.SetExtPractices(id_employee, date_from, date_to, org, pos, education);
                            z++;
                        }
                        if (positions.Length >= z + 1)
                        {
                            string pos = positions[z];
                            //MySqlFunctions.SetExtPractices(id_employee, date_from, date_to, org, pos, education);
                            z++;
                        }
                        
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
