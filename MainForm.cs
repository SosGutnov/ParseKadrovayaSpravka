using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ParseKadrovayaSpravka
{
    public partial class MainForm : Form
    {

        public static MySqlConnection connection = DBUtils.GetDBConnection();

        public MainForm()
        {
            InitializeComponent();

            ConnectXMLfile.Connect();
            dataGridViewInfo.Rows.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //ParseInfo.ParseSpecialPractices(dataGridViewInfo);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //ParseInfo.ParseTacherInfo(dataGridViewInfo);
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            //ParseInfo.ParseAuditoriesInfo(dataGridViewInfo);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            //ParseInfo.ParseReferenceKO20_4(dataGridViewInfo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connection.Open();
            try
            {
                /*InsertDegrees.InsertEmpl(ParseInfo.fio);
                InsertDegrees.InsertEmpl_Degrees(ParseInfo.fio, ParseInfo.degrees);
                InsertEducation.InsertEdu1(ParseInfo.fio, ParseInfo.for_education);
                InsertTitles.InsertTitl(ParseInfo.fio, ParseInfo.degrees);//degrees=titles
                InsertExternalPractices.InsertExtP(ParseInfo.external_practice);*/
                InsertLoads();
            }
            finally
            {
                connection.Close();
                connection.Dispose();
                connection = null;
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ParseInfo.ParseLoads(progressBar1);
        }
        public void InsertLoads()
        {
            progressBar1.Value = 0;
            progressBar1.Minimum = 0;
            progressBar1.Step = 1;
            progressBar1.Maximum = ParseInfo.Listloads.Count;
            foreach (var load in ParseInfo.Listloads)
            {
                InsertReferenceTables.InsertLoads(load.Load);
                InsertReferenceTables.InsertSubjectForms(load.Subject_form);
                InsertReferenceTables.InsertGroups(load.Group);
                InsertEmpl_load.Insert(load);
                progressBar1.PerformStep();
            }
            System.Console.WriteLine("loads - OK");
            System.Console.WriteLine("groups - OK");
            System.Console.WriteLine("empl_loads - OK");
        }
    }
}
