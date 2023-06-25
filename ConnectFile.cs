using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParseKadrovayaSpravka
{
    class ConnectFile
    {
        public static string XlPath { get; set; }

        public static void Connect(Button button1)
        {
            var curDir = Environment.CurrentDirectory;
            XlPath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = curDir + @"\..\..";
                //openFileDialog.Filter = "(*.xlsm)|*.xlsm|(*.xlsx)|*.xlsx";
                openFileDialog.Filter = "(*.xls)|*.xls*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Выберите файл";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    XlPath = openFileDialog.FileName;
                }
            }

            button1.Text = "Файл выбран";

        }
    }
}
