class Program
{
    static void Main()
    {
        Console.WriteLine("Цель:");
        int target = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите кол-во элементов в массиве:");
        int kol = int.Parse(Console.ReadLine());

        int[] arr = new int[kol];
        for (int i = 0; i < kol; i++)
        {
            Console.WriteLine("Введите число:");
            arr[i] = int.Parse(Console.ReadLine());
        }
        
        int[] result = Solution.TwoSum(arr, target);

        for (int i = 0; i < result.Length; i++)
        {
            Console.WriteLine(result[i] + " ");
        }
    }

    public class Solution
    {
        public static int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
                
            for (int i = 0; i < nums.Length; i++)
            {
                dict.Add(i, nums[i]);
            }
                
            List<KeyValuePair<int, int>> sortedDict = new List<KeyValuePair<int, int>>();
            if(dict.Values.Min()>0)
                sortedDict = dict.OrderBy(x => x.Value).Where(x => x.Value <= target).ToList();
            else
                sortedDict = dict.OrderBy(x => x.Value).ToList();
            int left = 0;
            int right = sortedDict.Count - 1;
            int sum = 0;

            while (right > left)
            {
                sum = sortedDict[left].Value + sortedDict[right].Value;
                    
                if(sum == target)
                    return [sortedDict[left].Key, sortedDict[right].Key];
                if (sum < target)
                    left++;
                else
                    right--;
            }
            return [0,0];
        }
    }
}