``` ini

BenchmarkDotNet=v0.10.5, OS=Windows 10.0.15063
Processor=Intel Core i7-4710MQ CPU 2.50GHz (Haswell), ProcessorCount=8
Frequency=2435773 Hz, Resolution=410.5473 ns, Timer=TSC
  [Host]            : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2046.0
  LegacyJit-Clr-X86 : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2046.0

Job=LegacyJit-Clr-X86  Jit=LegacyJit  Platform=X86  
Runtime=Clr  

```
 |                    Method |      Mean |     Error |    StdDev |    Median | Scaled |     Gen 0 | Allocated |
 |-------------------------- |----------:|----------:|----------:|----------:|-------:|----------:|----------:|
 |  Test_v_0_1_transformator | 39.683 ms | 0.7930 ms | 0.9132 ms | 39.869 ms |   1.00 | 4980.2632 |  16.31 MB |
 |  Test_v_0_2_transformator | 12.068 ms | 0.0909 ms | 0.0850 ms | 12.074 ms |   0.30 | 2518.7953 |   7.69 MB |
 |  Test_v_0_3_transformator | 10.118 ms | 0.1988 ms | 0.3153 ms |  9.971 ms |   0.26 | 1831.2500 |   5.91 MB |
 |  Test_v_0_4_transformator | 10.507 ms | 0.1657 ms | 0.1384 ms | 10.427 ms |   0.26 | 1831.2500 |   5.91 MB |
 |  Test_v_0_5_transformator |  6.096 ms | 0.1688 ms | 0.1944 ms |  6.034 ms |   0.15 | 1543.7500 |   4.88 MB |
 |  Test_v_0_6_transformator |  5.204 ms | 0.0114 ms | 0.0095 ms |  5.202 ms |   0.13 | 2029.1667 |   6.29 MB |
 |  Test_v_0_7_transformator |  3.967 ms | 0.0785 ms | 0.1586 ms |  3.888 ms |   0.10 | 1973.4375 |    6.1 MB |
 |  Test_v_0_8_transformator |  3.618 ms | 0.0315 ms | 0.0246 ms |  3.612 ms |   0.09 | 1405.9896 |   4.33 MB |
 |  Test_v_0_9_transformator |  2.686 ms | 0.0250 ms | 0.0234 ms |  2.694 ms |   0.07 | 1408.0729 |   4.33 MB |
 | Test_v_0_10_transformator |  2.677 ms | 0.0369 ms | 0.0346 ms |  2.668 ms |   0.07 | 1408.0729 |   4.33 MB |
 | Test_v_0_11_transformator |  2.701 ms | 0.0188 ms | 0.0176 ms |  2.703 ms |   0.07 | 1418.2813 |   4.33 MB |
 | Test_v_0_12_transformator |  2.622 ms | 0.0508 ms | 0.0679 ms |  2.604 ms |   0.07 | 1521.8750 |   4.69 MB |
 |  Test_v_1_1_transformator |  2.402 ms | 0.0118 ms | 0.0104 ms |  2.401 ms |   0.06 | 1401.8229 |   4.33 MB |
 |  Test_v_1_2_transformator |  2.418 ms | 0.0141 ms | 0.0132 ms |  2.424 ms |   0.06 | 1401.8229 |   4.33 MB |
 |  Test_v_2_0_transformator |  2.961 ms | 0.0111 ms | 0.0104 ms |  2.962 ms |   0.07 | 1399.7396 |   4.33 MB |
 |  Test_v_3_0_transformator |  3.411 ms | 0.0080 ms | 0.0075 ms |  3.409 ms |   0.09 | 1108.8542 |   3.46 MB |
 |  Test_v_4_0_transformator |  4.968 ms | 0.0201 ms | 0.0188 ms |  4.966 ms |   0.13 |  934.8958 |   3.04 MB |
 |  Test_v_4_1_transformator |  5.222 ms | 0.0201 ms | 0.0188 ms |  5.223 ms |   0.13 |  936.9792 |   3.04 MB |
 |  Test_v_4_2_transformator |  3.912 ms | 0.0117 ms | 0.0104 ms |  3.910 ms |   0.10 |  746.8750 |   2.35 MB |
