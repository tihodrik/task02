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
            char[] s1 = new char[] { 'A', 'B', 'F', 'H', 'E', 'D' };
            StringBuilder s2 = new StringBuilder();

            int i = 1;
            foreach (char it in s1)
            {
                s2.Append(it);
                Console.WriteLine("s2 ({0}): {1}", i++, s2);
            }

            s2.Replace('F', 'C');
            Console.WriteLine("\ns2 after replacement: {0}", s2);

            s2.Remove(3, 2);
            Console.WriteLine("s2 after removing: {0}", s2);

            s2.Insert(4, "EFG");
            Console.WriteLine("s2 after insertion: {0}", s2);

            Console.ReadKey();
        }
    }
}
