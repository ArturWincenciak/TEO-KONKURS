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
 |  Test_v_0_9_transformator | 2.468 ms | 0.0121 ms | 0.0114 ms |   1.01 | 1401.8229 |   4.33 MB |
 | Test_v_0_10_transformator | 2.445 ms | 0.0075 ms | 0.0070 ms |   1.00 | 1407.0313 |   4.33 MB |
 | Test_v_0_11_transformator | 2.445 ms | 0.0091 ms | 0.0085 ms |   1.00 | 1407.0313 |   4.33 MB |
 | Test_v_0_12_transformator | 2.548 ms | 0.0059 ms | 0.0056 ms |   1.04 | 1520.8333 |   4.69 MB |
 |  Test_v_1_1_transformator | 2.396 ms | 0.0055 ms | 0.0052 ms |   0.98 | 1405.9896 |   4.33 MB |
 |  Test_v_1_2_transformator | 2.437 ms | 0.0092 ms | 0.0086 ms |   1.00 | 1400.7813 |   4.33 MB |
 |  Test_v_2_0_transformator | 2.962 ms | 0.0107 ms | 0.0100 ms |   1.21 | 1398.6979 |   4.33 MB |
