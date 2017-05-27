``` ini

BenchmarkDotNet=v0.10.5, OS=Windows 10.0.15063
Processor=Intel Core i7-4710MQ CPU 2.50GHz (Haswell), ProcessorCount=8
Frequency=2435781 Hz, Resolution=410.5459 ns, Timer=TSC
  [Host]            : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2098.0
  LegacyJit-Clr-X86 : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2098.0

Job=LegacyJit-Clr-X86  Jit=LegacyJit  Platform=X86  
Runtime=Clr  

```
 |                    Method |      Mean |     Error |    StdDev | Scaled | ScaledSD |     Gen 0 | Allocated |
 |-------------------------- |----------:|----------:|----------:|-------:|---------:|----------:|----------:|
 |  Test_v_0_1_transformator | 39.686 ms | 1.1612 ms | 3.3318 ms |   1.00 |     0.00 | 4843.7500 |  16.31 MB |
 |  Test_v_0_2_transformator | 11.140 ms | 0.1289 ms | 0.1076 ms |   0.28 |     0.02 | 2409.3750 |   7.69 MB |
 |  Test_v_0_3_transformator |  9.537 ms | 0.1158 ms | 0.1027 ms |   0.24 |     0.02 | 1835.4167 |   5.91 MB |
 |  Test_v_0_4_transformator |  9.664 ms | 0.0969 ms | 0.0906 ms |   0.25 |     0.02 | 1839.5833 |   5.91 MB |
 |  Test_v_0_5_transformator |  5.427 ms | 0.0887 ms | 0.0786 ms |   0.14 |     0.01 | 1556.2500 |   4.88 MB |
 |  Test_v_0_6_transformator |  5.057 ms | 0.0910 ms | 0.0806 ms |   0.13 |     0.01 | 2025.0000 |   6.29 MB |
 |  Test_v_0_7_transformator |  3.662 ms | 0.0330 ms | 0.0308 ms |   0.09 |     0.01 | 1993.7500 |    6.1 MB |
 |  Test_v_0_8_transformator |  3.230 ms | 0.0596 ms | 0.0585 ms |   0.08 |     0.01 | 1399.7396 |   4.33 MB |
 |  Test_v_0_9_transformator |  2.386 ms | 0.0210 ms | 0.0186 ms |   0.06 |     0.00 | 1402.8646 |   4.33 MB |
 | Test_v_0_10_transformator |  2.325 ms | 0.0188 ms | 0.0157 ms |   0.06 |     0.00 | 1396.6146 |   4.33 MB |
 | Test_v_0_11_transformator |  2.370 ms | 0.0307 ms | 0.0287 ms |   0.06 |     0.00 | 1407.0313 |   4.33 MB |
 | Test_v_0_12_transformator |  2.502 ms | 0.0202 ms | 0.0189 ms |   0.06 |     0.00 | 1525.0000 |   4.69 MB |
 |  Test_v_1_1_transformator |  2.323 ms | 0.0257 ms | 0.0240 ms |   0.06 |     0.00 | 1402.8646 |   4.33 MB |
 |  Test_v_1_2_transformator |  2.423 ms | 0.0219 ms | 0.0205 ms |   0.06 |     0.00 | 1401.8229 |   4.33 MB |
 |  Test_v_2_0_transformator |  2.878 ms | 0.0326 ms | 0.0289 ms |   0.07 |     0.01 | 1401.8229 |   4.33 MB |
 |  Test_v_3_0_transformator |  3.370 ms | 0.0502 ms | 0.0470 ms |   0.09 |     0.01 | 1119.6546 |   3.46 MB |
 |  Test_v_4_0_transformator |  4.932 ms | 0.0964 ms | 0.0990 ms |   0.13 |     0.01 |  948.9890 |   3.04 MB |
 |  Test_v_4_1_transformator |  5.162 ms | 0.0519 ms | 0.0485 ms |   0.13 |     0.01 |  936.9792 |   3.04 MB |
 |  Test_v_4_2_transformator |  3.826 ms | 0.0185 ms | 0.0173 ms |   0.10 |     0.01 |  741.6667 |   2.35 MB |
