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
           int t=Convert.ToInt32(Console.ReadLine());
            for (int i=0; i<t; i++)
            {
                Console.WriteLine(Solution());
            }
        }
        static string Solution()
        {
            int[] fleet = new int[4] { 0, 0, 0, 0 };
                var line = Console.ReadLine();
                var arr = line.Split(' ');
            int boat;
            for (int i = 0; i < 10; i++)
            {
                boat = int.Parse(arr[i]);
                fleet[boat - 1]++;
                if (fleet[boat - 1] > (5 - boat))
                    return "No";
            }
            return "Yes";
        }
    }

}
