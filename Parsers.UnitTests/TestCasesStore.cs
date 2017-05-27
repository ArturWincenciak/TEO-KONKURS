using System.Collections.Generic;
using System.Reactive.Subjects;
using Akka.IO;
using Common;
using NUnit.Framework;

namespace Parser.UnitTests
{
    public class TestCasesStore
    {
        public static readonly ISubject<ByteString, CtiEvent>[] Transformators = 
        {
            new v_0_1.CtiTransformator(new v_0_1.CtiParser()),
            new v_0_2.CtiTransformator(new v_0_2.CtiParser()),
            new v_0_3.CtiTransformator(new v_0_3.CtiParser()),
            new v_0_4.CtiTransformator(new v_0_4.CtiParser()),
            new v_0_5.CtiTransformator(new v_0_5.CtiParser()),
            new v_0_6.CtiTransformator(new v_0_6.CtiParser()),
            new v_0_7.CtiTransformator(new v_0_7.CtiParser()),
            new v_0_8.CtiTransformator(new v_0_8.CtiParser()),
            new v_0_9.CtiTransformator(new v_0_9.CtiParser()),
            new v_0_10.CtiTransformator(new v_0_10.CtiParser()),
            new v_0_11.CtiTransformator(new v_0_11.CtiParser()),
            new v_0_12.CtiTransformator(new v_0_12.CtiParser()),
            new v_1_1.CtiTransformator(new v_1_1.ByteBuffer(), new v_1_1.CtiParser()),
            new v_1_2.CtiTransformator(new v_1_2.ByteBuffer(), new v_1_2.CtiParser()),
            new v_2_0.CtiTransformator(),
            new v_3_0.CtiTransformator(new v_3_0.ByteBuffer(), new v_3_0.CtiParser()),
            new v_4_0.CtiTransformator(new v_4_0.ByteBuffer(), new v_4_0.CtiParser()),
            new v_4_1.CtiTransformator(new v_4_1.ByteBuffer(), new v_4_1.CtiParser()),
            new v_4_2.CtiTransformator(new v_4_2.ByteBuffer(), new v_4_2.CtiParser())
        };

        public static IEnumerable<TestCaseData> GetTestCasesForTransformator()
        {
            foreach (ISubject<ByteString, CtiEvent> transformator in Transformators)
            {
                yield return new TestCaseData(transformator);
            }
        }
    }
}
