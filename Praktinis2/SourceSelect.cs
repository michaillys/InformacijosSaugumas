using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;




namespace Praktinis2
{
    class SourceSelect
    {
        public string? SourcePath { get; set; }
        public string? OutputPath { get; set; }

        public string SelectSource()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                SourcePath = dlg.FileName;
            }
            return SourcePath ?? string.Empty;
        }

        public string SelectOutput()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Title = "Select output folder";
            dlg.CheckFileExists = false;
            dlg.CheckPathExists = false;
            dlg.FileName = "Select output folder";
            dlg.Filter = "All files (*.*)|*.*";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                OutputPath = System.IO.Path.GetDirectoryName(dlg.FileName);
            }
            return OutputPath ?? string.Empty;
        }
    }
}
