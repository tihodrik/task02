using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, m;

            n = Input("Enter number of rows: ");
            m = Input("Enter number of columns: ");
            


            int[,] dec = new int[n, m];

            Console.Clear();

            for (int i = 0; i < dec.GetLength(0); i++)
                for (int j = 0; j < dec.GetLength(1); j++)
                {
                    dec[i, j] = Input("Element [" + i + "," + j + "]: ");
                    
                }

            Console.Clear();
            Print(dec);

            Console.WriteLine("Min is {0}", SearchMin(dec));
            Console.WriteLine("Max is {0}", SearchMax(dec));

            Console.WriteLine("\n\nAfter Max to Min function");
            MaxToMin(dec);
            Print(dec);

            Console.ReadKey();


        }



        static int SearchMin(int[,] dec)
        {
            int min = dec[0, 0];

            foreach (int it in dec)
                if (it < min)
                    min = it;

            return min;
        }
        static int SearchMax(int[,] dec)
        {
            int max = dec[0, 0];

            foreach (int it in dec)
                if (it > max)
                    max = it;

            return max;
        }
        static void MaxToMin(int[,] dec)
        {
            int min = SearchMin(dec);
            int max = SearchMax(dec);
            for (int i = 0; i < dec.GetLength(0); i++)
                for (int j = 0; j < dec.GetLength(1); j++)
                    if (dec[i, j] == max)
                        dec[i, j] = min;
        }

        static void Print(int[,] dec)
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

        static int Input(string text){
            int value;

            while (true)
            {
                Console.Write(text);
                try
                {
                    value = int.Parse(Console.ReadLine());
                    return value;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nWrong input. Try again\n");
                }

            }
        }
    }
}
