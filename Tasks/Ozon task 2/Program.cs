using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Text;
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
            int[] months = new int[12] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            var line = Console.ReadLine();
            var arr = line.Split(' ');
            int day, month, year;
            day = int.Parse(arr[0]);
            month = int.Parse(arr[1]);
            year = int.Parse(arr[2]);
            if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
            {
                months[1] = 29;
            }
            if (day <= months[month-1])
            {
                return "Yes";
            }
            else
                return "No";
        }
    }

}
