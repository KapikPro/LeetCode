public class Solution
{
    public int MaxProfit(int[] prices)
    {
        int min = 0, razn = 0, n_razn = 0;
        for (int i = 0; i < prices.Length; i++)
        {
            if (prices[i] < prices[min])
                min = i;
            n_razn = prices[i] - prices[min];
            if (razn < n_razn)
                razn = n_razn;
        }
        return razn;
    }
}
