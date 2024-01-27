using System.Numerics;

int MinSubArrayLen(int target, int[] nums)
{
    int l = 0, r = 0, sum=nums[l], len=1,lengl=0,plus=0;
    while(r<nums.Length)
    {
        while(sum<target)
        {
            if (r + 1 == nums.Length)
            {
                return lengl;
            }
            r++;
            sum += nums[r];
            len++;
        }
        while(sum>=target)
        {
            l++;
            len--;
            sum -= nums[l-1];
            if(sum<target)
                plus = 1;
        }
        if (lengl == 0 && (sum>=target || plus==1))
            lengl = len+plus;
        else
        lengl=Math.Min(lengl,len+plus);
        plus = 0;
    }
    return lengl ;
}

int size = Convert.ToInt32(Console.ReadLine());
int[] nums = new int[size];
int target = Convert.ToInt32(Console.ReadLine());
for(int i = 0;i< nums.Length;i++)
    nums[i]=Convert.ToInt32(Console.ReadLine());
Console.WriteLine(MinSubArrayLen(target, nums));
