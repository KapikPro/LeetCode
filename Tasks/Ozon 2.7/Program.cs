using var input = new StreamReader(Console.OpenStandardInput());
using var output = new StreamWriter(Console.OpenStandardOutput());

int t = int.Parse(input.ReadLine() ?? "0");
for (int i = 0; i < t; i++)
{
    List<int> nm = input.ReadLine()!.Split(' ').Select(int.Parse).ToList();
    int n = nm[0];
    int m = nm[1];
    string s = "";
    Robot A = new Robot();
    Robot B = new Robot();
    List<List<Char>> field = new List<List<Char>>();
    for (int j = 0; j < n; j++)
    {
        s = input.ReadLine();
        field.Add(s.ToCharArray().ToList());
        if (s.Contains('A'))
        {
            A.x = s.IndexOf('A');
            A.y = j;
            A.name = 'A';
        }

        if (s.Contains('B'))
        {
            B.x = s.IndexOf('B');
            B.y = j;
            B.name = 'B';
        }
    }

    if (A.x <= B.x )
    {
        Solution(ref field, A, B, n, m, 1);
    }
    else
    {
        Solution(ref field, A, B, n, m, 0);
    }

    //output.Write('\n');
    for (int j = 0; j < field.Count; j++)
    {
        for (int k = 0; k < field[j].Count; k++)
        {
            output.Write(field[j][k]);
        }

        output.Write('\n');
    }
}

void Solution(ref List<List<Char>> field, Robot A, Robot B, int n, int m, int flag)
{
    char a = 'a';
    char b = 'b';
    if (flag == 0 || (B.x == 0 && A.y >= B.y)|| (A.x == m-1 && A.y > B.y))
    {
        a = 'b';
        b = 'a';
        Robot C = A;
        A = B;
        B = C;
    }

    if (A.y % 2 != 0)
    {
        if (A.y - 1 != B.y || A.x != B.x)
        {
            A.y--;
            field[A.y][A.x] = a;
            while (A.x != 0)
            {
                A.x--;
                field[A.y][A.x] = a;
            }

            while (A.y != 0)
            {
                A.y--;
                field[A.y][A.x] = a;
            }
        }
        else
        {
            A.y++;
            field[A.y][A.x] = a;
            while (A.x != 0)
            {
                A.x--;
                field[A.y][A.x] = a;
            }

            while (A.y != 0)
            {
                A.y--;
                field[A.y][A.x] = a;
            }
        }
    }
    else
    {
        while (A.x != 0)
        {
            A.x--;
            field[A.y][A.x] = a;
        }

        while (A.y != 0)
        {
            A.y--;
            field[A.y][A.x] = a;
        }
    }

    if (B.y % 2 != 0)
    {
        if (field[B.y + 1][B.x] != a && field[B.y + 1][B.x] != A.name)
        {
            B.y++;
            field[B.y][B.x] = b;
            while (B.x != m - 1)
            {
                B.x++;
                field[B.y][B.x] = b;
            }

            while (B.y != n - 1)
            {
                B.y++;
                field[B.y][B.x] = b;
            }
        }
        else
        {
            B.y--;
            field[B.y][B.x] = b;
            while (B.x != m - 1)
            {
                B.x++;
                field[B.y][B.x] = b;
            }

            while (B.y != n - 1)
            {
                B.y++;
                field[B.y][B.x] = b;
            }
        }
    }
    else
    {
        while (B.x != m - 1)
        {
            B.x++;
            field[B.y][B.x] = b;
        }

        while (B.y != n - 1)
        {
            B.y++;
            field[B.y][B.x] = b;
        }
    }
}

class Robot
{
    public int x { get; set; }
    public int y { get; set; }

    public char name { get; set; }
}