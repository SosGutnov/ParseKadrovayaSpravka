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
            ConnectFile.Connect();
            dataGridViewInfoTeacher.Rows.Clear();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ParseInfo.ParseSpecialPractices(dataGridViewInfoTeacher);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ParseInfo.ParseTacherInfo(dataGridViewInfoTeacher);
        }
    }
}
