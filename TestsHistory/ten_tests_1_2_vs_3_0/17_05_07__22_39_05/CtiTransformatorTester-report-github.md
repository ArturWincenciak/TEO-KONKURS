``` ini

BenchmarkDotNet=v0.10.5, OS=Windows 10.0.15063
Processor=Intel Core i7-4710MQ CPU 2.50GHz (Haswell), ProcessorCount=8
Frequency=2435773 Hz, Resolution=410.5473 ns, Timer=TSC
  [Host]            : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2046.0
  LegacyJit-Clr-X86 : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2046.0

Job=LegacyJit-Clr-X86  Jit=LegacyJit  Platform=X86  
Runtime=Clr  

```
 |                   Method |     Mean |     Error |    StdDev | Scaled |     Gen 0 | Allocated |
 |------------------------- |---------:|----------:|----------:|-------:|----------:|----------:|
 | Test_v_1_2_transformator | 2.438 ms | 0.0162 ms | 0.0152 ms |   0.71 | 1408.0729 |   4.33 MB |
 | Test_v_3_0_transformator | 3.440 ms | 0.0527 ms | 0.0467 ms |   1.00 | 1107.8125 |   3.46 MB |
