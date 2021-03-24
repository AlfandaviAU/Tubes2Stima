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

namespace OnlyVANS
{

    //FORM
    public partial class onlyvans : Form
    {
        string exploreWith = ""; // var nyimpan pilihan explore with
        string chooseAccount = ""; // var nyimpan pilihan choose account
        string algorithm = ""; // pilihan algoritma
        string filePath = ""; // var buat nyimpan path
        string fileName; //file name
        List<string> lines = new List<string>();
        List<string> basis = new List<string>();
        List<string> panduan2 = new List<string>();

        int count_graph = 0;

        //public static convertGraph(string[] )
        public static string converterAsu(string a, List<string> basis, List<string> panduan2)
        {
            int res = 0;
            for (int i = 0; i < basis.Count; i++)
            {
                if (basis[i] == a)
                {
                    res = i;
                }
            }
            return panduan2[res];
        }

        public static string reconverterAsu(string a, List<string> basis, List<string> panduan2)
        {
            int res = 0;
            for (int i = 0; i < panduan2.Count; i++)
            {
                if (panduan2[i] == a)
                {
                    res = i;
                }
            }
            return basis[res];
        }

        public static string ConverterKeChar(int num)
        {
            switch (num)
            {
                case 1:
                    return ("A");

                case 2:
                    return ("B");

                case 3:
                    return ("C");

                case 4:
                    return ("D");

                case 5:
                    return ("E");

                case 6:
                    return ("F");

                case 7:
                    return ("G");

                case 8:
                    return ("H");

                case 9:
                    return ("I");

                case 10:
                    return ("J");

                case 11:
                    return ("K");

                case 12:
                    return ("L");

                case 13:
                    return ("M");

                case 14:
                    return ("N");

                case 15:
                    return ("O");

                case 16:
                    return ("P");

                case 17:
                    return ("Q");

                case 18:
                    return ("R");

                case 19:
                    return ("S");

                case 20:
                    return ("T");

                case 21:
                    return ("U");

                case 22:
                    return ("V");

                case 23:
                    return ("W");

                case 24:
                    return ("X");

                case 25:
                    return ("Y");

                case 26:
                    return ("Z");

                default:
                    return ("UNDEFINED");

            }
        }
        public static int ConverterKeInt(string character)
        {
            switch (character)
            {
                case "A":
                    return (1);

                case "B":
                    return (2);

                case "C":
                    return (3);

                case "D":
                    return (4);

                case "E":
                    return (5);

                case "F":
                    return (6);

                case "G":
                    return (7);

                case "H":
                    return (8);

                case "I":
                    return (9);

                case "J":
                    return (10);

                case "K":
                    return (11);

                case "L":
                    return (12);

                case "M":
                    return (13);

                case "N":
                    return (14);

                case "O":
                    return (15);

                case "P":
                    return (16);

                case "Q":
                    return (17);

                case "R":
                    return (18);

                case "S":
                    return (19);

                case "T":
                    return (20);

                case "U":
                    return (21);

                case "V":
                    return (22);

                case "W":
                    return (23);

                case "X":
                    return (24);

                case "Y":
                    return (25);

                case "Z":
                    return (26);

                default:
                    return (-1);

            }
        }
        static int ProsesDisek(Graph a, int src, int dest, int titik)
        {
            int teman = 0;
            int[] temp1 = new int[titik];
            int[] temp2 = new int[titik];
            int count = 0;
            int count1 = 0;
            int count2 = 0;
            for (int i = 0; i < a.After(src).Count(); i++)
            {
                if (a.After(src)[i] != 0)
                {
                    temp1[count1] = a.After(src)[i];
                    count1++;
                }
            }
            for (int i = 0; i < a.After(dest).Count(); i++)
            {
                if (a.After(dest)[i] != 0)
                {
                    temp2[count2] = a.After(dest)[i];
                    count2++;
                }
            }

            for (int i = 0; i < count1; i++)
            {
                for (int j = 0; j < count2; j++)
                {
                    if (src == temp2[j] || dest == temp1[i])
                    {
                        teman = 1;
                    }
                    else if (temp1[i] == temp2[j] && (temp1[i] != 0))
                    {
                        count += 1;
                    }
                }
            }
            if (teman == 1)
            {
                return 0;
            }
            return count;
        }
        // Soal1(g, g2, src, data[i].Item1, count_graph);
        int Soal1(Graph a, int src, int dest, int titik)
        {
            int teman = 0;
            int[] temp1 = new int[titik];
            int[] temp2 = new int[titik];
            int count = 0;
            int count1 = 0;
            int count2 = 0;
            for (int i = 0; i < a.After(src).Count(); i++)
            {
                if (a.After(src)[i] != 0)
                {
                    temp1[count1] = a.After(src)[i];
                    count1++;
                }
            }
            for (int i = 0; i < a.After(dest).Count(); i++)
            {
                if (a.After(dest)[i] != 0)
                {
                    temp2[count2] = a.After(dest)[i];
                    count2++;
                }
            }

            for (int i = 0; i < count1; i++)
            {
                for (int j = 0; j < count2; j++)
                {
                    if (src == temp2[j] || dest == temp1[i])
                    {
                        teman = 1;
                    }
                    else if (temp1[i] == temp2[j] && (temp1[i] != 0))
                    {
                        count += 1;
                    }
                }
            }
            if (teman == 1)
            {
                //Console.WriteLine("Already friends");
                label10.Text += "Already friends\n";
                return 0;
            }
            else if (count > 0)
            {
                if (count != 1)
                {
                    //Console.WriteLine(count + " mutual friends : ");
                    label10.Text += count + " mutual friends : \n";
                }
                else
                {
                    //Console.WriteLine("1 mutual friend : ");
                    label10.Text += "1 mutual friend : \n";
                }
            }
            else
            {
                //Console.WriteLine("No mutual friend");
                label10.Text += "No mutual friend\n";
                return 0;
            }

            for (int i = 0; i < count1; i++)
            {
                for (int j = 0; j < count2; j++)
                {
                    if (temp1[i] == temp2[j] && (temp1[i] != 0))
                    {
                        //Console.WriteLine(ConverterKeChar(temp1[i]));
                        label10.Text += ConverterKeChar(temp1[i]) + "\n";
                    }
                }
            }
            return teman;
        }

