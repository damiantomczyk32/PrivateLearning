using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSVReader
{
    class OwnFile
    {
        public string Set(TextBox textBox,string filter)
        {
            string path = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = filter+"|*."+filter+ "|All|*.*";
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = openFileDialog.FileName;
                textBox.Enabled = false;
            }
            return path = textBox.Text;
        }
    }
}
