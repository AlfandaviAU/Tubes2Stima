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
    //FORM
    public partial class onlyvans : Form
    {
        string exploreWith; // var nyimpan pilihan explore with
        string chooseAccount; // var nyimpan pilihan choose account
        string algorithm; // pilihan algoritma
        string filePath; // var buat nyimpan path

        public onlyvans()
        {
            //gui yang sedang berlangsung disini
            InitializeComponent();
            panel1.BringToFront();
            panel1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //button1 = tombol Start Journey
            panel1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open txt file";
            openFileDialog1.ShowDialog();
            filePath = System.IO.Path.GetFullPath(openFileDialog1.FileName);
            var fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
            label7.Text = fileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //SUBMIT BUTTON
            //button3
            label8.Text = "Friends recommendations for " + chooseAccount + ":";
            //label9 buat gambar graph
            //label10 buat nampilkan hasil
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //radioButton1 BFS
            algorithm = radioButton1.Text;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //radioButton2 DFS
            algorithm = radioButton2.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Menyimpan state yang dipilih ke variabel exploreWith
            chooseAccount = comboBox1.SelectedItem.ToString();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBox2
            exploreWith = comboBox2.SelectedItem.ToString();
        }
    }
}
