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
            string s = Console.ReadLine();
            string t = Console.ReadLine();

            Console.WriteLine(IsSubsequence(s,t));
        }
        static bool IsSubsequence(string s, string t)
        {
            bool c = true;
            int o = -1;

            for (int i = 0; i < s.Length; i++)
            {
                o = t.IndexOf(s[i]);
                if(o < 0)
                    return false;
                else
                    t=t.Substring(o+1);
            }
            return c;
        }
    }
}
