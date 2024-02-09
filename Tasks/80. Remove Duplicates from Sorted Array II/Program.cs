using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = Convert.ToInt32(Console.ReadLine());
            int[] nums = new int[size];

            for (int i = 0; i < size; i++)
            {
                nums[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine(RemoveDuplicates(nums));
        }

        static int RemoveDuplicates(int[] nums)
        {
            int k = 0, l = 0;
            int c = 0;

            for (int r = 0; r < nums.Length; r++)
            {
                if (r < nums.Length - 1)
                {
                    if (nums[r] == nums[r + 1])
                    {
                        c++;
                        if (l != 0 && c <= 2)
                        {
                            nums[l] = nums[r];
                            l++;
                            k++;
                        }
                        else
                        {
                            if (c <= 2)
                                k++;
                            else
                            {
                                if(l==0)
                                l = r;
                            }
                        }
                    }
                    else
                    {
                        if (c >= 2)
                        {
                            if (l == 0)
                                l = r;
                        }
                        else
                           if (l != 0)
                        {
                            nums[l] = nums[r];
                            l++;
                            k++;
                        }
                        else
                            k++;
                        c = 0;

                    }
                }
                else
                    if (c < 2 && l != 0)
                {
                    nums[l] = nums[r];
                    k++;
                }
                else
                    if (c < 2)
                    k++;

            }
            return k;
        }
    }
}
