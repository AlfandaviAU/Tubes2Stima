using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlyVANS
{
    public partial class onlyvans : Form
    {
        string pilihan;

        public onlyvans()
        {
            InitializeComponent();
            panel1.BringToFront();
            panel1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open txt file";
            openFileDialog1.ShowDialog();
            var fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
            MessageBox.Show(fileName);
            if (fileName != "")
            {
                label7.Text = fileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //button3
            label8.Text = "Friends recommendations for " + pilihan + ":";
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //radioButton1 BFS
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //radioButton2 DFS
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pilihan = comboBox1.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox2
        }
    }
}
