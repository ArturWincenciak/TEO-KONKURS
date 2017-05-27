``` ini

BenchmarkDotNet=v0.10.5, OS=Windows 10.0.15063
Processor=Intel Core i7-4710MQ CPU 2.50GHz (Haswell), ProcessorCount=8
Frequency=2435773 Hz, Resolution=410.5473 ns, Timer=TSC
  [Host]            : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2046.0
  LegacyJit-Clr-X86 : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2046.0

Job=LegacyJit-Clr-X86  Jit=LegacyJit  Platform=X86  
Runtime=Clr  

```
 |                    Method |      Mean |     Error |    StdDev | Scaled |     Gen 0 | Allocated |
 |-------------------------- |----------:|----------:|----------:|-------:|----------:|----------:|
 |  Test_v_0_1_transformator | 37.384 ms | 0.1092 ms | 0.1022 ms |   1.00 | 4891.6667 |  16.31 MB |
 |  Test_v_0_2_transformator | 11.199 ms | 0.0304 ms | 0.0284 ms |   0.30 | 2421.8750 |   7.69 MB |
 |  Test_v_0_3_transformator |  9.685 ms | 0.0254 ms | 0.0238 ms |   0.26 | 1843.7500 |   5.91 MB |
 |  Test_v_0_4_transformator |  9.764 ms | 0.0529 ms | 0.0494 ms |   0.26 | 1839.5833 |   5.91 MB |
 |  Test_v_0_5_transformator |  5.467 ms | 0.0124 ms | 0.0110 ms |   0.15 | 1547.9167 |   4.88 MB |
 |  Test_v_0_6_transformator |  5.165 ms | 0.0206 ms | 0.0193 ms |   0.14 | 2020.8333 |   6.29 MB |
 |  Test_v_0_7_transformator |  3.803 ms | 0.0098 ms | 0.0092 ms |   0.10 | 1996.8750 |    6.1 MB |
 |  Test_v_0_8_transformator |  3.296 ms | 0.0111 ms | 0.0104 ms |   0.09 | 1401.8229 |   4.33 MB |
 |  Test_v_0_9_transformator |  2.458 ms | 0.0107 ms | 0.0100 ms |   0.07 | 1408.0729 |   4.33 MB |
 | Test_v_0_10_transformator |  2.460 ms | 0.0115 ms | 0.0108 ms |   0.07 | 1405.9896 |   4.33 MB |
 | Test_v_0_11_transformator |  2.438 ms | 0.0064 ms | 0.0054 ms |   0.07 | 1401.8229 |   4.33 MB |
 | Test_v_0_12_transformator |  2.587 ms | 0.0475 ms | 0.0371 ms |   0.07 | 1521.8750 |   4.69 MB |
 |  Test_v_1_1_transformator |  2.482 ms | 0.0496 ms | 0.0842 ms |   0.07 | 1408.0729 |   4.33 MB |
 |  Test_v_1_2_transformator |  2.425 ms | 0.0092 ms | 0.0086 ms |   0.06 | 1401.8229 |   4.33 MB |
 |  Test_v_2_0_transformator |  2.964 ms | 0.0072 ms | 0.0061 ms |   0.08 | 1400.7813 |   4.33 MB |
