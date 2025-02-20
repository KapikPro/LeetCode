public class Solution
{
    public static void Main()
    {
        Console.WriteLine(RemoveDuplicates(new int[] { 1, 1, 2 }));
    }

    public static int RemoveDuplicates(int[] nums)
    {
        HashSet<int> hashSet = new HashSet<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            hashSet.Add(nums[i]);
        }

        nums = hashSet.ToArray();
        int k = nums.Length;
        return k;
    }
}