using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FastMessageV2
{
    public partial class FormAddNewName : Form
    {
        string FastName = @"C:\FastName.txt";
        public FormAddNewName()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            File.AppendAllText(FastName, "\n" + textBox1.Text);
            this.Visible = false;
        }
    }
}
