using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;


namespace TubesStima2
{
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
        public void DFS(int a)
        {
            bool[] dikunjungi = new bool[titik];
            Stack<Int32> stack = new Stack<int>();
            dikunjungi[a] = true;
            stack.Push(a);

            while (stack.Count != 0)
            {
                a = stack.Pop();
                Console.Write(a + ",");
                foreach (int i in simpul[a])
                {
                    if (!dikunjungi[i])
                    {
                        dikunjungi[i] = true;
                        stack.Push(i);
                    }
                }
            }
        }
        public void BFS(int a) {
            bool[] dikunjungi = new bool[titik];
            Queue<Int32> queue = new Queue<int>();
            dikunjungi[a] = true;
            queue.Enqueue(a);

            while(queue.Count != 0) {
                a = queue.Dequeue();
                Console.Write(a+",");
                foreach(int i in simpul[a]) {
                    if(!dikunjungi[i]) {
                        dikunjungi[i] = true;
                        queue.Enqueue(i);
                    }
                }
            }
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
    class Program
    {
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
        static int Soal1(Graph a, int src, int dest, int titik)
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
                Console.WriteLine("Already friends");
                return 0;
            }
            else if (count > 0)
            {
                if (count != 1)
                {
                    Console.WriteLine(count + " mutual friends : ");
                }
                else
                {
                    Console.WriteLine("1 mutual friend : ");
                }
            }
            else
            {
                Console.WriteLine("No mutual friend");
                return 0;
            }

            for (int i = 0; i < count1; i++)
            {
                for (int j = 0; j < count2; j++)
                {
                    if (temp1[i] == temp2[j] && (temp1[i] != 0))
                    {
                        Console.WriteLine(ConverterKeChar(temp1[i]));
                    }
                }
            }
            return teman;
        }

        static bool Soal2DFS(Graph g,int awal,int akhir,int[] dikunjungi,int[] result,int tingkat,List<string> basis,List<string> panduan2) {
            string temp;
            dikunjungi[awal] = 1;
            if(awal == akhir) {
                int x = 0;
                temp = ConverterKeChar(result[0]);
                Console.Write(reconverterAsu(temp,basis,panduan2));
                Console.Write(" dan ");
                temp = ConverterKeChar(akhir);
                Console.WriteLine(reconverterAsu(temp,basis,panduan2));
                if(tingkat == 0) {
                    Console.WriteLine("You are searchig for yourself");
                }
                else if(tingkat == 1) {
                    Console.WriteLine("Direct connection");
                }
                else if(tingkat == 2) {
                    Console.WriteLine("1st-degree connection");
                }
                else if(tingkat == 3) {
                    Console.WriteLine("2nd-degree connection");
                }
                else if(tingkat == 4) {
                    Console.WriteLine("3rd-degree connection");
                }
                else {
                    Console.WriteLine((tingkat - 1) + " th-degree connection");
                }
                if (tingkat >= 1)
                {
                    while (x < tingkat)
                    {
                        temp = ConverterKeChar(result[x]);
                        Console.Write(reconverterAsu(temp, basis, panduan2));
                        Console.Write(" -> ");
                        x = x + 1;
                    }
                    temp = ConverterKeChar(result[x]);
                    Console.WriteLine(reconverterAsu(temp, basis, panduan2));
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
        static void Soal2BFS(Graph g,int a, int b, int count_graph, List<string> basis, List<string> panduan2)
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
            Console.Write(reconverterAsu(temp, basis, panduan2));
            Console.Write(" dan ");
            temp = ConverterKeChar(b);
            Console.WriteLine(reconverterAsu(temp, basis, panduan2));
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
                    Console.WriteLine("You are searching for yourself");
                }
                else if (result.Count == 2)
                {
                    Console.WriteLine("Direct connection");
                }
                else if (result.Count == 3)
                {
                    Console.WriteLine("1st-degree connection");
                }
                else if (result.Count == 4)
                {
                    Console.WriteLine("2nd-degree connection");
                }
                else if (result.Count == 5)
                {
                    Console.WriteLine("3rd-degree connection");
                }
                else
                {
                    Console.WriteLine((result.Count - 2) + " th-degree connection");
                }
                if (result.Count >= 2)
                {
                    while (result.Count > 1)
                    {
                        int buang = result.Pop();
                        temp = ConverterKeChar(buang);
                        Console.Write(reconverterAsu(temp, basis, panduan2));
                        Console.Write(" -> ");
                    }
                    int buang2 = result.Pop();
                    temp = ConverterKeChar(buang2);
                    Console.WriteLine(reconverterAsu(temp, basis, panduan2));

                }
            }
            else
            {
                Console.WriteLine("Tidak ada jalur koneksi yang tersedia");
                Console.WriteLine("Anda harus memulai koneksi baru itu sendiri.");
            }

        }

