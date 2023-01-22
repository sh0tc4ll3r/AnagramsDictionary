using BenchmarkDotNet.Attributes;

namespace Kata.PerformanceTests;

public class BenchmarkAnagrams
{
    [Benchmark]
    public void SpeedPerformance()
    {
        Anagrams.ExtractAnagrams();
    }    
}