namespace SolutionLib._135._分发糖果
{
    public class Solution
    {
        public int Candy(int[] ratings)
        {
            int res = 1, makeup = 1, precandy = 1, mcandy = 1;
            for (int i = 1; i < ratings.Length; i++)
                res += ratings[i - 1] < ratings[i] ? mcandy = precandy += makeup = 1 : ratings[i - 1] == ratings[i] ? mcandy = precandy = makeup = 1 : mcandy == makeup++ ? ++mcandy : makeup - (precandy = 1);
            return res;
        }
    }

    public class __Solution
    {
        public int Candy(int[] ratings)
        {
            int res = 1, makeup = 1, precandy = 1, mcandy = 1;
            for (int i = 1; i < ratings.Length; i++)
                if (ratings[i - 1] < ratings[i])
                    res += mcandy = precandy += makeup = 1;
                else if (ratings[i - 1] == ratings[i])
                    res += mcandy = precandy = makeup = 1;
                else
                    res += mcandy == makeup++ ? ++mcandy : makeup - (precandy = 1);
            return res;
        }
    }

    public class _Solution
    {
        public int Candy(int[] ratings)
        {
            var candies = new int[ratings.Length];
            candies[0] = 1;
            for (int i = 1; i < ratings.Length; i++)
                if (ratings[i - 1] < ratings[i])
                    candies[i] = candies[i - 1] + 1;
                else if (ratings[i - 1] == ratings[i])
                    candies[i] = 1;
                else
                {
                    candies[i] = 1;
                    for (int j = i - 1; j >= 0 && candies[j] <= candies[j + 1] && ratings[j] > ratings[j + 1]; j--)
                        candies[j]++;
                }
            int res = 0;
            for (int i = 0; i < candies.Length; i++) res += candies[i];
            return res;
        }
    }
}
