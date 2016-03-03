using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Обработчики исключений в обоих случаях получились практически одинаковыми.
// Можно ли как-нибудь этот момент учесть и сократить код?

namespace arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m;

            // Или это уже чересчур?
            while (true)
            {
                try
                {

                    Console.Write("Enter number of rows: ");
                    n = System.Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter number of columns: ");
                    m = System.Convert.ToInt32(Console.ReadLine());

                    break;
                }

                catch (FormatException)
                {
                    Console.WriteLine("\nWrong input. Try again");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
            }


            int[,] dec = new int[n, m];

            Console.Clear();

            for (int i = 0; i < dec.GetLength(0); i++)
                for (int j = 0; j < dec.GetLength(1); j++)
                {
                    try
                    {
                        Console.Write("Element [{0},{1}]: ", i, j);
                        dec[i, j] = System.Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\nWrong input. Try again\n");

                        if (j > 0) j--;
                        else
                        {
                            i--;
                            j = m - 1;
                        }


                        continue;
                    }
                }

            Console.Clear();
            print(dec);

            Console.WriteLine("Min is {0}", searchMin(dec));
            Console.WriteLine("Max is {0}", searchMax(dec));

            Console.WriteLine("\n\nAfter Max to Min function");
            MaxToMin(dec);
            print(dec);

            Console.ReadKey();


        }



        static int searchMin(int[,] dec)
        {
            int min = dec[0, 0];

            foreach (int it in dec)
                if (it < min)
                    min = it;

            return min;
        }
        static int searchMax(int[,] dec)
        {
            int max = dec[0, 0];

            foreach (int it in dec)
                if (it > max)
                    max = it;

            return max;
        }
        static void MaxToMin(int[,] dec)
        {
            int min = searchMin(dec);
            int max = searchMax(dec);
            for (int i = 0; i < dec.GetLength(0); i++)
                for (int j = 0; j < dec.GetLength(1); j++)
                    if (dec[i, j] == max)
                        dec[i, j] = min;
        }

        static void print(int[,] dec)
        {
            Console.Write("\n");
            for (int i = 0; i < dec.GetLength(0); i++)
            {
                for (int j = 0; j < dec.GetLength(1); j++)
                    Console.Write("{0}\t", dec[i, j]);
                Console.Write("\n\n");
            }
            Console.Write("\n");
        }
    }
}
