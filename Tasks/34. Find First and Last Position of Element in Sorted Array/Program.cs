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
            int[] nums = new int[m];
            int target = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < m; i++)
                nums[i] = Convert.ToInt32(Console.ReadLine());
            int[] sol = solution.SearchRange(nums, target);
            for (int i = 0; i < sol.Length; i++)
                Console.WriteLine(sol[i]);
        }
        public class Solution
        {
            public int[] SearchRange(int[] nums, int target)
            {
                int[] sol = new int[2] { -5, -5 };
                int r = nums.Length - 1;
                int l = 0;
                int middle;
                if (nums.Length > 0)
                    while (sol[0] == -5 || sol[1] == -5)
                    {
                        middle = (r + l) / 2;
                        if (nums[middle] > target)
                            r = middle;
                        else
                            if (nums[middle] < target)
                            l = middle;
                        else
                        {
                            if (nums[l] == target)
                                sol[0] = l;
                            else
                            if (middle != 0 && nums[middle - 1] == target)
                            {
                                int ll = l;
                                int rr = middle;
                                while (rr - ll != 1)
                                {
                                    middle = (rr + ll) / 2;
                                    if (nums[middle] < target)
                                    {
                                        ll = middle;
                                    }
                                    else
                                        rr = middle;
                                }
                                sol[0] = rr;
                                l = rr;
                            }
                            else
                            {
                                sol[0] = middle;
                                l = middle;
                            }
                            if (r - l == 1 && nums[r] != target)
                            {
                                sol[1] = l;
                                return sol;
                            }
                            if (nums[r] == target)
                            {
                                sol[1] = r;
                                return sol;
                            }
                            while (r - l != 1)
                            {
                                middle = (r + l) / 2;
                                if (nums[middle] == target)
                                {
                                    l = middle;
                                }
                                else
                                    r = middle;
                                if (r - l == 1 && nums[r] != target)
                                {
                                    sol[1] = l;
                                    return sol;
                                }
                            }
                            sol[1] = l;
                            return sol;

                        }
                        if ((r - l) == 1 || r - l == 0)
                        {
                            if(nums[r] != target && nums[l] != target)
                            {
                                sol[0] = -1;
                                sol[1] = -1;
                                return sol;
                            }
                              else
                            {
                                if(nums[r]== target && nums[l] == target)
                                {
                                    sol[0] = l;
                                    sol[1] = r;
                                    return sol;
                                }
                                if (nums[r] != target && nums[l] == target)
                                {
                                    sol[0] = l;
                                    sol[1] = l;
                                    return sol;
                                }
                                if (nums[r] == target && nums[l] != target)
                                {
                                    sol[0] = r;
                                    sol[1] = r;
                                    return sol;
                                }
                            }
                        }

                    }
                sol[0] = -1;
                sol[1] = -1;
                return sol;
            }
        }
    }

}
