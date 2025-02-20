using System.Drawing;

public class Solution
{
    public static void Main()
    {
        Console.WriteLine(HIndex(new int[] { 0, 1, 1 }));
    }

    public static int HIndex(int[] citations)
    {
        Dictionary<int, int> dictionary = new Dictionary<int, int>();
        citations = citations.OrderByDescending(x => x).ToArray();
        int lastValue = 0;
        int last = citations[0];
        for (int i = 0; i < citations.Length; i++)
        {
            if (citations[i] != 0)
            {
                if (dictionary.ContainsKey(citations[i]))
                {
                    dictionary[citations[i]]++;
                }
                else
                {
                    dictionary.Add(citations[i], 1);
                }
            }
            else
            {
                if (!dictionary.ContainsKey(citations[i]))
                    dictionary.Add(citations[i], 0);
            }

            if (citations[i] != last)
            {
                dictionary[citations[i]] += dictionary[last];
                if (dictionary[citations[i]] > citations[i])
                {
                    if (dictionary[last] <= last)
                        return dictionary[last];
                    else
                    {
                        return last;
                    }
                }

                last = citations[i];
            }
        }

        if (dictionary[last] <= last)
            return dictionary[last];
        else
        {
            return last;
        }
    }
}