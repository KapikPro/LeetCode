using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string haystack = Console.ReadLine();
            string needle = Console.ReadLine();

            Console.WriteLine(StrStr(haystack,needle));
        }
        static int StrStr(string haystack, string needle)
        {
            int k = -1;

            k=haystack.IndexOf(needle);
            return k;
        }
    }
}
