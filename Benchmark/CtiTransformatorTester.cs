using Akka.IO;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;

namespace BenchmarkTeoVincent
{
    //[HardwareCounters(HardwareCounter.BranchMispredictions, HardwareCounter.BranchInstructions)]
    [MemoryDiagnoser]
    //[InliningDiagnoser]
    [HtmlExporter]
    [CsvMeasurementsExporter]
    //[RPlotExporter]
    [Config(typeof(Config))]
    public class CtiTransformatorTester
    {
        private static int iterationsCount;
        private static ByteString[] input;
        private static NullCtiEventConsumer consumer;

        private static v_0_1.CtiTransformator v_0_1_transformator;
        private static v_0_2.CtiTransformator v_0_2_transformator;
        private static v_0_3.CtiTransformator v_0_3_transformator;
        private static v_0_4.CtiTransformator v_0_4_transformator;
        private static v_0_5.CtiTransformator v_0_5_transformator;
        private static v_0_6.CtiTransformator v_0_6_transformator;
        private static v_0_7.CtiTransformator v_0_7_transformator;
        private static v_0_8.CtiTransformator v_0_8_transformator;
        private static v_0_9.CtiTransformator v_0_9_transformator;
        private static v_0_10.CtiTransformator v_0_10_transformator;
        private static v_0_11.CtiTransformator v_0_11_transformator;
        private static v_0_12.CtiTransformator v_0_12_transformator;
        private static v_1_1.CtiTransformator v_1_1_transformator;
        private static v_1_2.CtiTransformator v_1_2_transformator;
        private static v_2_0.CtiTransformator v_2_0_transformator;
        private static v_3_0.CtiTransformator v_3_0_transformator;
        private static v_4_0.CtiTransformator v_4_0_transformator;
        private static v_4_1.CtiTransformator v_4_1_transformator;
        private static v_4_2.CtiTransformator v_4_2_transformator;

        [Setup]
        public void SetupData()
        {
            iterationsCount = 1000;
            input = new[]
            {
                oneEventInOnePart,
                oneEventInTwoParts[0],
                oneEventInTwoParts[1],
                twoEventsInOnePart,
                oneEventInThreeParts[0],
                oneEventInThreeParts[1],
                oneEventInThreeParts[2]
            };

            consumer = new NullCtiEventConsumer();

            v_0_1_transformator = new v_0_1.CtiTransformator(new v_0_1.CtiParser());
            v_0_1_transformator.Subscribe(consumer);

            v_0_2_transformator = new v_0_2.CtiTransformator(new v_0_2.CtiParser());
            v_0_2_transformator.Subscribe(consumer);

            v_0_3_transformator = new v_0_3.CtiTransformator(new v_0_3.CtiParser());
            v_0_3_transformator.Subscribe(consumer);

            v_0_4_transformator = new v_0_4.CtiTransformator(new v_0_4.CtiParser());
            v_0_4_transformator.Subscribe(consumer);

            v_0_5_transformator = new v_0_5.CtiTransformator(new v_0_5.CtiParser());
            v_0_5_transformator.Subscribe(consumer);

            v_0_6_transformator = new v_0_6.CtiTransformator(new v_0_6.CtiParser());
            v_0_6_transformator.Subscribe(consumer);

            v_0_7_transformator = new v_0_7.CtiTransformator(new v_0_7.CtiParser());
            v_0_7_transformator.Subscribe(consumer);

            v_0_8_transformator = new v_0_8.CtiTransformator(new v_0_8.CtiParser());
            v_0_8_transformator.Subscribe(consumer);

            v_0_9_transformator = new v_0_9.CtiTransformator(new v_0_9.CtiParser());
            v_0_9_transformator.Subscribe(consumer);

            v_0_10_transformator = new v_0_10.CtiTransformator(new v_0_10.CtiParser());
            v_0_10_transformator.Subscribe(consumer);

            v_0_11_transformator = new v_0_11.CtiTransformator(new v_0_11.CtiParser());
            v_0_11_transformator.Subscribe(consumer);

            v_0_12_transformator = new v_0_12.CtiTransformator(new v_0_12.CtiParser());
            v_0_12_transformator.Subscribe(consumer);

            v_1_1_transformator = new v_1_1.CtiTransformator(new v_1_1.ByteBuffer(), new v_1_1.CtiParser());
            v_1_1_transformator.Subscribe(consumer);

            v_1_2_transformator = new v_1_2.CtiTransformator(new v_1_2.ByteBuffer(), new v_1_2.CtiParser());
            v_1_2_transformator.Subscribe(consumer);

            v_2_0_transformator = new v_2_0.CtiTransformator();
            v_2_0_transformator.Subscribe(consumer);

            v_3_0_transformator = new v_3_0.CtiTransformator(new v_3_0.ByteBuffer(), new v_3_0.CtiParser());
            v_3_0_transformator.Subscribe(consumer);

            v_4_0_transformator = new v_4_0.CtiTransformator(new v_4_0.ByteBuffer(), new v_4_0.CtiParser());
            v_4_0_transformator.Subscribe(consumer);

            v_4_1_transformator = new v_4_1.CtiTransformator(new v_4_1.ByteBuffer(), new v_4_1.CtiParser());
            v_4_1_transformator.Subscribe(consumer);

            v_4_2_transformator = new v_4_2.CtiTransformator(new v_4_2.ByteBuffer(), new v_4_2.CtiParser());
            v_4_2_transformator.Subscribe(consumer);
        }

