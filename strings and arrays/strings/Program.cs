using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace strings
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] letArr = new char[] { 'A', 'B', 'F', 'H', 'E', 'D' };
            StringBuilder letStr = new StringBuilder();

            int i = 1;
            foreach (char it in letArr)
            {
                letStr.Append(it);
                Console.WriteLine("s2 ({0}): {1}", i++, letStr);
            }

            letStr.Replace('F', 'C');
            Console.WriteLine("\ns2 after replacement: {0}", letStr);

            letStr.Remove(3, 2);
            Console.WriteLine("s2 after removing: {0}", letStr);

            letStr.Insert(4, "EFG");
            Console.WriteLine("s2 after insertion: {0}", letStr);

            Console.ReadKey();
        }
    }
}
