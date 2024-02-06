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
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp15
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                int k = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine(Solution(k));
            }
        }

        static string Solution(int k)
        {
            string line = Convert.ToString(Console.ReadLine());
            string[] all_Num = line.Split(new char[] { ',' });
            string pattern = @"\d+-\d+", pattern_b = @"\d+", answer = "";
            int[] pages = new int[k];
            Match match;
            int a, b, leng = 0;

            for (int i = 0; i < k; i++)
            {
                pages[i] = 0;
            }
            for (int i = 0; i < all_Num.Length; i++)
            {
                match = Regex.Match(all_Num[i], pattern);
                if (match.Success)
                {
                    match = Regex.Match(all_Num[i], pattern_b);
                    a = int.Parse(match.Value);
                    b = int.Parse(all_Num[i].Substring(match.Length + 1));
                    for (int l = a; l <= b; l++)
                    {
                        pages[l - 1] = 1;
                    }
                }
                else
                    pages[Convert.ToInt32(all_Num[i]) - 1] = 1;
            }
            for (int i = 0; i < pages.Length - 1; i++)
            {
                if (pages[i] == 1 && answer.Length > 0)
                    if (answer[answer.Length - 1] == '-')
                        answer += i.ToString();
                if (pages[i] == 0)
                {
                    if (pages[i + 1] == 0)
                    {
                        if (answer.Length > 0)
                        {
                            if (answer[answer.Length - 1] != '-')
                                answer += "," + (i + 1).ToString() + "-";
                        }
                        else
                            answer += (i + 1).ToString() + "-";
                    }
                    else
                    {
                        if (answer.Length > 0 && answer[answer.Length - 1] != '-')
                            answer += "," + (i + 1).ToString();
                        else
                            answer += (i + 1).ToString();
                    }
                }
            }
            if (answer.Length > 0)
            {
                if (answer[answer.Length - 1] == '-')
                    answer += (pages.Length).ToString();
                else
                 if (pages[pages.Length - 1] == 0)
                    answer +=","+ (pages.Length).ToString();
            }
            else
                 if (pages[pages.Length - 1] == 0)
                answer +=(pages.Length).ToString();
            return answer;
        }
    }
}