public class Solution
{
    public static void Main()
    {
        Rotate(new int[] { 1,2,3,4,5,6,7}, 3);
    }

    public static void Rotate(int[] nums, int k)
    {
        k = k % nums.Length;
        int[] numb = nums.Skip(nums.Length - k).Take(k).Concat(nums.Take(nums.Length - k)).ToArray();
        Array.Copy(numb, nums, nums.Length);
    }
}