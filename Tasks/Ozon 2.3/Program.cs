using System.Runtime.Intrinsics.Arm;
using System.Text.RegularExpressions;

using var input = new StreamReader(Console.OpenStandardInput());
using var output = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(input.ReadLine());
for (int i = 0; i < n; i++)
{
    int t = 0;
    int quantity = int.Parse(input.ReadLine());
    string s2 = input.ReadLine();
    string s3 = input.ReadLine(); 
    //Console.WriteLine(Solution(quantity,s2,s3));
    output.WriteLine(Solution(quantity,s2,s3));
}

string Solution(int quantity, string s2, string s3)
{
    if(!new Regex(@"^-?(?:[1-9]\d{0,8}|0|1000000000)(?: -?(?:[1-9]\d{0,8}|0|1000000000))*$").IsMatch(s3))
        return "no";
    try
    {
        List<int> list = s2.Split(' ').Select(int.Parse).OrderBy(x => x).ToList();
        List<int> list2 = s3.Split(' ').Select(int.Parse).ToList();
        
        
        if (list2.Count != quantity || !list2.SequenceEqual(list))
        {
            return "no";
        }
    }
    catch
    {
        return "no";
    }
    return "yes";
}