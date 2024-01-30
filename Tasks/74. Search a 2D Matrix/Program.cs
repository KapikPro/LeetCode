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
            Solution solution = new Solution();
            int m = Convert.ToInt32(Console.ReadLine());
            int n = Convert.ToInt32(Console.ReadLine());
            int[][] matrix = new int[m][];
            for (int i = 0; i < m; i++)
                matrix[i] = new int[n];
            int target = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < m; i++)
                for (int k = 0; k < n; k++)
                    matrix[i][k] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(solution.SearchMatrix(matrix, target));
        }
    }
    public class Solution
    {
        public bool SearchMatrix(int[][] matrix, int target)
        {
            int i = matrix.GetLength(0);
            int j = matrix.GetLength(1);
            for (int k = 0; k < j; k++)
            {
                int l = 0;
                int r = i - 1;
                while (l <= r)
                {
                    int m = (l + r) / 2;
                    if (matrix[m][k] == target)
                    {
                        return true;
                    }
                    if (matrix[m][k] < target)
                    {
                        l = m + 1;
                    }
                    else
                    {
                        r = m - 1;
                    }
                }
            }
            return false;
        }
    }

}
