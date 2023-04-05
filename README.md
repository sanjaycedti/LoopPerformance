# LoopPerformance
Comparing various loops performance

* Benchmark Summary *

BenchmarkDotNet=v0.13.5, OS=macOS Ventura 13.1 (22C65) [Darwin 22.2.0]
Apple M1 Pro, 1 CPU, 8 logical and 8 physical cores
.NET SDK=7.0.202
  [Host]     : .NET 7.0.4 (7.0.423.11508), Arm64 RyuJIT AdvSIMD [AttachedDebugger]
  DefaultJob : .NET 7.0.4 (7.0.423.11508), Arm64 RyuJIT AdvSIMD


|     Method | Count |     Mean |    Error |   StdDev | Allocated |
|----------- |------ |---------:|---------:|---------:|----------:|
| NormalLoop |   100 | 42.17 ns | 0.145 ns | 0.121 ns |         - |
|   SpanLoop |   100 | 52.65 ns | 1.044 ns | 1.394 ns |         - |
|   FastLoop |   100 | 52.44 ns | 0.759 ns | 0.673 ns |         - |
| FasterLoop |   100 | 49.69 ns | 0.579 ns | 0.484 ns |         - |