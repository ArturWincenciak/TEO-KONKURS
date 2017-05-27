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
 |  Test_v_0_9_transformator | 2.493 ms | 0.0453 ms | 0.0354 ms |   1.02 | 1410.1563 |   4.33 MB |
 | Test_v_0_10_transformator | 2.439 ms | 0.0091 ms | 0.0085 ms |   1.00 | 1405.9896 |   4.33 MB |
 | Test_v_0_11_transformator | 2.449 ms | 0.0123 ms | 0.0103 ms |   1.00 | 1401.8229 |   4.33 MB |
 | Test_v_0_12_transformator | 2.558 ms | 0.0126 ms | 0.0112 ms |   1.04 | 1520.8333 |   4.69 MB |
 |  Test_v_1_1_transformator | 2.407 ms | 0.0098 ms | 0.0092 ms |   0.98 | 1398.6979 |   4.33 MB |
 |  Test_v_1_2_transformator | 2.440 ms | 0.0117 ms | 0.0104 ms |   1.00 | 1405.9896 |   4.33 MB |
 |  Test_v_2_0_transformator | 2.970 ms | 0.0096 ms | 0.0089 ms |   1.21 | 1399.7396 |   4.33 MB |
