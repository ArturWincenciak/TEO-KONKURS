``` ini

BenchmarkDotNet=v0.10.5, OS=Windows 10.0.15063
Processor=Intel Core i7-4710MQ CPU 2.50GHz (Haswell), ProcessorCount=8
Frequency=2435773 Hz, Resolution=410.5473 ns, Timer=TSC
  [Host]            : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2046.0
  LegacyJit-Clr-X86 : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2046.0

Job=LegacyJit-Clr-X86  Jit=LegacyJit  Platform=X86  
Runtime=Clr  

```
 |                    Method |     Mean |     Error |    StdDev | Scaled |     Gen 0 | Allocated |
 |-------------------------- |---------:|----------:|----------:|-------:|----------:|----------:|
 |  Test_v_0_9_transformator | 2.398 ms | 0.0228 ms | 0.0202 ms |   1.02 | 1405.9896 |   4.33 MB |
 | Test_v_0_10_transformator | 2.366 ms | 0.0121 ms | 0.0107 ms |   1.00 | 1407.0313 |   4.33 MB |
 | Test_v_0_11_transformator | 2.356 ms | 0.0063 ms | 0.0056 ms |   1.00 | 1403.9063 |   4.33 MB |
 | Test_v_0_12_transformator | 2.481 ms | 0.0105 ms | 0.0093 ms |   1.05 | 1522.9167 |   4.69 MB |
 |  Test_v_1_1_transformator | 2.321 ms | 0.0080 ms | 0.0071 ms |   0.99 | 1403.9063 |   4.33 MB |
 |  Test_v_1_2_transformator | 2.332 ms | 0.0045 ms | 0.0035 ms |   0.99 | 1400.7813 |   4.33 MB |
 |  Test_v_2_0_transformator | 2.860 ms | 0.0058 ms | 0.0054 ms |   1.21 | 1397.6563 |   4.33 MB |
