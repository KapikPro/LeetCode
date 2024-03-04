using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        int sum = 0,a;
        int count=Convert.ToInt32(Console.ReadLine());
        for(int i=0; i<count; i++)
        {
            a= Convert.ToInt32(Console.ReadLine());
            sum += a / 4;
            a = a % 4;
            if (a > 1 && a <= 3)
                sum += 2;
            else
                if(a==1)
                sum++;
        }
        Console.WriteLine(sum);
    }
}


