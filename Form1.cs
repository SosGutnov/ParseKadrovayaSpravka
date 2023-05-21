using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParseKadrovayaSpravka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConnectFile.Connect(button1);
            dataGridViewInfo.Rows.Clear();
            toolStripMenuItem1_Click(sender,  e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            ParseInfo.ParseAuditoriesInfo(dataGridViewInfo);
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            ParseInfo.ParseReferenceKO20_4(dataGridViewInfo);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InsertDataExample.InsertDataEmpl(ParseInfo.fio);
            InsertDataExample.InsertDataEmpl_Degrees(ParseInfo.fio, ParseInfo.degrees);
        }
    }
}
