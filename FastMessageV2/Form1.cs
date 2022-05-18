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
    public partial class Form1 : Form
    {
        string FastName = @"C:\FastName.txt";
        string FastMessages = @"C:\FastMessages.txt";
        string[] messages = new string[200];
        int j = 0;
        Form2 form2 = new Form2();
        public Form1()
        {
            InitializeComponent();
            notifyIcon1.Visible = false;
            // добавляем Эвент или событие по 2му клику мышки, 
            //вызывая функцию  notifyIcon1_MouseDoubleClick
            this.notifyIcon1.MouseDoubleClick += new MouseEventHandler(notifyIcon1_MouseDoubleClick);

            // добавляем событие на изменение окна
            this.Resize += new System.EventHandler(this.Form1_Resize);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form2.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] lines = File.ReadAllLines(FastName);
            foreach (string s in lines)
            {
                listBox1.Items.Add(s);
            }

            string a = File.ReadAllText(FastMessages);
            int i = File.ReadAllLines(FastName).Length;     //надо внести правильно из файла в строку, чтобы можно было связать с другим файлом
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
            Clipboard.SetText(messages[listBox1.SelectedIndex].Trim());
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // делаем нашу иконку скрытой
            notifyIcon1.Visible = false;
            // возвращаем отображение окна в панели
            this.ShowInTaskbar = true;
            //разворачиваем окно
            WindowState = FormWindowState.Normal;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            // проверяем наше окно, и если оно было свернуто, делаем событие        
            if (WindowState == FormWindowState.Minimized)
            {
                // прячем наше окно из панели
                this.ShowInTaskbar = false;
                // делаем нашу иконку в трее активной
                notifyIcon1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            string[] lines = File.ReadAllLines(FastName);
            foreach (string s in lines)
            {
                listBox1.Items.Add(s);
            }
            int j = 0;
            string a = File.ReadAllText(FastMessages);
            int i = File.ReadAllLines(FastName).Length;     //надо внести правильно из файла в строку, чтобы можно было связать с другим файлом
            string[] subs = a.Split(';');
            foreach (var sub in subs)
            {
                messages[j] = sub;
                j++;
            }
        }
    }
}
