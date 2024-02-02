using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
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
            List<int> list = new List<int>();

            for (int i = 0; i < t; i++)
            {
                Solution(ref list);
                Console.WriteLine(list.Count);
                for (int j = 0; j < list.Count; j++)
                    Console.Write(list[j] + " ");
                Console.Write('\n');
                list.Clear();
            }
        }

        static void Solution(ref List<int> list)
        {
            int quantity = Convert.ToInt32(Console.ReadLine());
            int[] nums = new int[quantity];
            int l = 0, condition = 0;
            var line = Console.ReadLine();
            var arr = line.Split(' ');

            for (int i = 0; i < quantity; i++)
            {
                nums[i] = int.Parse(arr[i]);
            }
            if (nums.Length > 1)
            {
                condition = 0;
                list.Add(nums[0]);
                if (nums[0] == nums[1] + 1)
                    condition = -1;
                else
                    if (nums[0] == nums[1] - 1)
                    condition = 1;
                else
                {
                    condition = 0;
                }
                if (nums.Length == 2)
                {
                    if (condition == 0)
                    {
                        list.Add(0);
                        list.Add(nums[1]);
                        list.Add(0);
                    }
                    else
                        list.Add(Out(condition, nums, 1, l));
                }
                for (int r = 1; r < nums.Length - 1; r++)
                {

                    if (nums[r] == nums[r + 1] + 1)
                    {
                        if (l == r)
                            condition = -1;
                        else
                        if (condition != -1)
                        {
                            list.Add(Out(condition, nums, r, l));
                            if (condition != 0)
                            {
                                l = r + 1;
                                list.Add(nums[r + 1]);
                            }
                            else
                            {
                                condition = -1;
                                l = r;
                                list.Add(nums[r]);
                            }
                        }

                    }
                    else
                          if (nums[r] == nums[r + 1] - 1)
                    {
                        if (l == r)
                            condition = 1;
                        else
                        if (condition != 1)
                        {
                            list.Add(Out(condition, nums, r, l));
                            if (condition != 0)
                            {
                                l = r + 1;
                                list.Add(nums[r + 1]);
                            }
                            else
                            {
                                condition = 1;
                                l = r;
                                list.Add(nums[r]);
                            }
                        }
                    }
                    else
                    {
                        if (condition == 0)
                        {
                            if (l == r)
                            {
                                condition = 0;
                            }
                            else
                            {
                                list.Add(Out(condition, nums, r, l));
                                condition = 0;
                                list.Add(nums[r]);
                            }
                        }
                        else
                        {
                            list.Add(Out(condition, nums, r, l));
                            l = r + 1;
                            list.Add(nums[r + 1]);
                        }
                    }
                    if ((r == nums.Length - 2) || (r == nums.Length - 1))
                    {
                        if (condition != 0)
                        {
                            r++;
                            list.Add(Out(condition, nums, r, l));
                        }
                        else
                        {
                            list.Add(Out(condition, nums, r, l));
                            list.Add(nums[r + 1]);
                            list.Add(0);
                        }
                    }
                }
            }
            else
            {
                list.Add(nums[0]);
                list.Add(0);
                return;
            }
        }

        static int Out(int condirion, int[] nums, int r, int l)
        {
            switch (condirion)
            {
                case 0:
                    return 0;
                case 1:
                    return nums[r] - nums[l];
                case -1:
                    return nums[r] - nums[l];
            }
            return 0;
        }
    }
}