
using var input = new StreamReader(Console.OpenStandardInput());
using var output = new StreamWriter(Console.OpenStandardOutput());

int t = int.Parse(input.ReadLine() ?? "0");
for (int i = 0; i < t; i++)
{
    List<Level> levels = new List<Level>();
    List<int> quantity = input.ReadLine()!.Split(' ').Select(int.Parse).ToList();
    List<int> ab = new List<int>();
    int n = quantity[0];
    int m = quantity[1];
    Dictionary<int, int> numbers = new Dictionary<int, int>();
    Dictionary<int, int> kol = new Dictionary<int, int>();
    for (int j = 0; j < m; j++)
    {
        ab = input.ReadLine()!.Split(' ').Select(int.Parse).ToList();
        levels.Add(new Level(ab[0], ab[1]));
        if (!numbers.ContainsKey(ab[0]))
        {
            numbers.Add(ab[0], 0);
            kol.Add(ab[0], 1);
        }
        else
        {
            kol[ab[0]]++;
        }
        if (!numbers.ContainsKey(ab[1]))
        {
            numbers.Add(ab[1], 0);
            kol.Add(ab[1], 1);
        }
        else
        {
            kol[ab[1]]++;
        }
    }
    ab.Clear();
    numbers = numbers.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

    for (int j = 0; j < levels.Count; j++)
    {
        if (numbers[levels[j].a] == 0 && numbers[levels[j].b] == 0)
        {
            numbers[levels[j].a]=1;
            numbers[levels[j].b]=1;
            ab.Add(j+1);
        }
        else
        if (numbers[levels[j].a] == 1 && numbers[levels[j].b] == 0)
        {
            if (kol[levels[j].a] > kol[levels[j].b])
            {
                numbers[levels[j].a]=0;
                numbers[levels[j].b]=1;
                ab.Add(j+1);
            }
        }
        else
        if (numbers[levels[j].a] == 0 && numbers[levels[j].b] == 1)
        {
            if (kol[levels[j].b] > kol[levels[j].a])
            {
                numbers[levels[j].a]=1;
                numbers[levels[j].b]=0;
                ab.Add(j+1);
            }
        }
    }
    output.WriteLine(numbers.Where(x => x.Value == 1).Count());
    output.WriteLine(ab.Count);
    foreach (var a in ab)
    {
        output.Write(a+" ");
    }
    output.Write('\n');
}

class Level
{
    public int a;
    public int b;

    public Level(int _a, int _b)
    {
        a = _a;
        b = _b;
    }
}