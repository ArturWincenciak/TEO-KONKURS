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
 |  Test_v_0_1_transformator | 37.588 ms | 0.1082 ms | 0.1012 ms |   1.00 | 4858.3333 |  16.31 MB |
 |  Test_v_0_2_transformator | 11.213 ms | 0.0342 ms | 0.0319 ms |   0.30 | 2417.7083 |   7.69 MB |
 |  Test_v_0_3_transformator |  9.729 ms | 0.0451 ms | 0.0422 ms |   0.26 | 1822.9167 |   5.91 MB |
 |  Test_v_0_4_transformator |  9.738 ms | 0.0301 ms | 0.0282 ms |   0.26 | 1839.5833 |   5.91 MB |
 |  Test_v_0_5_transformator |  5.488 ms | 0.0131 ms | 0.0116 ms |   0.15 | 1539.5833 |   4.88 MB |
 |  Test_v_0_6_transformator |  5.137 ms | 0.0158 ms | 0.0140 ms |   0.14 | 2027.0833 |   6.29 MB |
 |  Test_v_0_7_transformator |  3.793 ms | 0.0276 ms | 0.0231 ms |   0.10 | 1990.6250 |    6.1 MB |
 |  Test_v_0_8_transformator |  3.302 ms | 0.0193 ms | 0.0161 ms |   0.09 | 1402.8646 |   4.33 MB |
 |  Test_v_0_9_transformator |  2.482 ms | 0.0225 ms | 0.0188 ms |   0.07 | 1408.0729 |   4.33 MB |
 | Test_v_0_10_transformator |  2.455 ms | 0.0063 ms | 0.0059 ms |   0.07 | 1399.7396 |   4.33 MB |
 | Test_v_0_11_transformator |  2.435 ms | 0.0108 ms | 0.0101 ms |   0.06 | 1399.7396 |   4.33 MB |
 | Test_v_0_12_transformator |  2.556 ms | 0.0129 ms | 0.0121 ms |   0.07 | 1521.8750 |   4.69 MB |
 |  Test_v_1_1_transformator |  2.409 ms | 0.0110 ms | 0.0098 ms |   0.06 | 1407.0313 |   4.33 MB |
 |  Test_v_1_2_transformator |  2.427 ms | 0.0118 ms | 0.0111 ms |   0.06 | 1399.7396 |   4.33 MB |
 |  Test_v_2_0_transformator |  2.979 ms | 0.0096 ms | 0.0085 ms |   0.08 | 1407.0313 |   4.33 MB |
