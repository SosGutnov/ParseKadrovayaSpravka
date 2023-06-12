using System;
using System.Collections.Generic;

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
                    string fio = data[i][0].Trim();
                    string organization = data[i][1].Trim();
                    string position = data[i][2].Trim();
                    string date = data[i][3].Trim();

                    int id_employee = MySqlFunctions.GetEmployeesID(Form1.connection, fio.Split()[0], fio.Split()[1], fio.Split()[2]);
                    int education = Convert.ToInt32(data[i][4].Split()[0]);


                    string[] organizations = organization.Split(new string[1] { "\n\n" }, StringSplitOptions.None);
                    int z = 0;
                    for (int j = 0; j < organizations.Length; j++)
                    {
                        string org = organizations[j];
                        string[] positions = position.Split(new string[1] { "\n\n" }, StringSplitOptions.None);
                        string[] dates = date.Split(new string[1] { "\n\n\n" }, StringSplitOptions.None);

                        if (positions.Length >= z + 1)
                        {
                            string pos = positions[z];
                            MySqlFunctions.SetExtPractices(id_employee, dates[z], org, pos, education);
                            z++;
                        }
                        if (positions.Length >= z + 1)
                        {
                            string pos = positions[z];
                            MySqlFunctions.SetExtPractices(id_employee, dates[z], org, pos, education);
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
