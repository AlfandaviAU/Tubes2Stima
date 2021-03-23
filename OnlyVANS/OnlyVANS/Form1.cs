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
        string exploreWith = ""; // var nyimpan pilihan explore with
        string chooseAccount = ""; // var nyimpan pilihan choose account
        string algorithm = ""; // pilihan algoritma
        string filePath = ""; // var buat nyimpan path

        public onlyvans()
        {
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
            if (filePath == "")
            {
                label8.Text = "Message : File belum di input.";
            }
            else if(algorithm == "")
            {
                label8.Text = "Message : Pilih algoritma terlebih dahulu.";
            }
            else if (chooseAccount == "")
            {
                label8.Text = "Message : Pilih akun terlebih dahulu.";
            }
            else if (exploreWith == "")
            {
                label8.Text = "Message : Pilih teman yang ingin dixplore terlebih dahulu.";
            }
            else
            {
                //SUBMIT BUTTON
                //button3
                label8.Text = "Friends recommendations for " + chooseAccount + ":";
                //label9 buat gambar graph
                //label10 buat nampilkan hasil


                //MENGGAMBAR GRAPH
                //create a viewer object 
                Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
                //create a graph object 
                Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
                //asumsi input 
                graph.AddEdge("A", "B"); 
                graph.AddEdge("B", "C");
                graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
                graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
                graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
                Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
                c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
                c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
                //bind the graph to the viewer 
                viewer.Graph = graph;
                //associate the viewer with the form 
                panel2.SuspendLayout();
                viewer.Dock = System.Windows.Forms.DockStyle.Fill;
                panel2.Controls.Add(viewer);
                panel2.ResumeLayout();



            }
            


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
