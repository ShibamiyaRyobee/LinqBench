using BenchmarkDotNet.Running;

namespace LinqBench;

internal class Program
{
    static void Main(string[] args)
    {
        BenchmarkRunner.Run<WhereAndFirst>();
    }
}
