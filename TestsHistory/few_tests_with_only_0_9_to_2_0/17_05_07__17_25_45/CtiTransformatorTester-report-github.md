``` ini

BenchmarkDotNet=v0.10.5, OS=Windows 10.0.15063
Processor=Intel Core i7-4710MQ CPU 2.50GHz (Haswell), ProcessorCount=8
Frequency=2435773 Hz, Resolution=410.5473 ns, Timer=TSC
  [Host]            : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2046.0
  LegacyJit-Clr-X86 : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2046.0

Job=LegacyJit-Clr-X86  Jit=LegacyJit  Platform=X86  
Runtime=Clr  

```
 |                    Method |     Mean |     Error |    StdDev | Scaled | ScaledSD |     Gen 0 | Allocated |
 |-------------------------- |---------:|----------:|----------:|-------:|---------:|----------:|----------:|
 |  Test_v_0_9_transformator | 2.487 ms | 0.0472 ms | 0.0505 ms |   1.02 |     0.02 | 1408.0729 |   4.33 MB |
 | Test_v_0_10_transformator | 2.440 ms | 0.0064 ms | 0.0056 ms |   1.00 |     0.00 | 1407.0313 |   4.33 MB |
 | Test_v_0_11_transformator | 2.444 ms | 0.0085 ms | 0.0079 ms |   1.00 |     0.00 | 1408.0729 |   4.33 MB |
 | Test_v_0_12_transformator | 2.555 ms | 0.0123 ms | 0.0115 ms |   1.05 |     0.01 | 1521.8750 |   4.69 MB |
 |  Test_v_1_1_transformator | 2.409 ms | 0.0140 ms | 0.0131 ms |   0.99 |     0.01 | 1401.8229 |   4.33 MB |
 |  Test_v_1_2_transformator | 2.428 ms | 0.0060 ms | 0.0056 ms |   0.99 |     0.00 | 1404.9479 |   4.33 MB |
 |  Test_v_2_0_transformator | 2.967 ms | 0.0093 ms | 0.0078 ms |   1.21 |     0.00 | 1407.0313 |   4.33 MB |
