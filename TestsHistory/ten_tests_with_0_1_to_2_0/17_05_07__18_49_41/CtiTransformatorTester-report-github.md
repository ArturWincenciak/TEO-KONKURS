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
 |  Test_v_0_1_transformator | 37.511 ms | 0.1819 ms | 0.1701 ms |   1.00 | 4891.6667 |  16.31 MB |
 |  Test_v_0_2_transformator | 11.216 ms | 0.0453 ms | 0.0423 ms |   0.30 | 2409.3750 |   7.69 MB |
 |  Test_v_0_3_transformator |  9.722 ms | 0.0203 ms | 0.0180 ms |   0.26 | 1835.4167 |   5.91 MB |
 |  Test_v_0_4_transformator |  9.741 ms | 0.0395 ms | 0.0370 ms |   0.26 | 1818.7500 |   5.91 MB |
 |  Test_v_0_5_transformator |  5.484 ms | 0.0136 ms | 0.0127 ms |   0.15 | 1560.4167 |   4.88 MB |
 |  Test_v_0_6_transformator |  5.148 ms | 0.0170 ms | 0.0159 ms |   0.14 | 2018.7500 |   6.29 MB |
 |  Test_v_0_7_transformator |  3.793 ms | 0.0095 ms | 0.0080 ms |   0.10 | 1991.6667 |    6.1 MB |
 |  Test_v_0_8_transformator |  3.302 ms | 0.0105 ms | 0.0093 ms |   0.09 | 1401.8229 |   4.33 MB |
 |  Test_v_0_9_transformator |  2.463 ms | 0.0064 ms | 0.0057 ms |   0.07 | 1402.8646 |   4.33 MB |
 | Test_v_0_10_transformator |  2.925 ms | 0.0079 ms | 0.0070 ms |   0.08 | 1401.8229 |   4.33 MB |
 | Test_v_0_11_transformator |  2.442 ms | 0.0162 ms | 0.0143 ms |   0.07 | 1399.7396 |   4.33 MB |
 | Test_v_0_12_transformator |  2.553 ms | 0.0135 ms | 0.0126 ms |   0.07 | 1518.7500 |   4.69 MB |
 |  Test_v_1_1_transformator |  2.402 ms | 0.0094 ms | 0.0088 ms |   0.06 | 1401.8229 |   4.33 MB |
 |  Test_v_1_2_transformator |  2.429 ms | 0.0127 ms | 0.0119 ms |   0.06 | 1408.0729 |   4.33 MB |
 |  Test_v_2_0_transformator |  2.969 ms | 0.0085 ms | 0.0080 ms |   0.08 | 1402.8646 |   4.33 MB |
