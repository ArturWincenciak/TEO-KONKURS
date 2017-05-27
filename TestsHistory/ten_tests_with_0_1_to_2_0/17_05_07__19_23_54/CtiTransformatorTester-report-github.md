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
 |  Test_v_0_1_transformator | 37.366 ms | 0.2015 ms | 0.1884 ms |   1.00 | 4808.3333 |  16.31 MB |
 |  Test_v_0_2_transformator | 11.224 ms | 0.0430 ms | 0.0402 ms |   0.30 | 2417.7083 |   7.69 MB |
 |  Test_v_0_3_transformator |  9.674 ms | 0.0270 ms | 0.0252 ms |   0.26 | 1843.7500 |   5.91 MB |
 |  Test_v_0_4_transformator |  9.739 ms | 0.0433 ms | 0.0405 ms |   0.26 | 1831.2500 |   5.91 MB |
 |  Test_v_0_5_transformator |  5.485 ms | 0.0105 ms | 0.0082 ms |   0.15 | 1537.5000 |   4.88 MB |
 |  Test_v_0_6_transformator |  5.117 ms | 0.0178 ms | 0.0149 ms |   0.14 | 2022.9167 |   6.29 MB |
 |  Test_v_0_7_transformator |  3.779 ms | 0.0147 ms | 0.0138 ms |   0.10 | 1992.7083 |    6.1 MB |
 |  Test_v_0_8_transformator |  3.286 ms | 0.0092 ms | 0.0086 ms |   0.09 | 1401.8229 |   4.33 MB |
 |  Test_v_0_9_transformator |  2.463 ms | 0.0101 ms | 0.0084 ms |   0.07 | 1407.0313 |   4.33 MB |
 | Test_v_0_10_transformator |  2.448 ms | 0.0062 ms | 0.0058 ms |   0.07 | 1400.7813 |   4.33 MB |
 | Test_v_0_11_transformator |  2.453 ms | 0.0114 ms | 0.0107 ms |   0.07 | 1401.8229 |   4.33 MB |
 | Test_v_0_12_transformator |  2.543 ms | 0.0077 ms | 0.0072 ms |   0.07 | 1520.8333 |   4.69 MB |
 |  Test_v_1_1_transformator |  2.418 ms | 0.0083 ms | 0.0078 ms |   0.06 | 1398.6979 |   4.33 MB |
 |  Test_v_1_2_transformator |  2.432 ms | 0.0095 ms | 0.0089 ms |   0.07 | 1407.0313 |   4.33 MB |
 |  Test_v_2_0_transformator |  2.974 ms | 0.0118 ms | 0.0111 ms |   0.08 | 1399.7396 |   4.33 MB |
