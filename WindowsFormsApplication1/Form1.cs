using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using MetroFramework;

namespace WindowsFormsApplication1
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        static WebClient client = new WebClient();

        static string GetCode(string placeholder)
        {
           string code = client.DownloadString(placeholder);
           client.DownloadFile(placeholder, "index.html");
           placeholder = code;

           return code;
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_vsc_Click(object sender, EventArgs e)
        {
            string placeholder;
            if (metroComboBox1.SelectedIndex == 0)
            {
                richTextBox1.Text = "";

                placeholder = textBox2.Text + textBox1.Text + textBox3.Text;

                richTextBox1.Text = GetCode(placeholder);
            }
            else if (metroComboBox1.SelectedIndex == 1)
            {
                richTextBox1.Text = "";

                placeholder = textBox2.Text + textBox1.Text + textBox3.Text;
                if (metroToggle1.Checked == true)
                {
                    string path = @"C:\Users\" + Environment.UserName + @"\Desktop\index.html";
                    client.DownloadFile(placeholder, path);
                }
                else
                {
                    client.DownloadFile(placeholder, "index.html");

                }
                richTextBox1.Text = GetCode(placeholder);
            }
            else if (metroComboBox1.SelectedIndex == 2)
            {
                richTextBox1.Text = "";

                placeholder = textBox2.Text + textBox1.Text + textBox3.Text;
                if (metroToggle1.Checked == true)
                {
                    string path = @"C:\Users\" + Environment.UserName + @"\Desktop\main.html";
                    client.DownloadFile(placeholder, path);
                }
                else
                {
                    client.DownloadFile(placeholder, "main.html");

                }
                richTextBox1.Text = GetCode(placeholder);
            }
            else
            {
                richTextBox1.Text = "Select a method!";
            }
        }

        private void metroComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroComboBox1.SelectedIndex == 0)
            {
                metroLabel1.Enabled = false;
                metroToggle1.Enabled = false;
            }
            else if (metroComboBox1.SelectedIndex == 1)
            {
                metroLabel1.Enabled = true;
                metroToggle1.Enabled = true;
            }
            else if (metroComboBox1.SelectedIndex == 2)
            {
                metroLabel1.Enabled = true;
                metroToggle1.Enabled = true;
            }
            else
            {
                metroLabel1.Enabled = false;
                metroToggle1.Enabled = false;
            }
        }

    }
}
