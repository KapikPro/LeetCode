using var input = new StreamReader(Console.OpenStandardInput());
using var output = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(input.ReadLine());
for (int i = 0; i < n; i++)
{
    output.WriteLine(Solution());
}

string Solution()
{
    string x = input.ReadLine();
    if (x.Length == 1)
        return "0";

    List<int> nums = x.Select(c => int.Parse(c.ToString())).ToList();
    x = "";
    bool flag = false;

    for (int i = 1; i < nums.Count; i++)
    {
        if (nums[i - 1] < nums[i] && flag == false)
        {
            x += "";
            flag = true;
        }
        else
            x += nums[i - 1].ToString();

        if (i == nums.Count - 1)
        {
            if (flag == false)
                x += "";
            else
                x += nums[i].ToString();
        }
    }

    return x;
}