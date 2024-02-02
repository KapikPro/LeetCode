using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                Solution();
                Console.WriteLine();
            }
        }

        static void Solution()
        {
            int quantity = Convert.ToInt32(Console.ReadLine());
            string line, sign, trigger = "1";
            int l = 15, r = 30, number;

            for (int i = 0; i < quantity; i++)
            {
                line = Console.ReadLine();
                sign = line.Remove(2);
                number = int.Parse(line.Remove(0, 3));
                Console.WriteLine(Choise(number, sign, ref l, ref r, ref trigger));
            }
        }
        static string Choise(int number, string sign, ref int l, ref int r, ref string trigger)
        {
            if (trigger == "-1")
                return trigger;
            if (string.Compare(sign, "<=") == 0)
            {
                if (number >= l)
                {
                    if (number < r)
                        r = number;
                    return r.ToString();
                }
                else
                {
                    trigger = "-1";
                    return trigger;
                }
            }
            else
            {
                if (number <= r)
                {
                    if (number > l)
                        l = number;
                    return l.ToString();
                }
                else
                {
                    trigger = "-1";
                    return trigger;
                }
            }
        }
    }
}