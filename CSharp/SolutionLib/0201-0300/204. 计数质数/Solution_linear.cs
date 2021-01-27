using System.Collections.Generic;

namespace SolutionLib._204._计数质数
{
    public class Solution_linear
    {
        public int CountPrimes(int n)
        {
            var primes = new List<int>();
            var notPrime = new bool[n];
            for (int i = 2; i < n; i++)
            {
                if (!notPrime[i])
                    primes.Add(i);
                for (int j = 0; j < primes.Count && i * primes[j] < n; j++)
                {
                    notPrime[i * primes[j]] = true;
                    if (i % primes[j] == 0) break;
                }
            }
            return primes.Count;
        }
    }
}