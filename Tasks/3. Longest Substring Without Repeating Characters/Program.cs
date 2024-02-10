using System;
using System.Collections;
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

            Console.WriteLine(LengthOfLongestSubstring(s));
        }
        static int LengthOfLongestSubstring(string s)
        {
            int length = 0;
            ArrayList list = new ArrayList();
            for (int i = 0; i < s.Length; i++)
            {
                if (list.Contains(s[i]))
                {
                    if (list.Count > length)
                        length = list.Count;
                    list.RemoveRange(0, list.IndexOf(s[i])+1);
                    list.Add(s[i]);
                }
                else
                    list.Add(s[i]);
            }
            if (list.Count > length)
                length = list.Count;
            return length;
        }
    }
}
