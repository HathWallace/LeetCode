namespace SolutionLib._605._种花问题
{
    public class Solution
    {
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            int pref = -2, count = 0, empty = 0;
            for (int i = 0; i < flowerbed.Length; i++)
            {
                if (flowerbed[i] == 0) continue;
                empty = i - pref - 1;
                if (empty != 0) count += empty / 2 - (empty + 1) % 2;
                pref = i;
            }

            if (pref < 0)
                empty = flowerbed.Length + 2;
            else
                empty = flowerbed.Length - pref;
            if (empty != 0) count += empty / 2 - (empty + 1) % 2;
            return count >= n;
        }
    }

    public class _Solution
    {
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            if (flowerbed.Length == 1)
            {
                return flowerbed[0] == 0 || flowerbed[0] == 1 && n == 0;
            }
            int remain = n;
            for (int i = 0; i < flowerbed.Length && remain > 0; i++)
            {
                if (flowerbed[i] == 1) continue;
                if (i == 0 && flowerbed[i + 1] == 0 || i == flowerbed.Length - 1 && flowerbed[i - 1] == 0 || i != 0 && i != flowerbed.Length - 1 && flowerbed[i - 1] == 0 && flowerbed[i + 1] == 0)
                {
                    remain--;
                    flowerbed[i] = 1;
                }
            }
            return remain == 0;
        }
    }
}