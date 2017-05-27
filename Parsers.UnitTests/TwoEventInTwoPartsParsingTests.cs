using Akka.IO;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.Reactive.Subjects;
using Common;

namespace Parser.UnitTests
{
    [TestFixture]
    public class TwoEventInTwoPartsParsingTests
    {
        private const string TWO_EVENTS = "Event: Trying\r\n" +
                           "SessionID: PO-PIRIOS_15B0FF9B0BA1\r\n" +
                           "SourceCallerID: 0048123456781\r\n" +
                           "DestinationCallerID: 048121234561\r\n" +
                           "CallStartDate: 27/03/2017 15:34:34.281\r\n" +
                           "Timestamp: 1490621674281\r\n" +
                           "\r\n" +
                           "Event: Trying\r\n" +
                           "SessionID: PO-PIRIOS_15B0FF9B0BA2\r\n" +
                           "SourceCallerID: 0048123456782\r\n" +
                           "DestinationCallerID: 048121234562\r\n" +
                           "CallStartDate: 27/03/2017 15:34:34.282\r\n" +
                           "Timestamp: 1490621674282\r\n" +
                           "\r\n";

        private static IEnumerable<TestCaseData> GetTestsCases()
        {
            foreach (var target in TestCasesStore.Transformators)
            {
                for (int i = 0; i < TWO_EVENTS.Length; i++)
                {
                    ByteString firstInputPart = ByteString.FromString(TWO_EVENTS.Substring(0, i));
                    ByteString secondInputPart = ByteString.FromString(TWO_EVENTS.Substring(i, TWO_EVENTS.Length - i));
                    yield return new TestCaseData(firstInputPart, secondInputPart, target);
                }
            }
        }

        [TestCaseSource(typeof(TwoEventInTwoPartsParsingTests), nameof(TwoEventInTwoPartsParsingTests.GetTestsCases))]
        public void GIVEN_two_event_in_two_parts_WHEN_parse_THEN_get_two_event_object(ByteString firstPart, ByteString secondPart, ISubject<ByteString, CtiEvent> target)
        {
            // arrange
            IObserver<CtiEvent> consumer = MockRepository.GenerateStub<IObserver<CtiEvent>>();

            // act
            target.Subscribe(consumer);
            target.OnNext(firstPart);
            target.OnNext(secondPart);
            target.OnCompleted();

            // assert
            consumer.AssertWasCalled(f => f.OnNext(Arg<TryingEvent>.Matches(e =>
                e.SessionId == "PO-PIRIOS_15B0FF9B0BA1" &&
                e.SourceCallerId == "0048123456781" &&
                e.DestinationCallerId == "048121234561" &&
                e.CallStartDate == "27/03/2017 15:34:34.281" &&
                e.Timestamp == "1490621674281"
            )), f => f.Repeat.Times(1));

            consumer.AssertWasCalled(f => f.OnNext(Arg<TryingEvent>.Matches(e =>
                e.SessionId == "PO-PIRIOS_15B0FF9B0BA2" &&
                e.SourceCallerId == "0048123456782" &&
                e.DestinationCallerId == "048121234562" &&
                e.CallStartDate == "27/03/2017 15:34:34.282" &&
                e.Timestamp == "1490621674282"
            )), f => f.Repeat.Times(1));

            consumer.AssertWasCalled(f => f.OnCompleted());
            consumer.AssertWasNotCalled(f => f.OnError(Arg<Exception>.Is.Anything));
        }
    }
}
