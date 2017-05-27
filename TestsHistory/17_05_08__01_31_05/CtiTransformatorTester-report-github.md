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
 |  Test_v_0_1_transformator | 37.527 ms | 0.0802 ms | 0.0751 ms |   1.00 | 4858.3333 |  16.31 MB |
 |  Test_v_0_2_transformator | 11.339 ms | 0.0732 ms | 0.0685 ms |   0.30 | 2421.8750 |   7.69 MB |
 |  Test_v_0_3_transformator |  9.805 ms | 0.0270 ms | 0.0239 ms |   0.26 | 1814.5833 |   5.91 MB |
 |  Test_v_0_4_transformator |  9.767 ms | 0.0267 ms | 0.0237 ms |   0.26 | 1835.4167 |   5.91 MB |
 |  Test_v_0_5_transformator |  5.531 ms | 0.0211 ms | 0.0197 ms |   0.15 | 1547.9167 |   4.88 MB |
 |  Test_v_0_6_transformator |  5.161 ms | 0.0174 ms | 0.0163 ms |   0.14 | 2027.0833 |   6.29 MB |
 |  Test_v_0_7_transformator |  3.779 ms | 0.0086 ms | 0.0081 ms |   0.10 | 1993.7500 |    6.1 MB |
 |  Test_v_0_8_transformator |  3.310 ms | 0.0218 ms | 0.0204 ms |   0.09 | 1407.0313 |   4.33 MB |
 |  Test_v_0_9_transformator |  2.458 ms | 0.0096 ms | 0.0090 ms |   0.07 | 1402.8646 |   4.33 MB |
 | Test_v_0_10_transformator |  2.425 ms | 0.0107 ms | 0.0100 ms |   0.06 | 1401.8229 |   4.33 MB |
 | Test_v_0_11_transformator |  2.452 ms | 0.0090 ms | 0.0079 ms |   0.07 | 1401.8229 |   4.33 MB |
 | Test_v_0_12_transformator |  2.564 ms | 0.0093 ms | 0.0082 ms |   0.07 | 1525.0000 |   4.69 MB |
 |  Test_v_1_1_transformator |  2.403 ms | 0.0102 ms | 0.0096 ms |   0.06 | 1398.6979 |   4.33 MB |
 |  Test_v_1_2_transformator |  2.421 ms | 0.0086 ms | 0.0081 ms |   0.06 | 1398.6979 |   4.33 MB |
 |  Test_v_2_0_transformator |  2.957 ms | 0.0078 ms | 0.0061 ms |   0.08 | 1401.8229 |   4.33 MB |
 |  Test_v_3_0_transformator |  3.404 ms | 0.0114 ms | 0.0107 ms |   0.09 | 1111.9792 |   3.46 MB |
 |  Test_v_4_0_transformator |  4.975 ms | 0.0177 ms | 0.0166 ms |   0.13 |  932.8125 |   3.04 MB |
 |  Test_v_4_1_transformator |  5.220 ms | 0.0160 ms | 0.0150 ms |   0.14 |  928.6458 |   3.04 MB |
 |  Test_v_4_2_transformator |  3.912 ms | 0.0095 ms | 0.0088 ms |   0.10 |  746.8750 |   2.35 MB |
