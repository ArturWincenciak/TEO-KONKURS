``` ini

BenchmarkDotNet=v0.10.6, OS=Windows 10 Redstone 2 (10.0.15063)
Processor=Intel Core i7-4710MQ CPU 2.50GHz (Haswell), ProcessorCount=8
Frequency=2435781 Hz, Resolution=410.5459 ns, Timer=TSC
  [Host]            : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2098.0
  LegacyJit-Clr-X86 : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2098.0

Job=LegacyJit-Clr-X86  Jit=LegacyJit  Platform=X86  
Runtime=Clr  

```
 |                    Method |      Mean |     Error |    StdDev |    Median | Scaled |     Gen 0 | Allocated |
 |-------------------------- |----------:|----------:|----------:|----------:|-------:|----------:|----------:|
 |  Test_v_0_1_transformator | 37.682 ms | 0.3825 ms | 0.3390 ms | 37.614 ms |   1.00 | 5375.0000 |  16.31 MB |
 |  Test_v_0_2_transformator | 11.395 ms | 0.1247 ms | 0.1041 ms | 11.381 ms |   0.30 | 2546.8750 |   7.69 MB |
 |  Test_v_0_3_transformator |  9.826 ms | 0.0353 ms | 0.0330 ms |  9.821 ms |   0.26 | 1968.7500 |   5.91 MB |
 |  Test_v_0_4_transformator |  9.814 ms | 0.0511 ms | 0.0478 ms |  9.820 ms |   0.26 | 1968.7500 |   5.91 MB |
 |  Test_v_0_5_transformator |  5.598 ms | 0.0629 ms | 0.0588 ms |  5.597 ms |   0.15 | 1625.0000 |   4.88 MB |
 |  Test_v_0_6_transformator |  5.134 ms | 0.0581 ms | 0.0544 ms |  5.115 ms |   0.14 | 2093.7500 |   6.29 MB |
 |  Test_v_0_7_transformator |  3.868 ms | 0.0713 ms | 0.1286 ms |  3.812 ms |   0.10 | 2031.2500 |    6.1 MB |
 |  Test_v_0_8_transformator |  3.311 ms | 0.0138 ms | 0.0130 ms |  3.311 ms |   0.09 | 1441.4063 |   4.33 MB |
 |  Test_v_0_9_transformator |  2.441 ms | 0.0112 ms | 0.0105 ms |  2.440 ms |   0.06 | 1441.4063 |   4.33 MB |
 | Test_v_0_10_transformator |  2.570 ms | 0.0133 ms | 0.0118 ms |  2.570 ms |   0.07 | 1441.4063 |   4.33 MB |
 | Test_v_0_11_transformator |  2.579 ms | 0.0141 ms | 0.0110 ms |  2.579 ms |   0.07 | 1441.4063 |   4.33 MB |
 | Test_v_0_12_transformator |  2.625 ms | 0.0201 ms | 0.0168 ms |  2.623 ms |   0.07 | 1562.5000 |   4.69 MB |
 |  Test_v_1_1_transformator |  2.437 ms | 0.0081 ms | 0.0067 ms |  2.437 ms |   0.06 | 1441.4063 |   4.33 MB |
 |  Test_v_1_2_transformator |  2.638 ms | 0.0243 ms | 0.0216 ms |  2.634 ms |   0.07 | 1441.4063 |   4.33 MB |
 |  Test_v_2_0_transformator |  3.125 ms | 0.0618 ms | 0.0803 ms |  3.079 ms |   0.08 | 1441.4063 |   4.33 MB |
 |  Test_v_3_0_transformator |  3.492 ms | 0.0243 ms | 0.0216 ms |  3.490 ms |   0.09 | 1148.4375 |   3.46 MB |
 |  Test_v_4_0_transformator |  5.133 ms | 0.0281 ms | 0.0249 ms |  5.127 ms |   0.14 | 1007.8125 |   3.04 MB |
 |  Test_v_4_1_transformator |  5.455 ms | 0.0107 ms | 0.0095 ms |  5.460 ms |   0.14 | 1007.8125 |   3.04 MB |
 |  Test_v_4_2_transformator |  4.090 ms | 0.0138 ms | 0.0122 ms |  4.087 ms |   0.11 |  781.2500 |   2.35 MB |
