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
 |  Test_v_0_1_transformator | 37.816 ms | 0.3714 ms | 0.3475 ms |   1.00 | 4908.3333 |  16.31 MB |
 |  Test_v_0_2_transformator | 11.216 ms | 0.1065 ms | 0.0889 ms |   0.30 | 2421.8750 |   7.69 MB |
 |  Test_v_0_3_transformator |  9.795 ms | 0.0570 ms | 0.0534 ms |   0.26 | 1831.2500 |   5.91 MB |
 |  Test_v_0_4_transformator |  9.762 ms | 0.0583 ms | 0.0546 ms |   0.26 | 1793.7500 |   5.91 MB |
 |  Test_v_0_5_transformator |  5.497 ms | 0.0193 ms | 0.0180 ms |   0.15 | 1543.7500 |   4.88 MB |
 |  Test_v_0_6_transformator |  5.139 ms | 0.0167 ms | 0.0156 ms |   0.14 | 2025.0000 |   6.29 MB |
 |  Test_v_0_7_transformator |  3.780 ms | 0.0162 ms | 0.0152 ms |   0.10 | 1997.9167 |    6.1 MB |
 |  Test_v_0_8_transformator |  3.297 ms | 0.0086 ms | 0.0081 ms |   0.09 | 1400.7813 |   4.33 MB |
 |  Test_v_0_9_transformator |  2.465 ms | 0.0107 ms | 0.0100 ms |   0.07 | 1404.9479 |   4.33 MB |
 | Test_v_0_10_transformator |  2.444 ms | 0.0098 ms | 0.0091 ms |   0.06 | 1398.6979 |   4.33 MB |
 | Test_v_0_11_transformator |  2.450 ms | 0.0092 ms | 0.0086 ms |   0.06 | 1400.7813 |   4.33 MB |
 | Test_v_0_12_transformator |  2.547 ms | 0.0105 ms | 0.0099 ms |   0.07 | 1523.9583 |   4.69 MB |
 |  Test_v_1_1_transformator |  2.403 ms | 0.0163 ms | 0.0144 ms |   0.06 | 1407.0313 |   4.33 MB |
 |  Test_v_1_2_transformator |  2.436 ms | 0.0102 ms | 0.0095 ms |   0.06 | 1401.8229 |   4.33 MB |
 |  Test_v_2_0_transformator |  2.963 ms | 0.0107 ms | 0.0100 ms |   0.08 | 1398.6979 |   4.33 MB |
