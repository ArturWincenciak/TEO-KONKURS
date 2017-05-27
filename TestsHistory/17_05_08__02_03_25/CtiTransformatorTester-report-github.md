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
 |  Test_v_0_1_transformator | 37.426 ms | 0.1022 ms | 0.0906 ms |   1.00 | 4791.6667 |  16.31 MB |
 |  Test_v_0_2_transformator | 11.357 ms | 0.0524 ms | 0.0490 ms |   0.30 | 2417.7083 |   7.69 MB |
 |  Test_v_0_3_transformator |  9.774 ms | 0.0417 ms | 0.0391 ms |   0.26 | 1827.0833 |   5.91 MB |
 |  Test_v_0_4_transformator |  9.770 ms | 0.0666 ms | 0.0623 ms |   0.26 | 1827.0833 |   5.91 MB |
 |  Test_v_0_5_transformator |  5.530 ms | 0.0272 ms | 0.0254 ms |   0.15 | 1558.3333 |   4.88 MB |
 |  Test_v_0_6_transformator |  5.145 ms | 0.0152 ms | 0.0143 ms |   0.14 | 2025.0000 |   6.29 MB |
 |  Test_v_0_7_transformator |  3.783 ms | 0.0110 ms | 0.0103 ms |   0.10 | 1990.6250 |    6.1 MB |
 |  Test_v_0_8_transformator |  3.297 ms | 0.0152 ms | 0.0142 ms |   0.09 | 1399.7396 |   4.33 MB |
 |  Test_v_0_9_transformator |  2.453 ms | 0.0092 ms | 0.0081 ms |   0.07 | 1400.7813 |   4.33 MB |
 | Test_v_0_10_transformator |  2.429 ms | 0.0149 ms | 0.0139 ms |   0.06 | 1407.0313 |   4.33 MB |
 | Test_v_0_11_transformator |  2.442 ms | 0.0119 ms | 0.0112 ms |   0.07 | 1400.7813 |   4.33 MB |
 | Test_v_0_12_transformator |  2.568 ms | 0.0153 ms | 0.0143 ms |   0.07 | 1526.0417 |   4.69 MB |
 |  Test_v_1_1_transformator |  2.412 ms | 0.0081 ms | 0.0076 ms |   0.06 | 1408.0729 |   4.33 MB |
 |  Test_v_1_2_transformator |  2.414 ms | 0.0085 ms | 0.0079 ms |   0.06 | 1399.7396 |   4.33 MB |
 |  Test_v_2_0_transformator |  2.956 ms | 0.0125 ms | 0.0117 ms |   0.08 | 1400.7813 |   4.33 MB |
 |  Test_v_3_0_transformator |  3.404 ms | 0.0050 ms | 0.0047 ms |   0.09 | 1108.8542 |   3.46 MB |
 |  Test_v_4_0_transformator |  4.963 ms | 0.0138 ms | 0.0129 ms |   0.13 |  934.8958 |   3.04 MB |
 |  Test_v_4_1_transformator |  5.237 ms | 0.0213 ms | 0.0200 ms |   0.14 |  934.8958 |   3.04 MB |
 |  Test_v_4_2_transformator |  3.937 ms | 0.0193 ms | 0.0181 ms |   0.11 |  708.3333 |   2.35 MB |
