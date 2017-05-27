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
 |  Test_v_0_1_transformator | 37.549 ms | 0.1229 ms | 0.1149 ms |   1.00 | 4891.6667 |  16.31 MB |
 |  Test_v_0_2_transformator | 11.193 ms | 0.0238 ms | 0.0211 ms |   0.30 | 2421.8750 |   7.69 MB |
 |  Test_v_0_3_transformator |  9.793 ms | 0.0421 ms | 0.0394 ms |   0.26 | 1843.7500 |   5.91 MB |
 |  Test_v_0_4_transformator |  9.794 ms | 0.0527 ms | 0.0493 ms |   0.26 | 1835.4167 |   5.91 MB |
 |  Test_v_0_5_transformator |  5.501 ms | 0.0183 ms | 0.0162 ms |   0.15 | 1552.0833 |   4.88 MB |
 |  Test_v_0_6_transformator |  5.150 ms | 0.0217 ms | 0.0203 ms |   0.14 | 2027.0833 |   6.29 MB |
 |  Test_v_0_7_transformator |  3.785 ms | 0.0110 ms | 0.0103 ms |   0.10 | 1990.6250 |    6.1 MB |
 |  Test_v_0_8_transformator |  3.296 ms | 0.0072 ms | 0.0067 ms |   0.09 | 1401.8229 |   4.33 MB |
 |  Test_v_0_9_transformator |  2.468 ms | 0.0084 ms | 0.0079 ms |   0.07 | 1402.8646 |   4.33 MB |
 | Test_v_0_10_transformator |  2.444 ms | 0.0074 ms | 0.0070 ms |   0.07 | 1404.9479 |   4.33 MB |
 | Test_v_0_11_transformator |  2.443 ms | 0.0093 ms | 0.0087 ms |   0.07 | 1401.8229 |   4.33 MB |
 | Test_v_0_12_transformator |  2.545 ms | 0.0105 ms | 0.0099 ms |   0.07 | 1522.9167 |   4.69 MB |
 |  Test_v_1_1_transformator |  2.423 ms | 0.0119 ms | 0.0112 ms |   0.06 | 1402.8646 |   4.33 MB |
 |  Test_v_1_2_transformator |  2.427 ms | 0.0102 ms | 0.0096 ms |   0.06 | 1408.0729 |   4.33 MB |
 |  Test_v_2_0_transformator |  2.984 ms | 0.0152 ms | 0.0142 ms |   0.08 | 1408.0729 |   4.33 MB |
