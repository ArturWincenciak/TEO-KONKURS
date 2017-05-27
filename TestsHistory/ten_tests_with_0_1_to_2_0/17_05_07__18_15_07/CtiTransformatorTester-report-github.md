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
 |  Test_v_0_1_transformator | 37.380 ms | 0.1420 ms | 0.1328 ms |   1.00 | 4908.3333 |  16.31 MB |
 |  Test_v_0_2_transformator | 11.202 ms | 0.0342 ms | 0.0320 ms |   0.30 | 2421.8750 |   7.69 MB |
 |  Test_v_0_3_transformator |  9.779 ms | 0.0712 ms | 0.0631 ms |   0.26 | 1839.5833 |   5.91 MB |
 |  Test_v_0_4_transformator |  9.756 ms | 0.0536 ms | 0.0502 ms |   0.26 | 1835.4167 |   5.91 MB |
 |  Test_v_0_5_transformator |  5.486 ms | 0.0171 ms | 0.0160 ms |   0.15 | 1552.0833 |   4.88 MB |
 |  Test_v_0_6_transformator |  5.148 ms | 0.0190 ms | 0.0178 ms |   0.14 | 2018.7500 |   6.29 MB |
 |  Test_v_0_7_transformator |  3.785 ms | 0.0098 ms | 0.0077 ms |   0.10 | 1992.7083 |    6.1 MB |
 |  Test_v_0_8_transformator |  3.321 ms | 0.0119 ms | 0.0111 ms |   0.09 | 1407.0313 |   4.33 MB |
 |  Test_v_0_9_transformator |  2.460 ms | 0.0079 ms | 0.0073 ms |   0.07 | 1408.0729 |   4.33 MB |
 | Test_v_0_10_transformator |  2.448 ms | 0.0076 ms | 0.0071 ms |   0.07 | 1403.9063 |   4.33 MB |
 | Test_v_0_11_transformator |  2.447 ms | 0.0068 ms | 0.0060 ms |   0.07 | 1402.8646 |   4.33 MB |
 | Test_v_0_12_transformator |  2.547 ms | 0.0116 ms | 0.0108 ms |   0.07 | 1522.9167 |   4.69 MB |
 |  Test_v_1_1_transformator |  2.425 ms | 0.0125 ms | 0.0117 ms |   0.06 | 1401.8229 |   4.33 MB |
 |  Test_v_1_2_transformator |  2.419 ms | 0.0067 ms | 0.0062 ms |   0.06 | 1402.8646 |   4.33 MB |
 |  Test_v_2_0_transformator |  2.974 ms | 0.0107 ms | 0.0100 ms |   0.08 | 1402.8646 |   4.33 MB |
