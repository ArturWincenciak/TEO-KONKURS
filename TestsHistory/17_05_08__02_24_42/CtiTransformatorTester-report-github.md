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
 |  Test_v_0_1_transformator | 37.340 ms | 0.1889 ms | 0.1767 ms |   1.00 | 4808.3333 |  16.31 MB |
 |  Test_v_0_2_transformator | 11.251 ms | 0.0230 ms | 0.0215 ms |   0.30 | 2396.8750 |   7.69 MB |
 |  Test_v_0_3_transformator |  9.764 ms | 0.0441 ms | 0.0412 ms |   0.26 | 1835.4167 |   5.91 MB |
 |  Test_v_0_4_transformator |  9.736 ms | 0.0467 ms | 0.0436 ms |   0.26 | 1843.7500 |   5.91 MB |
 |  Test_v_0_5_transformator |  5.516 ms | 0.0123 ms | 0.0115 ms |   0.15 | 1543.7500 |   4.88 MB |
 |  Test_v_0_6_transformator |  5.184 ms | 0.0278 ms | 0.0260 ms |   0.14 | 2010.4167 |   6.29 MB |
 |  Test_v_0_7_transformator |  3.795 ms | 0.0134 ms | 0.0126 ms |   0.10 | 1990.6250 |    6.1 MB |
 |  Test_v_0_8_transformator |  3.298 ms | 0.0122 ms | 0.0114 ms |   0.09 | 1402.8646 |   4.33 MB |
 |  Test_v_0_9_transformator |  2.458 ms | 0.0078 ms | 0.0073 ms |   0.07 | 1404.9479 |   4.33 MB |
 | Test_v_0_10_transformator |  2.439 ms | 0.0116 ms | 0.0108 ms |   0.07 | 1403.9063 |   4.33 MB |
 | Test_v_0_11_transformator |  2.434 ms | 0.0138 ms | 0.0122 ms |   0.07 | 1399.7396 |   4.33 MB |
 | Test_v_0_12_transformator |  2.564 ms | 0.0132 ms | 0.0124 ms |   0.07 | 1529.1667 |   4.69 MB |
 |  Test_v_1_1_transformator |  2.391 ms | 0.0085 ms | 0.0080 ms |   0.06 | 1401.8229 |   4.33 MB |
 |  Test_v_1_2_transformator |  2.422 ms | 0.0084 ms | 0.0079 ms |   0.06 | 1401.8229 |   4.33 MB |
 |  Test_v_2_0_transformator |  2.947 ms | 0.0086 ms | 0.0080 ms |   0.08 | 1397.6563 |   4.33 MB |
 |  Test_v_3_0_transformator |  3.412 ms | 0.0105 ms | 0.0098 ms |   0.09 | 1114.0625 |   3.46 MB |
 |  Test_v_4_0_transformator |  4.989 ms | 0.0183 ms | 0.0171 ms |   0.13 |  930.7292 |   3.04 MB |
 |  Test_v_4_1_transformator |  5.221 ms | 0.0205 ms | 0.0191 ms |   0.14 |  941.1458 |   3.04 MB |
 |  Test_v_4_2_transformator |  3.932 ms | 0.0200 ms | 0.0187 ms |   0.11 |  714.5833 |   2.35 MB |
