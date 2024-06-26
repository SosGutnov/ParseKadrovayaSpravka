﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ParseKadrovayaSpravka
{
    class ConnectXMLfile
    {
        public static List<string> XlPath { get; set; }

        public static void Connect()
        {
            var curDir = Environment.CurrentDirectory;
            XlPath = new List<string>();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.InitialDirectory = curDir + @"\..\..";
                //openFileDialog.Filter = "(*.xlsm)|*.xlsm|(*.xlsx)|*.xlsx";
                openFileDialog.Filter = "(*.xls)|*.xls*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.Multiselect = true;
                openFileDialog.RestoreDirectory = true;
                openFileDialog.Title = "Выберите файлы";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (var item in openFileDialog.FileNames)
                    {
                        XlPath.Add(item);
                    }
                    Console.WriteLine(XlPath[0]);

                }
            }
        }
    }
}
