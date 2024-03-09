using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int k;
        var line = Console.ReadLine();
        var arr = line.Split(':');
        int a = int.Parse(arr[0]);
        int b = int.Parse(arr[1]);

        line = Console.ReadLine();
        arr = line.Split(':');
        int c = int.Parse(arr[0]);
        int d = int.Parse(arr[1]);

        int sw = Convert.ToInt32(Console.ReadLine());

        if (sw == 1)
        {
            k = a;
            a = c;
            c = k;

            k = b;
            b = d;
            d = k;
        }

        if (a + c > b + d || ((a > d) && (a + c == b + d) && (a + c != 0)))
        {
            Console.WriteLine(0);
        }
        else
        {
            if (a>d && sw == 1 && a+b+c+d!=0)
                Console.WriteLine((b + d) - (a + c));
            else
            {
              Console.WriteLine((b + d) - (a + c) + 1);
            }
        }
    }
}


