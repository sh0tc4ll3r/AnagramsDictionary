using System.Collections;
using System.Diagnostics;

class Program
{
    static ulong HashMemory(string str)
    {
        ulong auxValue = 1;
        byte[] primes =
            { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101 };

        foreach (var ch in str)
        {
            switch (ch)
            {
                case >= 'A' and <= 'Z':
                    auxValue *= primes[ch - 'A'];
                    break;
                case >= 'a' and <= 'z':
                    auxValue *= primes[ch - 'a'];
                    break;
                default:
                    continue;
            }
        }

        return auxValue;
    }

    static void Main(string[] args)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Restart();
        var hashTable = new Dictionary<ulong, string>();

        var sr = new StreamReader("documents/English.txt");

        while (sr.Peek() >= 0)
        {
            var presentLine = sr.ReadLine();
            var cleanWord = string.Concat(presentLine.Split('/')[0]);
            var hash = HashMemory(cleanWord);
            if (hashTable.ContainsKey(hash))
            {
                hashTable[hash] = $"{hashTable[hash]}, {cleanWord}";
            }
            else
            {
                hashTable.Add(hash, cleanWord);
            }
        }

        var noSingles = new Dictionary<ulong, string>();

        foreach (var potentialAnagram in hashTable)
        {
            if (!potentialAnagram.Value.Contains(',')) continue;
            {
                noSingles.Add(potentialAnagram.Key, potentialAnagram.Value);
            }
        }
        //
        // var counter = 1;
        // foreach (var pair in noSingles)
        // {
        //     counter++;
        //     Console.Write(counter);
        //     Console.WriteLine(pair);
        // }

        Console.WriteLine(stopwatch.ElapsedMilliseconds);
    }
}