class Program
{
    static void Main()
    {
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine(Solution.Reverse(x));
    }

    public class Solution
    {
        public static int Reverse(int x)
        {
            string xs = x.ToString(), ress = "", max = int.MaxValue.ToString(), min = int.MinValue.ToString();
            bool flag = false;

            if (xs[0] == '-')
            {
                ress += '-';
                if (xs.Length == min.Length)
                    for (int i = xs.Length - 1; i > 0; i--)
                    {
                        int chx = int.Parse(xs[i].ToString());
                        int chmin = int.Parse(min[min.Length - i].ToString());
                        
                        if (!(ress == "-" && i != 1 && xs[i] == '0'))
                            ress += xs[i];

                        if (chx > chmin && flag == false)
                            return 0;
                        if (chx < chmin)
                            flag = true;
                    }
                else
                {
                    for (int i = xs.Length - 1; i > 0; i--)
                    {
                        if (!(ress == "-" && i != 1 && xs[i] == '0'))
                            ress += xs[i];
                    }
                }
            }
            else
            {
                if (xs.Length == max.Length)
                    for (int i = xs.Length - 1; i >= 0; i--)
                    {
                        int chx = int.Parse(xs[i].ToString());
                        int chmax = int.Parse(max[max.Length - i - 1].ToString());

                        if (!(ress == "" && i != 0 && xs[i] == '0'))
                            ress += xs[i];

                        if (chx > chmax && flag == false)
                            return 0;
                        if (chx < chmax)
                            flag = true;
                    }
                else
                {
                    for (int i = xs.Length - 1; i >= 0; i--)
                    {
                        if (!(ress == "" && i != 0 && xs[i] == '0'))
                            ress += xs[i];
                    }
                }
            }

            int res = int.Parse(ress);
            return res;
        }
    }
}
