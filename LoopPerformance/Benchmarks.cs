using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Attributes;

namespace LoopPerformance;

[MemoryDiagnoser(false)]
public class Benchmarks
{
	[Params(100)]
	public int Count { get; set; }

	private static User[] Items;

	[GlobalSetup]
	public void Setup()
	{
		Items = Enumerable.Range(0, Count)
			.Select(x => new User($"This is item# { x }")).ToArray();
	}

	[Benchmark]
	public void NormalLoop()
	{
		foreach(var item in Items)
		{
			item.GetName();
		}
	}

    [Benchmark]
    public void SpanLoop()
    {
		var span = Items.AsSpan();

        for (var i = 0; i < span.Length; i++)
        {
			var item = Items[i];

            item.GetName();
        }
    }

    [Benchmark]
    public void FastLoop()
    {
		ref var searchSpace = ref MemoryMarshal.GetArrayDataReference(Items);

        for (var i = 0; i < Items.Length; i++)
        {
			var item = Unsafe.Add(ref searchSpace, i);

            item.GetName();
        }
    }

    [Benchmark]
    public void FasterLoop()
    {
        ref var start = ref MemoryMarshal.GetArrayDataReference(Items);
        ref var end = ref Unsafe.Add(ref start, Items.Length);

        while (Unsafe.IsAddressLessThan(ref start, ref end))
        {
            start.GetName();

            start = ref Unsafe.Add(ref start, 1);
        }
    }
}

