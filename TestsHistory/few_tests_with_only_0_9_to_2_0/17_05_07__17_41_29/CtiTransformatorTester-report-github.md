``` ini

BenchmarkDotNet=v0.10.5, OS=Windows 10.0.15063
Processor=Intel Core i7-4710MQ CPU 2.50GHz (Haswell), ProcessorCount=8
Frequency=2435773 Hz, Resolution=410.5473 ns, Timer=TSC
  [Host]            : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2046.0
  LegacyJit-Clr-X86 : Clr 4.0.30319.42000, 32bit LegacyJIT-v4.7.2046.0

Job=LegacyJit-Clr-X86  Jit=LegacyJit  Platform=X86  
Runtime=Clr  

```
 |                    Method |     Mean |     Error |    StdDev | Scaled | ScaledSD |     Gen 0 | Allocated |
 |-------------------------- |---------:|----------:|----------:|-------:|---------:|----------:|----------:|
 |  Test_v_0_9_transformator | 2.372 ms | 0.0065 ms | 0.0057 ms |   1.01 |     0.00 | 1401.8229 |   4.33 MB |
 | Test_v_0_10_transformator | 2.545 ms | 0.0082 ms | 0.0077 ms |   1.08 |     0.00 | 1407.0313 |   4.33 MB |
 | Test_v_0_11_transformator | 2.357 ms | 0.0090 ms | 0.0080 ms |   1.00 |     0.00 | 1405.9896 |   4.33 MB |
 | Test_v_0_12_transformator | 2.465 ms | 0.0061 ms | 0.0054 ms |   1.05 |     0.00 | 1523.9583 |   4.69 MB |
 |  Test_v_1_1_transformator | 2.480 ms | 0.0494 ms | 0.0529 ms |   1.05 |     0.02 | 1421.2450 |   4.33 MB |
 |  Test_v_1_2_transformator | 2.433 ms | 0.0408 ms | 0.0362 ms |   1.03 |     0.02 | 1407.0313 |   4.33 MB |
 |  Test_v_2_0_transformator | 2.965 ms | 0.0110 ms | 0.0097 ms |   1.26 |     0.01 | 1394.5313 |   4.33 MB |
