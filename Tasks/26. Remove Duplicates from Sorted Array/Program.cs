public class Solution
{
    public int RemoveDuplicates(int[] nums)
    {
        int size = nums.Length;
        int max = nums[0];
        int pointer = -1;
        int k = 1;
        for (int i = 1; i < size; i++)
        {
            if (nums[i] == max)
            {
                nums[i] = 0;
                if (pointer == -1)
                    pointer = i;
            }
            else
              if (nums[i] > max)
            {
                k++;
                max = nums[i];
                if (pointer != -1)
                {
                    nums[pointer] = max;
                    pointer++;
                    nums[i] = 0;
                }
            }
        }
        return k;
    }
}