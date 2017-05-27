``` ini

BenchmarkDotNet=v0.10.5, OS=Windows 10.0.15063
Processor=Intel Core i7-4710MQ CPU 2.50GHz (Haswell), ProcessorCount=8
Frequency=2435773 Hz, Resolution=410.5473 ns, Timer=TSC
  [Host]            : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2046.0
  LegacyJit-Clr-X86 : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2046.0

Job=LegacyJit-Clr-X86  Jit=LegacyJit  Platform=X86  
Runtime=Clr  

```
 |                    Method |     Mean |     Error |    StdDev |   Median | Scaled | ScaledSD |     Gen 0 | Allocated |
 |-------------------------- |---------:|----------:|----------:|---------:|-------:|---------:|----------:|----------:|
 |  Test_v_0_9_transformator | 2.463 ms | 0.0116 ms | 0.0108 ms | 2.462 ms |   1.05 |     0.00 | 1405.9896 |   4.33 MB |
 | Test_v_0_10_transformator | 2.398 ms | 0.0492 ms | 0.0795 ms | 2.355 ms |   1.02 |     0.03 | 1400.7813 |   4.33 MB |
 | Test_v_0_11_transformator | 2.354 ms | 0.0052 ms | 0.0044 ms | 2.353 ms |   1.00 |     0.00 | 1402.8646 |   4.33 MB |
 | Test_v_0_12_transformator | 2.463 ms | 0.0055 ms | 0.0049 ms | 2.461 ms |   1.05 |     0.00 | 1523.9583 |   4.69 MB |
 |  Test_v_1_1_transformator | 2.322 ms | 0.0073 ms | 0.0069 ms | 2.325 ms |   0.99 |     0.00 | 1407.0313 |   4.33 MB |
 |  Test_v_1_2_transformator | 2.328 ms | 0.0063 ms | 0.0056 ms | 2.326 ms |   0.99 |     0.00 | 1399.7396 |   4.33 MB |
 |  Test_v_2_0_transformator | 2.857 ms | 0.0137 ms | 0.0128 ms | 2.853 ms |   1.21 |     0.01 | 1402.8646 |   4.33 MB |
