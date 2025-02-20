using System.Drawing;

public class Solution
{
    public static void Main()
    {
        Console.WriteLine(CanJump(new int[] { 8,2,4,4,4,9,5,2,5,8,8,0,8,6,9,1,1,6,3,5,1,2,6,6,0,4,8,6,0,3,2,8,7,6,5,1,7,0,3,4,8,3,5,9,0,4,0,1,0,5,9,2,0,7,0,2,1,0,8,2,5,1,2,3,9,7,4,7,0,0,1,8,5,6,7,5,1,9,9,3,5,0,7,5 }));
    }

    public static bool CanJump(int[] nums)
    {
        Queue<Pair> queue = new Queue<Pair>();
        HashSet<int> visited = new HashSet<int>();
        Pair first = new Pair(nums[0], 0);
        if(nums.Length == 1)
            return true;
        queue.Enqueue(first);
        visited.Add(0);

        while (queue.Count > 0)
        {
            first = queue.Dequeue();
            if (first.Level + 1 < nums.Length)
                for (int i = first.Level + 1; i <= first.Value + first.Level; i++)
                {
                    if (i == nums.Length - 1)
                        return true;
                    if (!visited.Contains(i))
                    {
                        Pair pair = new Pair(nums[i], i);
                        queue.Enqueue(pair);
                        visited.Add(i);
                        if (i + 1 == nums.Length)
                            break;
                    }
                }
        }

        return false;
    }
}

class Pair(int value, int level)
{
    public int Value { get; set; } = value;
    public int Level { get; set; } = level;
}