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
            List<string> list = new List<string>();
            int t = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                Solution(list);
                foreach (string word in list)
                    Console.Write(word);
                Console.WriteLine("-");
                list.Clear();
            }
        }

        static void Solution(List<string> list)
        {
            string line = Convert.ToString(Console.ReadLine()), line_au;
            int cursor = 0, number_l = 0;
            string pattern_Common = @"[A-Za-z]|[0-9]", pattern = @"L|R|U|D|B|E|N";
            Match match;
            list.Add("\n");

            for (int i = 0; i < line.Length; i++)
            {

                match = Regex.Match(line[i].ToString(), pattern_Common);
                if (match.Success)
                {
                    match = Regex.Match(line[i].ToString(), pattern);
                    if (match.Success)
                    {

                        switch (line[i].ToString())
                        {
                            case "L":
                                if (cursor - 1 >= 0)
                                    cursor--;
                                break;
                            case "R":
                                if (cursor + 1 <= list[number_l].Length)
                                    if ((cursor + 1 == list[number_l].Length && list[number_l][list[number_l].Length - 1] != '\n') || cursor + 1 != list[number_l].Length)
                                        cursor++;
                                break;
                            case "U":
                                if (number_l - 1 >= 0)
                                {
                                    if (list[number_l][list[number_l].Length - 1] != '\n')
                                        list[number_l] += '\n';
                                    number_l--;

                                    if (list[number_l].Length - 1 < cursor)
                                    {
                                        if (list[number_l][list[number_l].Length - 1] != '\n')
                                            cursor = list[number_l].Length;
                                        else
                                            cursor = list[number_l].Length - 1;
                                    }
                                }
                                break;
                            case "D":
                                if (number_l + 1 < list.Count)
                                {
                                    if (list[number_l][list[number_l].Length - 1] != '\n')
                                        list[number_l] += '\n';
                                    number_l++;
                                    if (list[number_l].Length-1 < cursor)
                                        if (list[number_l][list[number_l].Length - 1] != '\n')
                                            cursor = list[number_l].Length;
                                        else
                                            cursor = list[number_l].Length - 1;
                                }
                                break;
                            case "B":
                                cursor = 0;
                                break;
                            case "E":
                                    if (list[number_l][list[number_l].Length - 1] != '\n')
                                        cursor = list[number_l].Length;
                                    else
                                        cursor = list[number_l].Length - 1;
                                break;
                            case "N":
                                    if (list[number_l][list[number_l].Length - 1] != '\n')
                                        list[number_l] += '\n';
                                number_l++;
                                list.Insert(number_l, "");
                                if (cursor == list[number_l - 1].Length)
                                    cursor = 0;
                                else
                                {
                                    line_au = list[number_l - 1].Substring(0, cursor) + '\n';
                                    list[number_l] = list[number_l - 1].Substring(cursor);
                                    list[number_l - 1] = line_au;
                                    cursor = 0;
                                }
                                break;
                        }
                    }
                    else
                    {
                            line_au = list[number_l].Substring(0, cursor) + line[i];
                            list[number_l] = line_au + list[number_l].Substring(cursor);
                            cursor++;
                    }
                }
                if (i == line.Length - 1)
                {
                    if (list[number_l].Length > 0)
                    {
                        if (list[number_l][list[number_l].Length - 1] != '\n')
                            list[number_l] += '\n';
                    }
                    else
                        list[number_l] += '\n';

                }
            }
        }
    }
}