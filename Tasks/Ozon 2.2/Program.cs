using var input = new StreamReader(Console.OpenStandardInput());
using var output = new StreamWriter(Console.OpenStandardOutput());

int n = int.Parse(input.ReadLine());
for (int i = 0; i < n; i++)
{
    int t = 0;
    string s = input.ReadLine();

    Console.WriteLine(Solution(s, t));
    //output.WriteLine(Solution(s, t));
}

string Solution(string s, int t)
{
    if (t == 0 && s[t] != 'M')
        return "NO";
    if (t == s.Length - 1)
    {
        if (s[t] != 'D')
            return "NO";
        else
        {
            if (t > 0 && s[t - 1] != 'M')
                return "NO";
            else
                return "YES";
        }
    }

    switch (s[t])
    {
        case 'M':
            if (t > 0 && (s[t - 1] == 'M'))
                return "NO";
            else
            {
                t++;
                return Solution(s, t);
            }

            break;
        case 'C':
            if (t > 0 && (s[t - 1] != 'R' && s[t - 1] != 'M'))
                return "NO";
            else
            {
                t++;
                return Solution(s, t);
            }

            break;
        case 'R':
            if (t > 0 && s[t - 1] != 'M')
                return "NO";
            else
            {
                t++;
                return Solution(s, t);
            }

            break;
        case 'D':
            if (t > 0 && s[t - 1] != 'M')
                return "NO";
            else
            {
                t++;
                return Solution(s, t);
            }

            break;
    }

    return "AAA1";
}