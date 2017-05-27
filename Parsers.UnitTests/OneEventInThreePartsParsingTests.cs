using Akka.IO;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Reactive.Subjects;
using Common;

namespace Parser.UnitTests
{
    [TestFixture]
    public class OneEventInThreePartsParsingTests
    {
        [TestCaseSource(typeof(TestCasesStore), nameof(TestCasesStore.GetTestCasesForTransformator))]
        public void GIVEN_one_event_in_three_parts_WHEN_parse_three_times_THEN_get_one_event_object(ISubject<ByteString, CtiEvent> target)
        {
            // arrange
            IObserver<CtiEvent> consumer = MockRepository.GenerateStub<IObserver<CtiEvent>>();

            var firstPart = ByteString.FromString("Event: Trying\r\n" +
                                "SessionID: PO-PIRIOS_15B0FF9B0BA1\r\n" +
                                "SourceCall");

            var secondPart = ByteString.FromString("erID: 0048123456781\r\n" +
                                "DestinationCallerID: 048121234561\r\n" +
                                "CallStartD");

            var thirdPart = ByteString.FromString("ate: 27/03/2017 15:34:34.281\r\n" +
                                "Timestamp: 1490621674281\r\n" +
                                "\r\n");

            // act
            target.Subscribe(consumer);
            target.OnNext(firstPart);
            target.OnNext(secondPart);
            target.OnNext(thirdPart);
            target.OnCompleted();

            // assert
            consumer.AssertWasCalled(f => f.OnNext(Arg<TryingEvent>.Matches(e =>
                e.SessionId == "PO-PIRIOS_15B0FF9B0BA1" &&
                e.SourceCallerId == "0048123456781" &&
                e.DestinationCallerId == "048121234561" &&
                e.CallStartDate == "27/03/2017 15:34:34.281" &&
                e.Timestamp == "1490621674281"
            )), f => f.Repeat.Times(1));

            consumer.AssertWasCalled(f => f.OnCompleted());
            consumer.AssertWasNotCalled(f => f.OnError(Arg<Exception>.Is.Anything));
        }
    }
}
