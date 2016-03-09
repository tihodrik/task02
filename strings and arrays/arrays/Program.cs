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

            n = Input("Enter number of rows", 1);
            m = Input("Enter number of columns", 1);

			// Инициализация исходнго массива
			Console.Clear();
            int[,] dec = new int[n, m];
			
			for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    dec[i, j] = Input("Element [" + i + "," + j + "]");
                    
                }

			Console.Clear();
			Print(dec, "Init matrix");


			// Поиск максмального и минимального элементов
			Console.WriteLine("Min is {0}", SearchMin(dec));
			Console.WriteLine("Max is {0}", SearchMax(dec));
			Console.WriteLine("\n\n");
			Console.ReadKey();
			Console.Clear();

			// Поиск нескольких минимальных элементов
			int nMin = Input("Number of min elements to find", 1, n * m);
			int[] minN = SearchMinN(nMin, dec);

			// Поиск нескольких максимальных элементов
			int nMax = Input("Number of max elements to find", 1, n * m);
			int[] maxN = SearchMaxN(nMax, dec);

			Print(dec);
			Print(minN, "Min");
			Print(maxN, "Max");
			Console.ReadKey();


			// Замена максимального элемента минимальным
			Console.Clear();
			Print(dec, "Dec before MinToMax function");
			MaxToMin(dec);
			Print(dec, "Dec after MinToMax function");

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

        static void Print(int[,] dec, string text = "Dec")
        {
            Console.Write("\n" + text + "\n\n");
            for (int i = 0; i < dec.GetLength(0); i++)
            {
                for (int j = 0; j < dec.GetLength(1); j++)
                    Console.Write("{0}\t", dec[i, j]);
                Console.Write("\n\n");
            }
            Console.Write("\n");
        }
		static void Print(int[] array, string text = "")
		{
			Console.Write("\n" + text + "\n\n");
			for (int i = 0; i < array.GetLength(0); i++)
			{
				Console.Write("{0}\t", array[i]);
			}
			Console.Write("\n");
		}


        static int Input(string text, int min = Int32.MinValue, int max = Int32.MaxValue){
            int value;

            while (true)
            {
                Console.Write(text + ": ");
                try
                {
                    value = int.Parse(Console.ReadLine());
					if (value < min || value > max)
						throw new FormatException();
                    return value;
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nWrong input. Try again\n");
                }

            }
        }
		
        static int[] SearchMinN(int number, int[,] dec)
        {
			// min[0] <= min [1] <= ... <= min[number]
            int[] min = new int[number];
           
			int max = SearchMax(dec);
			for (int i = 0; i < number; i++)
				min[i] = max;

			for (int i=0; i < dec.GetLength(0); i++)			// массив не отсортирован - придется пройтись по каждому элементу
				for (int j = 0; j < dec.GetLength(1); j++)
				{
					if (dec[i, j] > min[number - 1])			// если текущий элемент больше самого большого из min,
						continue;								// то такой элемент нам заведомо не подходит

					for (int k = 0; k < number; k++)			// иначе сравниваем с каждым из min
						if (dec[i, j] < min[k])
						{
							for (int l = number - 1; l > k; l--)	// приходится делать сдвиг
								min[l] = min[l-1];

							min[k] = dec[i, j];
							
							break;
						}
				}
			return min;
        }
		static int[] SearchMaxN(int number, int[,] dec)
		{
			// max[0] >= max [1] >= ... >= max[number]
			int[] max = new int[number];

			int min = SearchMin(dec);
			for (int i = 0; i < number; i++)
				max[i] = min;

			for (int i = 0; i < dec.GetLength(0); i++)			// массив не отсортирован - придется пройтись по каждому элементу
				for (int j = 0; j < dec.GetLength(1); j++)
				{
					if (dec[i, j] < max[number - 1])			// если текущий элемент меньше самого маленького из max,
						continue;								// то такой элемент нам заведомо не подходит

					for (int k = 0; k < number; k++)			// иначе сравниваем с каждым из max
						if (dec[i, j] > max[k])
						{
							for (int l = number - 1; l > k; l--)	// приходится делать сдвиг
								max[l] = max[l - 1];

							max[k] = dec[i, j];

							break;
						}
				}
			return max;
		}
    }
}
