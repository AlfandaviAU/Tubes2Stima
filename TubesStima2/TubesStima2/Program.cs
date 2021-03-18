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
        static int ProsesDisek(Graph a, Graph b, int a1, int b1, int titik)
        {
            int teman = 0;
            int[] temp1 = new int[titik];
            int[] temp2 = new int[titik];
            int count1 = 0;
            int count2 = 0;
            int count = 0;
            foreach (int i in a.After(a1))
            {
                temp1[count1] = i;
                count1++;
            }
            foreach (int j in b.After(b1))
            {
                temp2[count2] = j;
                count2++;
            }

            for (int i = 0; i < count1; i++)
            {
                for (int j = 0; j < count2; j++)
                {
                    if (a1 == temp2[j] || b1 == temp1[i])
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
        static int Soal1(Graph a, Graph b, int a1, int b1, int titik)
        {
            int teman = 0;
            int[] temp1 = new int[titik];
            int[] temp2 = new int[titik];
            int count1 = 0;
            int count2 = 0;
            int count = 0;
            foreach (int i in a.After(a1))
            {
                temp1[count1] = i;
                count1++;
            }
            foreach (int j in b.After(b1))
            {
                temp2[count2] = j;
                count2++;
            }

            for (int i = 0; i < count1; i++)
            {
                for (int j = 0; j < count2; j++)
                {
                    if(a1 == temp2[j] || b1 == temp1[i]) {
                        teman = 1;
                    }
                    else if (temp1[i] == temp2[j] && (temp1[i] != 0))
                    {
                        count += 1;
                    }
                }
            }
            if(teman == 1) {
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

        static void Main(string[] args)
        {
            try
            {
                string filepath = @"E:\HMIF\Semester4\Strategi Algoritma\tubes 2\TubesStima2\TubesStima2\test.txt"; // nanti kau ubah pathnya
                List<string> lines = new List<string>();
                List<string> basis = new List<string>();
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


                int count_graph = Int32.Parse(lines[0]);

                Graph g = new Graph(count_graph);
                Graph g2 = new Graph(count_graph);

                for (int z = 1; z <= count_graph; z++)
                {
                    char[] c1 = { lines[z][0] };
                    string s1 = new string (c1);
                    int temp1 = ConverterKeInt(s1);

                    char[] c2 = { lines[z][2] };
                    string s2 = new string(c2);
                    int temp2 = ConverterKeInt(s2);
                    g.tambahSimpul(temp1, temp2);
                    g2.tambahSimpul(temp2, temp1);

                }

                Console.Write("Choose Account : ");
                string source = Console.ReadLine();
                int src = ConverterKeInt(source);

                Console.Write("Explore Friends With : ");
                string pelakor1 = Console.ReadLine();

                Console.Write("\n");
                Console.Write("Nama akun : ");
                Console.WriteLine(pelakor1);
                int pelakor2 = ConverterKeInt(pelakor1);
                Soal1(g, g2, src, pelakor2, count_graph);
                Console.Write("\n");



                int dest = ConverterKeInt(basis[0]);
                int temp = ProsesDisek(g, g2, src, dest, count_graph);

                var data = new List<Tuple<int, int>>()
                {
                    new Tuple<int,int>(1,temp)

                };

                for (int i = 1; i < basis.Count(); i++)
                {
                    int dest2 = ConverterKeInt(basis[i]);
                    int temp2 = ProsesDisek(g, g2, src, dest2, count_graph);
                    data.Add(new Tuple<int, int>(i+1, temp2));
                }
                data = data.OrderByDescending(t => t.Item2).ToList();
                for (int i = 0; i < data.Count; i++)
                {
                    
                    if (data[i].Item1 != pelakor2 && data[i].Item1 != src)
                    {
                        Console.Write("Nama akun : ");
                        Console.WriteLine(ConverterKeChar(data[i].Item1));
                        Soal1(g, g2, src, data[i].Item1, count_graph);
                        Console.Write("\n");
                    }

                }



                
                


            }

            catch (FileNotFoundException e)
            {
                Console.WriteLine("Not found");
            }
        }
    }
}