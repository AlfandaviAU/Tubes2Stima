using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            for (int i=0; i < a; i++)
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
                Console.Write(a+",");
                foreach(int i in simpul[a])
                {
                    if (!dikunjungi[i]){
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
        public int[] After(int a)
        {
            int[] after = new int[titik];
            foreach(int i in simpul[a])
            {
                after[i] = i;
            }
            return after;
        }

    }
    class Program
    {
        static string ConverterKeChar(int num)
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
        static int ConverterKeInt(string character)
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

        static void Soal1(Graph a, Graph b, int a1, int b1, int titik)
        {
            int[] temp1 = new int[titik];
            int[] temp2 = new int[titik];
            int count1 = 0;
            int count2 = 0;
            int count = 0;
            foreach(int i in a.After(a1))
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
                    if (temp1[i] == temp2[j] && (temp1[i] != 0))
                    {
                        count += 1;
                    }
                }
            }
            if (count > 0)
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
                Console.WriteLine("0 mutual friend");
            }
            
            for (int i = 0; i < count1; i++)
            {
                for(int j = 0; j < count2; j++)
                {
                    if (temp1[i] == temp2[j] && (temp1[i] != 0))
                    {
                        Console.WriteLine(ConverterKeChar(temp1[i]));
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int count_graph = 13;

            Graph g = new Graph(count_graph);
            Graph g2 = new Graph(count_graph);
            g.tambahSimpul(1, 2);
            g.tambahSimpul(1, 3);
            g.tambahSimpul(1, 4);
            g.tambahSimpul(2, 3);
            g.tambahSimpul(2, 5);
            g.tambahSimpul(2, 6);
            g.tambahSimpul(3, 6);
            g.tambahSimpul(3, 7);
            g.tambahSimpul(4, 7);
            g.tambahSimpul(4, 6);
            g.tambahSimpul(5, 8);
            g.tambahSimpul(5, 6);
            g.tambahSimpul(6, 8);

            g2.tambahSimpul(2, 1);
            g2.tambahSimpul(3, 1);
            g2.tambahSimpul(4, 1);
            g2.tambahSimpul(3, 2);
            g2.tambahSimpul(5, 2);
            g2.tambahSimpul(6, 2);
            g2.tambahSimpul(6, 3);
            g2.tambahSimpul(7, 3);
            g2.tambahSimpul(7, 4);
            g2.tambahSimpul(6, 4);
            g2.tambahSimpul(8, 5);
            g2.tambahSimpul(6, 5);
            g2.tambahSimpul(8, 6);

            Console.Write("Daftar rekomendasi teman untuk akun : ");
            string source = Console.ReadLine();
            int src = ConverterKeInt(source);

            Console.Write("Nama akun : ");
            string destination = Console.ReadLine();
            int dest = ConverterKeInt(destination);
            Soal1(g, g2, src, dest, count_graph);
        }
    }
}
