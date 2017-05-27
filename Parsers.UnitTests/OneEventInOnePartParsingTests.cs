using System.Reactive.Subjects;
using Akka.IO;
using NUnit.Framework;
using System;
using Common;
using Rhino.Mocks;

namespace Parser.UnitTests
{
    [TestFixture]
    public class OneEventInOnePartParsingTests
    {
        [TestCaseSource(typeof(TestCasesStore), nameof(TestCasesStore.GetTestCasesForTransformator))]
        public void GIVEN_trying_string_event_WHEN_parse_THEN_get_event_object(ISubject<ByteString, CtiEvent> target)
        {
            // arrange
            IObserver<CtiEvent> consumer = MockRepository.GenerateStub<IObserver<CtiEvent>>();

            var input = ByteString.FromString("Event: Trying\r\n" +
                                              "SessionID: PO-PIRIOS_15B0FF9B0BA1\r\n" +
                                              "SourceCallerID: 0048123456781\r\n" +
                                              "DestinationCallerID: 048121234561\r\n" +
                                              "CallStartDate: 27/03/2017 15:34:34.281\r\n" +
                                              "Timestamp: 1490621674281\r\n" +
                                              "\r\n");

            // act
            target.Subscribe(consumer);
            target.OnNext(input);
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

        /*
        [Test]
        [Ignore("todo: implement it")]
        public void GIVEN_dial_string_event_WHEN_parse_THEN_get_event_object()
        {
           
        }

        [Test]
        [Ignore("todo: implement it")]
        public void GIVEN_ringing_string_event_WHEN_parse_THEN_get_event_object()
        {
           
        }

        [Test]
        [Ignore("todo: implement it")]
        public void GIVEN_link_string_event_WHEN_parse_THEN_get_event_object()
        {
           
        }

        [Test]
        [Ignore("todo: implement it")]
        public void GIVEN_unlink_string_event_WHEN_parse_THEN_get_event_object()
        {
           
        }

        [Test]
        [Ignore("todo: implement it")]
        public void GIVEN_hangup_string_event_WHEN_parse_THEN_get_event_object()
        {
           
        }

        [Test]
        [Ignore("todo: implement it")]
        public void GIVEN_peer_status_string_event_WHEN_parse_THEN_get_event_object()
        {
           
        }

        [Test]
        [Ignore("todo: implement it")]
        public void GIVEN_session_close_string_event_WHEN_parse_THEN_get_event_object()
        {
            
        }
        */
    }
}
