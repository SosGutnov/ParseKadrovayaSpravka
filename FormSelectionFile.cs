using System;
using System.Windows.Forms;

namespace ParseKadrovayaSpravka
{
    public partial class FormSelectionFile : Form
    {
        public FormSelectionFile()
        {
            InitializeComponent();
        }

        private void buttonSFile_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            var mainForm = new MainForm();
            mainForm.Activate();
            mainForm.Visible = true;
            mainForm.Activate();

        }
    }
}
