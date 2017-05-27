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
 |  Test_v_0_1_transformator | 37.430 ms | 0.0936 ms | 0.0829 ms |   1.00 | 4808.3333 |  16.31 MB |
 |  Test_v_0_2_transformator | 11.211 ms | 0.0597 ms | 0.0558 ms |   0.30 | 2405.2083 |   7.69 MB |
 |  Test_v_0_3_transformator |  9.737 ms | 0.0575 ms | 0.0538 ms |   0.26 | 1843.7500 |   5.91 MB |
 |  Test_v_0_4_transformator |  9.684 ms | 0.0358 ms | 0.0335 ms |   0.26 | 1843.7500 |   5.91 MB |
 |  Test_v_0_5_transformator |  5.474 ms | 0.0166 ms | 0.0155 ms |   0.15 | 1543.7500 |   4.88 MB |
 |  Test_v_0_6_transformator |  5.143 ms | 0.0226 ms | 0.0211 ms |   0.14 | 2020.8333 |   6.29 MB |
 |  Test_v_0_7_transformator |  3.779 ms | 0.0140 ms | 0.0131 ms |   0.10 | 1991.6667 |    6.1 MB |
 |  Test_v_0_8_transformator |  3.337 ms | 0.0113 ms | 0.0105 ms |   0.09 | 1400.7813 |   4.33 MB |
 |  Test_v_0_9_transformator |  2.463 ms | 0.0111 ms | 0.0093 ms |   0.07 | 1407.0313 |   4.33 MB |
 | Test_v_0_10_transformator |  2.452 ms | 0.0083 ms | 0.0078 ms |   0.07 | 1401.8229 |   4.33 MB |
 | Test_v_0_11_transformator |  2.443 ms | 0.0121 ms | 0.0107 ms |   0.07 | 1400.7813 |   4.33 MB |
 | Test_v_0_12_transformator |  2.544 ms | 0.0124 ms | 0.0116 ms |   0.07 | 1522.9167 |   4.69 MB |
 |  Test_v_1_1_transformator |  2.407 ms | 0.0083 ms | 0.0077 ms |   0.06 | 1407.0313 |   4.33 MB |
 |  Test_v_1_2_transformator |  2.437 ms | 0.0088 ms | 0.0082 ms |   0.07 | 1398.6979 |   4.33 MB |
 |  Test_v_2_0_transformator |  2.971 ms | 0.0115 ms | 0.0108 ms |   0.08 | 1399.7396 |   4.33 MB |
