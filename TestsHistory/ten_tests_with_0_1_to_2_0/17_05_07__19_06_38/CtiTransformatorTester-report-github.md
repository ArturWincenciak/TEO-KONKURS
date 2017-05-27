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
 |  Test_v_0_1_transformator | 37.470 ms | 0.1583 ms | 0.1481 ms |   1.00 | 4858.3333 |  16.31 MB |
 |  Test_v_0_2_transformator | 11.269 ms | 0.0442 ms | 0.0414 ms |   0.30 | 2413.5417 |   7.69 MB |
 |  Test_v_0_3_transformator |  9.717 ms | 0.0501 ms | 0.0469 ms |   0.26 | 1839.5833 |   5.91 MB |
 |  Test_v_0_4_transformator |  9.749 ms | 0.0321 ms | 0.0268 ms |   0.26 | 1839.5833 |   5.91 MB |
 |  Test_v_0_5_transformator |  5.508 ms | 0.0127 ms | 0.0119 ms |   0.15 | 1552.0833 |   4.88 MB |
 |  Test_v_0_6_transformator |  5.129 ms | 0.0228 ms | 0.0214 ms |   0.14 | 2027.0833 |   6.29 MB |
 |  Test_v_0_7_transformator |  3.785 ms | 0.0087 ms | 0.0077 ms |   0.10 | 1991.6667 |    6.1 MB |
 |  Test_v_0_8_transformator |  3.292 ms | 0.0072 ms | 0.0060 ms |   0.09 | 1399.7396 |   4.33 MB |
 |  Test_v_0_9_transformator |  2.462 ms | 0.0069 ms | 0.0061 ms |   0.07 | 1402.8646 |   4.33 MB |
 | Test_v_0_10_transformator |  2.450 ms | 0.0088 ms | 0.0082 ms |   0.07 | 1408.0729 |   4.33 MB |
 | Test_v_0_11_transformator |  2.442 ms | 0.0076 ms | 0.0072 ms |   0.07 | 1402.8646 |   4.33 MB |
 | Test_v_0_12_transformator |  2.550 ms | 0.0101 ms | 0.0094 ms |   0.07 | 1525.0000 |   4.69 MB |
 |  Test_v_1_1_transformator |  2.408 ms | 0.0084 ms | 0.0070 ms |   0.06 | 1401.8229 |   4.33 MB |
 |  Test_v_1_2_transformator |  2.425 ms | 0.0113 ms | 0.0105 ms |   0.06 | 1405.9896 |   4.33 MB |
 |  Test_v_2_0_transformator |  2.967 ms | 0.0076 ms | 0.0071 ms |   0.08 | 1408.0729 |   4.33 MB |
