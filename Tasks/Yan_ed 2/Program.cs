
internal class Program
{

    static int Solution(int n, int m, List<string> list) 
{

        int n = Convert.ToInt32(Console.ReadLine());
        int k = Convert.ToInt32(Console.ReadLine());
        float solution=1;
        int b=(n+k-1);
        for (int i=1;i<=b;i++)
            solution*=i;
        b=k;
        for(int i=1;i<=b;i++)
            solution/=(float)i;
        b=n-1;
        for(int i=1;i<=b;i++)
            solution/=(float)i;
        Console.WriteLine((int)solution);
    }
}