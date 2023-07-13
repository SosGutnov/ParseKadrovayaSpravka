using DocumentFormat.OpenXml.Drawing.Diagrams;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParseKadrovayaSpravka
{
    public partial class MainForm : Form
    {

        public static MySqlConnection connection = DBUtils.GetDBConnection();

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectXMLfile.Connect(button1);
            dataGridViewInfo.Rows.Clear();
            toolStripMenuItem1_Click(sender,  e);
            toolStripMenuItem2_Click(sender, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ParseInfo.ParseLoads(dataGridViewInfo);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ParseInfo.ParseSpecialPractices(dataGridViewInfo);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ParseInfo.ParseTacherInfo(dataGridViewInfo);
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
                InsertDegrees.InsertEmpl(ParseInfo.fio);
                InsertDegrees.InsertEmpl_Degrees(ParseInfo.fio, ParseInfo.degrees);
                InsertEducation.InsertEdu1(ParseInfo.fio, ParseInfo.for_education);
                InsertTitles.InsertTitl(ParseInfo.fio, ParseInfo.degrees);//degrees=titles
                InsertExternalPractices.InsertExtP(ParseInfo.external_practice);
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
    }
}