        [Benchmark(Baseline = true)]
        public static void Test_v_0_1_transformator()
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (ByteString inp in input)
                {
                    v_0_1_transformator.OnNext(inp);
                }
            }
        }

        [Benchmark]
        public static void Test_v_0_2_transformator()
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (ByteString inp in input)
                {
                    v_0_2_transformator.OnNext(inp);
                }
            }
        }

        [Benchmark]
        public static void Test_v_0_3_transformator()
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (ByteString inp in input)
                {
                    v_0_3_transformator.OnNext(inp);
                }
            }
        }

        [Benchmark]
        public static void Test_v_0_4_transformator()
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (ByteString inp in input)
                {
                    v_0_4_transformator.OnNext(inp);
                }
            }
        }

        [Benchmark]
        public static void Test_v_0_5_transformator()
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (ByteString inp in input)
                {
                    v_0_5_transformator.OnNext(inp);
                }
            }
        }

        [Benchmark]
        public static void Test_v_0_6_transformator()
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (ByteString inp in input)
                {
                    v_0_6_transformator.OnNext(inp);
                }
            }
        }

        [Benchmark]
        public static void Test_v_0_7_transformator()
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (ByteString inp in input)
                {
                    v_0_7_transformator.OnNext(inp);
                }
            }
        }

        [Benchmark]
        public static void Test_v_0_8_transformator()
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (ByteString inp in input)
                {
                    v_0_8_transformator.OnNext(inp);
                }
            }
        }

        [Benchmark]
        public static void Test_v_0_9_transformator()
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (ByteString inp in input)
                {
                    v_0_9_transformator.OnNext(inp);
                }
            }
        }

        [Benchmark]
        public static void Test_v_0_10_transformator()
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (ByteString inp in input)
                {
                    v_0_10_transformator.OnNext(inp);
                }
            }
        }

        [Benchmark]
        public static void Test_v_0_11_transformator()
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (ByteString inp in input)
                {
                    v_0_11_transformator.OnNext(inp);
                }
            }
        }

        [Benchmark]
        public static void Test_v_0_12_transformator()
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (ByteString inp in input)
                {
                    v_0_12_transformator.OnNext(inp);
                }
            }
        }

        [Benchmark]
        public static void Test_v_1_1_transformator()
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (ByteString inp in input)
                {
                    v_1_1_transformator.OnNext(inp);
                }
            }
        }

        [Benchmark]
        public static void Test_v_1_2_transformator()
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (ByteString inp in input)
                {
                    v_1_2_transformator.OnNext(inp);
                }
            }
        }

        [Benchmark]
        public static void Test_v_2_0_transformator()
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (ByteString inp in input)
                {
                    v_2_0_transformator.OnNext(inp);
                }
            }
        }

        [Benchmark]
        public static void Test_v_3_0_transformator()
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (ByteString inp in input)
                {
                    v_3_0_transformator.OnNext(inp);
                }
            }
        }

        [Benchmark]
        public static void Test_v_4_0_transformator()
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (ByteString inp in input)
                {
                    v_4_0_transformator.OnNext(inp);
                }
            }
        }

        [Benchmark]
        public static void Test_v_4_1_transformator()
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (ByteString inp in input)
                {
                    v_4_1_transformator.OnNext(inp);
                }
            }
        }

        [Benchmark]
        public static void Test_v_4_2_transformator()
        {
            for (int i = 0; i < iterationsCount; i++)
            {
                foreach (ByteString inp in input)
                {
                    v_4_2_transformator.OnNext(inp);
                }
            }
        }

        private static readonly ByteString oneEventInOnePart = ByteString.FromString("Event: Trying\r\n" +
                                  "SessionID: PO-PIRIOS_15B0FF9B0BA1\r\n" +
                                  "SourceCallerID: 0048123456789\r\n" +
                                  "DestinationCallerID: 048121234567\r\n" +
                                  "CallStartDate: 27/03/2017 15:34:34.281\r\n" +
                                  "Timestamp: 1490621674281\r\n" +
                                  "\r\n");

        private static readonly ByteString[] oneEventInTwoParts = new[]
        {
            ByteString.FromString("Event: Trying\r\n" +
                                  "SessionID: PO-PIRIOS_15B0FF9B0BA1\r\n" +
                                  "SourceCallerID: 0048123456789\r\n" +
                                  "DestinationCal"),
            ByteString.FromString("lerID: 048121234567\r\n" +
                                  "CallStartDate: 27/03/2017 15:34:34.281\r\n" +
                                  "Timestamp: 1490621674281\r\n" +
                                  "\r\n"),
        };

        private static readonly ByteString twoEventsInOnePart = ByteString.FromString("Event: Trying\r\n" +
                                  "SessionID: PO-PIRIOS_15B0FF9B0BA1\r\n" +
                                  "SourceCallerID: 0048123456789\r\n" +
                                  "DestinationCallerID: 048121234567\r\n" +
                                  "CallStartDate: 27/03/2017 15:34:34.281\r\n" +
                                  "Timestamp: 1490621674281\r\n" +
                                  "\r\n" +
                                  "Event: Trying\r\n" +
                                  "SessionID: PO-PIRIOS_15B0FF9B0BA1\r\n" +
                                  "SourceCallerID: 2222\r\n" +
                                  "DestinationCallerID: 5555\r\n" +
                                  "CallStartDate: 27/03/2017 15:34:34.281\r\n" +
                                  "Timestamp: 1490621674281\r\n" +
                                  "\r\n");

        private static readonly ByteString[] oneEventInThreeParts = new[]
        {
            ByteString.FromString("Event: Trying\r\n" +
                                  "SessionID: PO-PIRIOS_15B0FF9B0BA1\r\n" +
                                  "SourceCall"),
            ByteString.FromString("erID: 0048123456789\r\n" +
                                  "DestinationCal"),
            ByteString.FromString("lerID: 048121234567\r\n" +
                                  "CallStartDate: 27/03/2017 15:34:34.281\r\n" +
                                  "Timestamp: 1490621674281\r\n" +
                                  "\r\n")
        };
    }
}