        static void Main(string[] args)
        {
            try
            {
                string filepath = @"C:\git\Tubes2Stima\TubesStima2\TubesStima2\test.txt"; // nanti kau ubah pathnya
                List<string> lines = new List<string>();
                List<string> basis = new List<string>();


                List<string> panduan2 = new List<string>();

                lines = File.ReadAllLines(filepath).ToList();
                for (int i = 1; i < lines.Count(); i++)
                {
                    
                    char[] asu = { lines[i][0] };
                    string temp2 = new string(asu);
                    char[] temp3 = { lines[i][2] };
                    string temp4 = new string(temp3);
                    if (basis .Contains(temp2) == false){
                        basis.Add(temp2);
                        
                    }
                    if (basis.Contains(temp4) == false)
                    {
                        basis.Add(temp4);
                    }
                }
                basis.Sort();
                Console.WriteLine("==========BASIS==========");
                foreach (string a in basis)
                {
                    Console.WriteLine(a);
                }
                for (int i = 0; i < basis.Count; i++)
                {
                    panduan2.Add(ConverterKeChar(i + 1));
                }
                Console.WriteLine("=========PANDUAN2========");
                foreach(string a in panduan2)
                {
                    Console.WriteLine(a);
                }
                int count_graph = Int32.Parse(lines[0]);

                Graph g = new Graph(count_graph);
                Graph g2 = new Graph(count_graph);
                Graph g3 = new Graph(count_graph + 1);

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


                Console.Write("Choose Account : ");
                string aasu1 = Console.ReadLine();
                int src = ConverterKeInt(converterAsu(aasu1, basis, panduan2));

                Console.Write("Explore Friends With : ");
                string asu1 = Console.ReadLine();
                string pelakor1 = converterAsu(asu1, basis, panduan2);
                bool cond = false;
                for (int i = 0; i < basis.Count; i++)
                {
                    if (pelakor1 == panduan2[i])
                    {
                        cond = true;
                    }
                }
                int pelakor2 = ConverterKeInt(pelakor1);
                if (cond == true)
                {
                    Console.Write("\n");
                    Console.Write("Nama akun : ");
                    Console.WriteLine(asu1);

                    Soal1(g3, src, pelakor2, count_graph);
                    Console.Write("\n");
                }
                else
                {
                    Console.Write("\n");
                    Console.Write("Nama akun : ");
                    Console.WriteLine(asu1);
                    Console.WriteLine("Tidak ditemukan\n");
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
                        Console.Write("Nama akun : ");
                        string asuu = ConverterKeChar(data[i].Item1);
                        Console.WriteLine(reconverterAsu(asuu, basis, panduan2));
                        Soal1(g3, src, data[i].Item1, count_graph);
                        Console.Write("\n");
                    }

                }
                // explore friends DFS
                Console.Write("Explore with : ");
                string masuk1 = Console.ReadLine();
                string dummy1 = converterAsu(masuk1, basis, panduan2);
                int awal = ConverterKeInt(dummy1);

                Console.Write("Choose account : ");
                string masuk2 = Console.ReadLine();
                string dummy2 = converterAsu(masuk2, basis, panduan2);
                int akhir = ConverterKeInt(dummy2);

                // static bool Soal2DFS(Graph g,int awal,int akhir,int[] dikunjungi,int[] result,int tingkat)
                int[] dikunjungi = new int[count_graph + 1];
                int[] result = new int[count_graph + 1];
                result[0] = awal;
                bool hasil = Soal2DFS(g3, awal, akhir, dikunjungi, result, 0, basis, panduan2);
                if (hasil == false)
                {
                    Console.WriteLine(masuk1 + " dan " + masuk2);
                    Console.WriteLine("Tidak ada jalur koneksi yang tersedia");
                    Console.WriteLine("Anda harus memulai koneksi baru itu sendiri.");
                }

                //explore friend BFS
                Console.Write("Explore with : ");
                string masuk3 = Console.ReadLine();
                string dummy3 = converterAsu(masuk1, basis, panduan2);
                int awal3 = ConverterKeInt(dummy1);

                Console.Write("Choose account : ");
                string masuk = Console.ReadLine();
                string dummy4 = converterAsu(masuk2, basis, panduan2);
                int akhir4 = ConverterKeInt(dummy2);
                //static void Soal2BFS(Graph g, int a, int b, int count_graph, List<string> basis, List<string> panduan2)
                Soal2BFS(g3, awal3, akhir4, count_graph, basis, panduan2);

            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine("Not found");
            }
        }
    }
}