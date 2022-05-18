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
    public partial class Form2 : Form
    {
        string FastName = @"C:\FastName.txt";
        string FastMessages = @"C:\FastMessages.txt";
        string[] messages = new string[200];
        int j = 0;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            listBox1.Items.Clear();
            string[] lines = File.ReadAllLines(FastName);
            foreach (string s in lines)
            {
                listBox1.Items.Add(s);
            }

            string a = File.ReadAllText(FastMessages);
            int i = File.ReadAllLines(FastName).Length;     
            string[] subs = a.Split(';');
            foreach (var sub in subs)
            {
                messages[j] = sub;
                j++;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = messages[listBox1.SelectedIndex].Trim();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
