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
            Console.WriteLine(ReverseWords(s));
        }
        static string ReverseWords(string s)
        {
            string[] words = s.Split(new char[] { ' ' });
            s = "";
            for (int i = words.Length - 1; i >= 0; i--)
            {
                if (words[i] != "")
                {
                    if (s == "")
                    {
                        words[i] = words[i].Trim();
                        s += words[i];
                    }
                    else
                    {
                        words[i] = words[i].Trim();
                        s += " " + words[i];
                    }
                }
            }
            return s;
        }
    }
}
