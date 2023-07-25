using MySql.Data.MySqlClient;
using ParseKadrovayaSpravka.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseKadrovayaSpravka
{
    class InsertEmpl_load
    {
        public static void Insert(Load_temp empl_load)
        {
            try
            {
                int load_id = GetIdLoad(empl_load.Load);
                int empl_id = GetIdEmployee(empl_load.Empl);
                int subject_form_id = GetIdSubjectForm(empl_load.Subject_form);
                int group_id = GetIdGroup(empl_load.Group);
                int edu_sem_id = GetIdEdu_semester(empl_load.Edu_semester);

                string sql = "SELECT `id` FROM `empl_loads`" +
                                " WHERE `load_id`=@load_id" +
                                " AND `semester`=@semester" +
                                " AND `employee_id`=@employee_id" +
                                " AND `hourly_fund`=@hourly_fund" +
                                " AND `subject`=@subject" +
                                " AND `edu_semester_id`=@edu_sem_id" +
                                " AND `group_id`=@group_id" +
                                " AND `subject_form_id`=@subject_form_id" +
                                " AND `hours_other`=@hours_other" +
                                " AND `hours_contact`=@hours_contact";
                MySqlCommand cmd1 = new MySqlCommand(sql, MainForm.connection);
                cmd1.Parameters.Add("@load_id", MySqlDbType.Int32).Value = load_id;
                cmd1.Parameters.Add("@semester", MySqlDbType.Int32).Value = empl_load.Semester;
                cmd1.Parameters.Add("@employee_id", MySqlDbType.Int32).Value = empl_id;
                cmd1.Parameters.Add("@hourly_fund", MySqlDbType.Int32).Value = empl_load.hourly_fund;
                cmd1.Parameters.Add("@edu_sem_id", MySqlDbType.Int32).Value = edu_sem_id;
                cmd1.Parameters.Add("@subject", MySqlDbType.VarChar).Value = empl_load.Subject;
                cmd1.Parameters.Add("@group_id", MySqlDbType.Int32).Value = group_id;
                cmd1.Parameters.Add("@subject_form_id", MySqlDbType.Int32).Value = subject_form_id;
                cmd1.Parameters.Add("@hours_other", MySqlDbType.Decimal).Value = empl_load.Hours_other;
                cmd1.Parameters.Add("@hours_contact", MySqlDbType.Decimal).Value = empl_load.Hours_contact;

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
                    sql = "INSERT INTO `empl_loads` (`load_id`, `semester`, `employee_id`, `hourly_fund`, `subject`, `group_id`, `subject_form_id`, `hours_other`, `hours_contact`)"
                                             + " VALUES (@load_id, @semester, @employee_id, @hourly_fund, @subject, @group_id, @subject_form_id, @hours_other, @hours_contact) ";
                    MySqlCommand cmd2 = new MySqlCommand(sql, MainForm.connection);

                    cmd2.Parameters.Add("@load_id", MySqlDbType.Int32).Value = load_id;
                    cmd2.Parameters.Add("@semester", MySqlDbType.Int32).Value = empl_load.Semester;
                    cmd2.Parameters.Add("@employee_id", MySqlDbType.Int32).Value = empl_id;
                    cmd2.Parameters.Add("@hourly_fund", MySqlDbType.Int32).Value = empl_load.hourly_fund;
                    cmd2.Parameters.Add("@subject", MySqlDbType.VarChar).Value = empl_load.Subject;
                    cmd2.Parameters.Add("@group_id", MySqlDbType.Int32).Value = group_id;
                    cmd2.Parameters.Add("@subject_form_id", MySqlDbType.Int32).Value = subject_form_id;
                    cmd2.Parameters.Add("@hours_other", MySqlDbType.Decimal).Value = empl_load.Hours_other;
                    cmd2.Parameters.Add("@hours_contact", MySqlDbType.Decimal).Value = empl_load.Hours_contact;

                    cmd2.ExecuteNonQuery();
                }
                reader1.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Выберите файл");
            }
        }

        public static int GetIdLoad(Load load)
        {
            int id = 0;
            try
            {
                int department_id = GetIdDepartment(load.Department);
                string sql = "SELECT `id` FROM `loads` WHERE `current_year`= '" + load.Current_year + "' AND `department_id`= '" + department_id + "'";

                MySqlCommand cmd = new MySqlCommand(sql, MainForm.connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader.GetValue(0));
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Выберите файл");
            }
            return id;
        }

        public static int GetIdEmployee(Employee empl)
        {
            int id = 0;
            try
            {
                string sql = "SELECT `id` FROM `employees` WHERE `surname`= '" + empl.Surname + "' AND LEFT(`name`, 1)= '"
                                    + empl.Name + "' AND LEFT(`patronimyc`, 1)= '" + empl.Patronimyc + "'";

                MySqlCommand cmd = new MySqlCommand(sql, MainForm.connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader.GetValue(0));
                    }
                }
                reader.Close();

                if (id == 0)
                {
                    Console.WriteLine("Парсинг нагрузок. Преподаватель не найден." + empl.Surname + " " + empl.Name + " " + empl.Patronimyc);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Выберите файл");
            }
            
            return id;
        }

        public static int GetIdSubjectForm(string subject_form)
        {
            int id = 0;
            try
            {
                string sql = "SELECT `id` FROM `subject_forms` WHERE `title`= '" + subject_form + "'";

                MySqlCommand cmd = new MySqlCommand(sql, MainForm.connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader.GetValue(0));
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Выберите файл");
            }

            return id;
        }

        public static int GetIdGroup(Group group)
        {
            int id = 0;
            try
            {
                int spec_id = GetIdSpeciality(group.Speciality);
                string sql = "SELECT `id` FROM `groups` WHERE `title`= '" + group.Title + "' AND `year`= '" + group.Year + "' AND `speciality_id`= '" + spec_id + "'";

                MySqlCommand cmd = new MySqlCommand(sql, MainForm.connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader.GetValue(0));
                    }
                }
                reader.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Выберите файл");
            }

            return id;
        }

        public static int GetIdDepartment(Department dep)
        {
            int id = 0;
            try
            {
                int faculty_id = GetIdFaculties(dep.Faculty);
                string sql = "SELECT `id` FROM `departments` WHERE `faculty_id`= '" + faculty_id + "' AND `title`= '" + dep.Title + "'";

                MySqlCommand cmd = new MySqlCommand(sql, MainForm.connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader.GetValue(0));
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Выберите файл");
            }

            return id;
        }

        public static int GetIdFaculties(string faculty)
        {

            int id = 0;
            try
            {
                string sql = "SELECT `id` FROM `faculties` WHERE `title`= '" + faculty + "'";

                MySqlCommand cmd = new MySqlCommand(sql, MainForm.connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader.GetValue(0));
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Выберите файл");
            }
            return id;
        }

        public static int GetIdSpeciality(Speciality speciality)
        {
            int id = 0;
            try
            {
                string sql = "SELECT `id` FROM `speciality` WHERE `title`= @title AND `code`=@code";

                MySqlCommand cmd = new MySqlCommand(sql, MainForm.connection);
                cmd.Parameters.Add("@title", MySqlDbType.VarChar).Value = speciality.Title;
                cmd.Parameters.Add("@code", MySqlDbType.VarChar).Value = speciality.Code;
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader.GetValue(0));
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Выберите файл");
            }
            return id;
        }

        public static int GetIdTitle_plan(Title_plan title_plan)
        {
            int id = 0;
            try
            {
                int spec_id = GetIdSpeciality(title_plan.Spec);
                string sql = "SELECT `id` FROM `title_plan` WHERE `spec_id`= @spec_id AND `date_enter` = @date_enter";

                MySqlCommand cmd = new MySqlCommand(sql, MainForm.connection);
                cmd.Parameters.Add("@spec_id", MySqlDbType.Int32).Value = spec_id;
                cmd.Parameters.Add("@date_enter", MySqlDbType.Year).Value = title_plan.Date_enter;
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader.GetValue(0));
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Выберите файл");
            }
            return id;
        }

        public static int GetIdSubject(string subject)
        {

            int id = 0;
            try
            {
                string sql = "SELECT `id` FROM `subjects` WHERE `title`= '" + subject + "'";

                MySqlCommand cmd = new MySqlCommand(sql, MainForm.connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader.GetValue(0));
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Выберите файл");
            }
            return id;
        }

        public static int GetIdEdu_plan(Edu_plan edu_plan)
        {
            int id = 0;
            try
            {
                int subject_id = GetIdSubject(edu_plan.Subject);
                int title_plan_id = GetIdTitle_plan(edu_plan.Title_plan);
                string sql = "SELECT `id` FROM `edu_plan` WHERE `subject_id`= @subject_id AND `title_plan_id` = @title_plan_id";

                MySqlCommand cmd = new MySqlCommand(sql, MainForm.connection);
                cmd.Parameters.Add("@subject_id", MySqlDbType.Int32).Value = subject_id;
                cmd.Parameters.Add("@title_plan_id", MySqlDbType.Int32).Value = title_plan_id;
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader.GetValue(0));
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Выберите файл");
            }
            return id;
        }

        public static int GetIdEdu_semester(Edu_semester edu_semester)
        {
            int id = 0;
            try
            {
                int edu_plan_id = GetIdEdu_plan(edu_semester.Edu_plan);
                string sql = "SELECT `id` FROM `edu_semesters` WHERE `edu_plan_id`= @edu_plan_id AND `semester` = @semester";

                MySqlCommand cmd = new MySqlCommand(sql, MainForm.connection);
                cmd.Parameters.Add("@edu_plan_id", MySqlDbType.Int32).Value = edu_plan_id;
                cmd.Parameters.Add("@semester", MySqlDbType.Int32).Value = edu_semester.Semester;
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        id = Convert.ToInt32(reader.GetValue(0));
                    }
                }
                reader.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
                Console.WriteLine(e.StackTrace);
                Console.WriteLine("Выберите файл");
            }
            return id;
        }
    }
}
