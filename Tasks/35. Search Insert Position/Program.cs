int SearchInsert(int[] nums, int target)
{
    int l = 0, r = nums.Length - 1;
    int p_sum;
    while (r - l > 1 && nums[r] != target)
    {
        p_sum = (l + r) / 2;
        if (nums[p_sum] >= target)
            r = p_sum;
        else
            l = p_sum;
    }
    if (nums[r] >= target && (nums[l] < target || r==0))
        return r;
    else
        if (nums[l] < target || r==0)
        return r + 1;
    else
        return r-1;
}
int size = Convert.ToInt32(Console.ReadLine());
int[] nums = new int[size];
int target = Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < nums.Length; i++)
    nums[i] = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(SearchInsert(nums, target));

