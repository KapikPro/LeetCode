using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;

internal class Program
{
    static void Main(string[] args)
    {
        var line = Console.ReadLine();
        var arr = line.Split(' ');
        int sum = 0, tree, meters, l, r;
        tree = int.Parse(arr[0]);
        meters = int.Parse(arr[1]);
        l = tree - meters;
        r = tree+meters;

        line = Console.ReadLine();
        arr = line.Split(' ');
        tree = int.Parse(arr[0]);
        meters = int.Parse(arr[1]);
        for (int i = Math.Min(l, tree - meters); i <= Math.Min(r, tree + meters); i++)
            sum++;
        if (Math.Min(r, tree + meters) == Math.Max(l, tree - meters))
            sum--;
        else
            if(Math.Max(l, tree - meters) < Math.Min(r, tree + meters))
                  sum -= -Math.Max(l, tree - meters) + Math.Min(r, tree + meters)+1;

        for (int i = Math.Max(l, tree - meters); i <= Math.Max(r, tree + meters); i++)
            sum++;
        Console.WriteLine(sum);
    }
}


