using BenchmarkDotNet.Attributes;

namespace LinqBench;

/// <summary>
/// 検索用データ保持クラス
/// </summary>
public class TestClass
{
    public int Prop1 { get; set; }

    public int Prop2 { get; set; }
}

[MemoryDiagnoser]
public class WhereAndFirst
{
    private List<TestClass>? _list;

    [GlobalSetup]
    public void Setup()
    {
        _list = Enumerable.Range(0, 10000).Select(x => new TestClass { Prop1 = x }).ToList();
    }

    [Benchmark]
    public TestClass ToListCultist()
    {
        var narrowedList = _list!.Where(x => x.Prop1 > 4000).ToList();
        return narrowedList.First(x => x.Prop1 == 4345);
    }

    [Benchmark]
    public TestClass Normal()
    {
        var narrowedEnumerable = _list!.Where(x => x.Prop1 > 4000);
        return narrowedEnumerable.First(x => x.Prop1 == 4345);
    }
}
