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
 |  Test_v_0_1_transformator | 37.452 ms | 0.6758 ms | 0.5644 ms | 37.193 ms |   1.00 | 4946.4286 |  16.31 MB |
 |  Test_v_0_2_transformator | 11.333 ms | 0.1685 ms | 0.1576 ms | 11.258 ms |   0.30 | 2417.7083 |   7.69 MB |
 |  Test_v_0_3_transformator |  9.865 ms | 0.0744 ms | 0.0696 ms |  9.853 ms |   0.26 | 1835.4167 |   5.91 MB |
 |  Test_v_0_4_transformator |  9.834 ms | 0.0937 ms | 0.0876 ms |  9.806 ms |   0.26 | 1843.7500 |   5.91 MB |
 |  Test_v_0_5_transformator |  5.602 ms | 0.1288 ms | 0.1378 ms |  5.541 ms |   0.15 | 1554.1667 |   4.88 MB |
 |  Test_v_0_6_transformator |  5.172 ms | 0.0941 ms | 0.0786 ms |  5.149 ms |   0.14 | 2018.7500 |   6.29 MB |
 |  Test_v_0_7_transformator |  3.780 ms | 0.0101 ms | 0.0090 ms |  3.781 ms |   0.10 | 1992.7083 |    6.1 MB |
 |  Test_v_0_8_transformator |  3.306 ms | 0.0317 ms | 0.0281 ms |  3.297 ms |   0.09 | 1403.9063 |   4.33 MB |
 |  Test_v_0_9_transformator |  2.445 ms | 0.0088 ms | 0.0063 ms |  2.446 ms |   0.07 | 1430.1031 |   4.33 MB |
 | Test_v_0_10_transformator |  2.513 ms | 0.0562 ms | 0.1479 ms |  2.432 ms |   0.07 | 1401.8229 |   4.33 MB |
 | Test_v_0_11_transformator |  2.715 ms | 0.0788 ms | 0.2322 ms |  2.671 ms |   0.07 | 1434.5815 |   4.33 MB |
 | Test_v_0_12_transformator |  2.552 ms | 0.0116 ms | 0.0097 ms |  2.552 ms |   0.07 | 1518.7500 |   4.69 MB |
 |  Test_v_1_1_transformator |  2.445 ms | 0.0641 ms | 0.1250 ms |  2.387 ms |   0.07 | 1401.8229 |   4.33 MB |
 |  Test_v_1_2_transformator |  2.425 ms | 0.0472 ms | 0.0442 ms |  2.411 ms |   0.06 | 1401.8229 |   4.33 MB |
 |  Test_v_2_0_transformator |  3.019 ms | 0.0598 ms | 0.1093 ms |  2.966 ms |   0.08 | 1409.3339 |   4.33 MB |
 |  Test_v_3_0_transformator |  3.426 ms | 0.0382 ms | 0.0357 ms |  3.413 ms |   0.09 | 1108.8542 |   3.46 MB |
 |  Test_v_4_0_transformator |  4.965 ms | 0.0165 ms | 0.0137 ms |  4.963 ms |   0.13 |  932.8125 |   3.04 MB |
 |  Test_v_4_1_transformator |  5.408 ms | 0.1041 ms | 0.1198 ms |  5.428 ms |   0.14 |  939.0625 |   3.04 MB |
 |  Test_v_4_2_transformator |  3.911 ms | 0.0166 ms | 0.0155 ms |  3.909 ms |   0.10 |  742.7083 |   2.35 MB |
