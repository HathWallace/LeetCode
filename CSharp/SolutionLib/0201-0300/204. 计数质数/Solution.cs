namespace SolutionLib._204._计数质数
{
    public class Solution2
    {
        public int CountPrimes(int n)
        {
            int ans = 0;
            var notPrimes = new bool[n];
            for (int i = 2; i < n; i++)
            {
                if (notPrimes[i]) continue;
                ans++;
                long j = i;
                while (i * j < n)
                {
                    notPrimes[i * j] = true;
                    j++;
                }
            }
            return ans;
        }
    }

    public class Solution
    {
        public int CountPrimes(int n)
        {
            int ans = 0;
            for (int i = 2; i < n; i++)
                if (IsPrime(i))
                    ans++;
            return ans;
        }

        private bool IsPrime(int x)
        {
            for (int i = 2; i * i <= x; i++)
                if (x % i == 0)
                    return false;
            return true;
        }

    }
}