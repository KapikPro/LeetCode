using System;
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
                Console.WriteLine(Solution());
            }
        }
        static string Solution()
        {
            string answer = "", number;
            string pattern = @"^([A-Za-z]{1}\d{1,2}[A-Za-z]{2})";
            int k = 0;
            string line = Console.ReadLine();
            int size=line.Length;
            Match match = Regex.Match(line, pattern);
            while (line!="" && match.Success)
            {
                    k++;
                    number = match.Value;
                    line = line.Substring(number.Length);
                    answer += number + " ";
                     match = Regex.Match(line, pattern);
            }


            if (answer.Length - k == size)
                return answer;
            else
                return "-";
        }
    }

}