static List<long> GeneratePrimes(int n)
{
    List<bool> values = Enumerable.Repeat(true, n).ToList();

    for (int i = 2; i <= Math.Sqrt(n); i++)
        if (values[i])
            for (int j = i*i; j < n; j += i) values[j] = false;

    List<long> primes = values.Select((isPrime, index) => (isPrime, index)).Where(x => x.isPrime && x.index > 1).Select(x => (long)x.index).ToList();

    return primes;
}

static long SumRange(List<long> nums, int startIndex, int endIndex)
{
    return nums.Skip(startIndex).Take(endIndex-startIndex).Sum(x => (long)x);
}

static List<long> GetRange(List<long> nums, int startIndex, int endIndex)
{
    return nums.Skip(startIndex).Take(endIndex-startIndex).ToList();
}

static List<long> GeneratePrimeList(int target)
{
    List<long> primes = GeneratePrimes(target);

    int startIndex = 0;
    int endIndex = primes.Count - 1;
    long currentSum;

    while (true)
    {
        currentSum = SumRange(primes, startIndex, endIndex);
        
        if (currentSum > target)
        {
            endIndex -= 1;
            continue;
        }

        if (currentSum < target)
        {
            startIndex += 1;
            endIndex = primes.Count -1;
            continue;
        }

        if (currentSum == target) return GetRange(primes, startIndex, endIndex);
    }
}

static int GetLongestPrimeList(int below)
{
    List<long> currentMax = [];
    long maxPrime = 0;
    List<long> primes = GeneratePrimes(below);

    foreach (long prime in primes)
    {
        List<long> currentPrimeList = GeneratePrimeList(prime);
        Console.WriteLine(prime);
        if (currentMax.Count < currentPrimeList.Count) {
            currentMax = currentPrimeList;
            maxPrime = prime;
        }
    }

    return maxPrime;
}

Console.WriteLine(GetLongestPrimeList(100));