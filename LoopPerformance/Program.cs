using BenchmarkDotNet.Attributes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BenchmarkDotNet.Running;
using LoopPerformance;

BenchmarkRunner.Run<Benchmarks>();


return;

var Items = Enumerable.Range(0, 10)
            .Select(x => new User($"This is item# {x}")).ToArray();

FasterLoop();

void NormalLoop()
{
    foreach (var item in Items)
    {
       Console.WriteLine(item.GetName());
    }
}

void SpanLoop()
{
    var span = Items.AsSpan();

    for (var i = 0; i < span.Length; i++)
    {
        var item = Items[i];

        Console.WriteLine(item.GetName());
    }
}

void FastLoop()
{
    ref var searchSpace = ref MemoryMarshal.GetArrayDataReference(Items);

    for (var i = 0; i < Items.Length; i++)
    {
        var item = Unsafe.Add(ref searchSpace, i);

        Console.WriteLine(item.GetName());
    }
}

void FasterLoop()
{
    ref var start = ref MemoryMarshal.GetArrayDataReference(Items);
    ref var end = ref Unsafe.Add(ref start, Items.Length);

    while (Unsafe.IsAddressLessThan(ref start, ref end))
    {
        Console.WriteLine(start.GetName());

        start = ref Unsafe.Add(ref start, 1);
    }
}