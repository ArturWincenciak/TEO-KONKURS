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
 |  Test_v_0_9_transformator | 2.460 ms | 0.0092 ms | 0.0081 ms |   1.01 | 1404.9479 |   4.33 MB |
 | Test_v_0_10_transformator | 2.453 ms | 0.0095 ms | 0.0085 ms |   1.00 | 1401.8229 |   4.33 MB |
 | Test_v_0_11_transformator | 2.446 ms | 0.0110 ms | 0.0103 ms |   1.00 | 1408.0729 |   4.33 MB |
 | Test_v_0_12_transformator | 2.556 ms | 0.0112 ms | 0.0099 ms |   1.05 | 1518.7500 |   4.69 MB |
 |  Test_v_1_1_transformator | 2.403 ms | 0.0091 ms | 0.0085 ms |   0.98 | 1407.0313 |   4.33 MB |
 |  Test_v_1_2_transformator | 2.428 ms | 0.0072 ms | 0.0064 ms |   0.99 | 1404.9479 |   4.33 MB |
 |  Test_v_2_0_transformator | 2.966 ms | 0.0096 ms | 0.0090 ms |   1.21 | 1398.6979 |   4.33 MB |