        bool Soal2DFS(Graph g,int awal,int akhir,int[] dikunjungi,int[] result,int tingkat,List<string> basis,List<string> panduan2) 
        {
            string temp;
            dikunjungi[awal] = 1;
            if(awal == akhir) {
                int x = 0;
                temp = ConverterKeChar(result[0]);
                //Console.Write(reconverterAsu(temp,basis,panduan2));
                label10.Text += reconverterAsu(temp,basis,panduan2);
                //Console.Write(" dan ");
                label10.Text += " dan ";
                temp = ConverterKeChar(akhir);
                //Console.WriteLine(reconverterAsu(temp,basis,panduan2));
                label10.Text += reconverterAsu(temp,basis,panduan2) + "\n";
                if(tingkat == 0) {
                    //Console.WriteLine("You are searching for yourself");
                    label10.Text += "You are searching for yourself\n";
                }
                else if(tingkat == 1) {
                    //Console.WriteLine("Direct connection");
                    label10.Text += "Direct connection\n";
                }
                else if(tingkat == 2) {
                    //Console.WriteLine("1st-degree connection");
                    label10.Text += "1st-degree connection\n";
                }
                else if(tingkat == 3) {
                    //Console.WriteLine("2nd-degree connection");
                    label10.Text += "2nd-degree connection\n";
                }
                else if(tingkat == 4) {
                    //Console.WriteLine("3rd-degree connection");
                    label10.Text += "3rd-degree connection\n";
                }
                else {
                    //Console.WriteLine((tingkat - 1) + " th-degree connection");
                    label10.Text += (tingkat - 1) + " th-degree connection\n";
                }
                if (tingkat >= 1)
                {
                    while (x < tingkat)
                    {
                        temp = ConverterKeChar(result[x]);
                        //Console.Write(reconverterAsu(temp, basis, panduan2));
                        label10.Text += reconverterAsu(temp, basis, panduan2);
                        //Console.Write(" -> ");
                        label10.Text += " -> ";
                        x = x + 1;
                    }
                    temp = ConverterKeChar(result[x]);
                    //Console.WriteLine(reconverterAsu(temp, basis, panduan2));
                    label10.Text += reconverterAsu(temp, basis, panduan2) + "\n";
                }
                return true;
            }
            else {
                int[] cabang = g.After(awal);
                foreach(int z in cabang) {
                    if(dikunjungi[z] == 0) {
                        result[tingkat+1] = z;
                        bool yesno = Soal2DFS(g, z, akhir, dikunjungi, result, tingkat + 1,basis,panduan2);
                        if(yesno)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        void Soal2BFS(Graph g,int a, int b, int count_graph, List<string> basis, List<string> panduan2)
        {
            int x;
            string temp;
            int[] prev = new int[count_graph + 1];
            bool found = false;
            bool[] dikunjungi = new bool[count_graph + 1];
            Queue<Int32> queue = new Queue<int>();
            dikunjungi[a] = true;
            prev[a] = -1;
            queue.Enqueue(a);

            while (queue.Count != 0 && found == false)
            {
                x = queue.Dequeue();
                if (x == b)
                {
                    found = true;
                }
                else
                {
                    foreach (int i in g.After(x))
                    {
                        if (!dikunjungi[i])
                        {
                            dikunjungi[i] = true;
                            prev[i] = x;
                            queue.Enqueue(i);
                        }
                    }
                }
            }
            temp = ConverterKeChar(a);
            //Console.Write(reconverterAsu(temp, basis, panduan2));
            label10.Text += reconverterAsu(temp, basis, panduan2);
            //Console.Write(" dan ");
            label10.Text += " dan ";
            temp = ConverterKeChar(b);
            //Console.WriteLine(reconverterAsu(temp, basis, panduan2));
            label10.Text += reconverterAsu(temp, basis, panduan2) + "\n";
            if (found)
            {
                Stack<Int32> result = new Stack<int>();
                int carry = b;
                while (carry != -1)
                {
                    result.Push(carry);
                    carry = prev[carry];
                }
                if (result.Count == 1)
                {
                    //Console.WriteLine("You are searching for yourself");
                    label10.Text += "You are searching for yourself\n";
                }
                else if (result.Count == 2)
                {
                    //Console.WriteLine("Direct connection");
                    label10.Text += "Direct connection\n";
                }
                else if (result.Count == 3)
                {
                    //Console.WriteLine("1st-degree connection");
                    label10.Text += "1st-degree connection\n";
                }
                else if (result.Count == 4)
                {
                    //Console.WriteLine("2nd-degree connection");
                    label10.Text += "2nd-degree connection\n";
                }
                else if (result.Count == 5)
                {
                    //Console.WriteLine("3rd-degree connection");
                    label10.Text += "3rd-degree connection\n";
                }
                else
                {
                    //Console.WriteLine((result.Count - 2) + " th-degree connection");
                    label10.Text += (result.Count - 2) + " th-degree connection\n";
                }
                if (result.Count >= 2)
                {
                    while (result.Count > 1)
                    {
                        int buang = result.Pop();
                        temp = ConverterKeChar(buang);
                        //Console.Write(reconverterAsu(temp, basis, panduan2));
                        label10.Text += reconverterAsu(temp, basis, panduan2);
                        //Console.Write(" -> ");
                        label10.Text += " -> ";
                    }
                    int buang2 = result.Pop();
                    temp = ConverterKeChar(buang2);
                    //Console.WriteLine(reconverterAsu(temp, basis, panduan2));
                    label10.Text += reconverterAsu(temp, basis, panduan2) + "\n";

                }
            }
            else
            {
                //Console.WriteLine("Tidak ada jalur koneksi yang tersedia");
                label10.Text += "Tidak ada jalur koneksi yang tersedia" + "\n";
                //Console.WriteLine("Anda harus memulai koneksi baru itu sendiri.");
                label10.Text += "Anda harus memulai koneksi baru itu sendiri." + "\n";
            }

        }

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
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            openFileDialog1.Title = "Open txt file";
            openFileDialog1.ShowDialog();
            filePath = System.IO.Path.GetFullPath(openFileDialog1.FileName);
            fileName = System.IO.Path.GetFileName(openFileDialog1.FileName);
            if (fileName != "open file")
            {
                label7.Text = fileName;
                lines = File.ReadAllLines(filePath).ToList();
                for (int i = 1; i < lines.Count(); i++)
                {

                    char[] asu = { lines[i][0] };
                    string temp2 = new string(asu);
                    char[] temp3 = { lines[i][2] };
                    string temp4 = new string(temp3);
                    if (basis.Contains(temp2) == false)
                    {
                        basis.Add(temp2);

                    }
                    if (basis.Contains(temp4) == false)
                    {
                        basis.Add(temp4);
                    }

                }
                basis.Sort();
                foreach (string a in basis)
                {
                    comboBox1.Items.Add(a);
                    comboBox2.Items.Add(a);
                }
                for (int i = 0; i < basis.Count; i++)
                {
                    panduan2.Add(ConverterKeChar(i + 1));
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((filePath == "") | (fileName == "open file") )
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
                label8.Text = "Friends recommendations for " + chooseAccount + ":\n";
                //label9 buat gambar graph
                //label10 buat nampilkan hasil
                int count_graph = Int32.Parse(lines[0]);

                Graph g = new Graph(count_graph);
                Graph g2 = new Graph(count_graph);
                Graph g3 = new Graph(27);

                for (int z = 1; z <= count_graph; z++)
                {
                    char[] c1 = { lines[z][0] };
                    string s1 = new string(c1);
                    string ss1 = converterAsu(s1, basis, panduan2);
                    int temp1 = ConverterKeInt(ss1);

                    char[] c2 = { lines[z][2] };
                    string s2 = new string(c2);
                    string ss2 = converterAsu(s2, basis, panduan2);
                    int temp2 = ConverterKeInt(ss2);
                    g3.tambahSimpul(temp1,temp2);
                    g3.tambahSimpul(temp2,temp1);

                }
                int src = ConverterKeInt(converterAsu(chooseAccount,basis, panduan2));
                string pelakor1 = converterAsu(exploreWith, basis, panduan2);
                bool cond = false;
                for (int i = 0; i < basis.Count; i++)
                {
                    if (pelakor1 == panduan2[i])
                    {
                        cond = true;
                    }
                }
                int pelakor2 = ConverterKeInt(pelakor1);
                if (cond == true){

                    string asuu2 = ConverterKeChar(pelakor2);
                    label10.Text += "Nama akun : " + reconverterAsu(asuu2, basis, panduan2) + "\n";
                    Soal1(g3, src, pelakor2, count_graph);
                    label10.Text += "\n";
                }else{
                    label10.Text += "Akun tersebut tidak ditemukan\n";
                }
                int dest = ConverterKeInt(pelakor1);
                int temp = ProsesDisek(g3, src, dest, count_graph);
                var data = new List<Tuple<int, int>>()
                {
                    new Tuple<int,int>(1,temp)

                };

                for (int i = 1; i < panduan2.Count(); i++)
                {
                    int dest2 = ConverterKeInt(panduan2[i]);
                    int temp2 = ProsesDisek(g3, src, dest2, count_graph);
                    data.Add(new Tuple<int, int>(i + 1, temp2));
                }
                data = data.OrderByDescending(t => t.Item2).ToList();
                for (int i = 0; i < data.Count; i++)
                {

                    if (data[i].Item1 != pelakor2 && data[i].Item1 != src)
                    {

                        label10.Text += "Nama akun : ";
                        string asuu = ConverterKeChar(data[i].Item1);
                        label10.Text += reconverterAsu(asuu, basis, panduan2);
                        label10.Text += "\n";
                        Soal1(g3, src, data[i].Item1, count_graph);
                        label10.Text += "\n";
                    }

                }
                if(algorithm == "DFS"){
                    string dummy1 = converterAsu(chooseAccount, basis, panduan2);
                    int awal = ConverterKeInt(dummy1);

                    string dummy2 = converterAsu(exploreWith, basis, panduan2);
                    int akhir = ConverterKeInt(dummy2);

                    int[] dikunjungi = new int[27];
                    int[] result = new int[count_graph + 1];
                    result[0] = awal;
                    bool hasil = Soal2DFS(g3, awal, akhir, dikunjungi, result, 0, basis, panduan2);
                    if (hasil == false)
                    {
                        label10.Text += (exploreWith + " dan " + chooseAccount + "\n");
                        label10.Text += ("Tidak ada jalur koneksi yang tersedia\n");
                        label10.Text += ("Anda harus memulai koneksi baru itu sendiri.\n");
                    }
                } else{
                    string dummy3 = converterAsu(chooseAccount, basis, panduan2);
                    int awal3 = ConverterKeInt(dummy3);

                    string dummy4 = converterAsu(exploreWith, basis, panduan2);
                    int akhir4 = ConverterKeInt(dummy4);
                    //static void Soal2BFS(Graph g, int a, int b, int count_graph, List<string> basis, List<string> panduan2)
                    Soal2BFS(g3, awal3, akhir4, 27, basis, panduan2);

                }

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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            exploreWith = ""; 
            chooseAccount = ""; 
            algorithm = ""; 
            filePath = "";
            lines.Clear();
            basis.Clear();
            panduan2.Clear();
            label7.ResetText();
            panel2.Controls.Clear();
            label8.ResetText();
            label10.ResetText();
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
    }
    class Graph
    {
        public int titik;
        public List<Int32>[] simpul;
        public Graph(int a)
        {
            titik = a;
            simpul = new List<Int32>[a];
            for (int i = 0; i < a; i++)
            {
                simpul[i] = new List<int>();
            }
        }
        public void tambahSimpul(int a, int b)
        {
            simpul[a].Add(b);
            simpul[a].Sort();
        }
      
        public int[] After(int a) // After iki intine sama ae karo bfs tapi sampe tingkat 1 ae
        {
            int[] after = new int[titik];
            foreach (int i in simpul[a])
            {
                after[i] = i;
            }
            return after;
        }
    }
}
