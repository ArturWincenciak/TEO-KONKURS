﻿using Akka.IO;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using System.Reactive.Subjects;
using Common;

namespace Parser.UnitTests
{
    [TestFixture]
    public class MoreThenOneEventInOnePartParsingTests
    {
        [TestCaseSource(typeof(TestCasesStore), nameof(TestCasesStore.GetTestCasesForTransformator))]
        public void GIVEN_two_events_in_one_part_WHEN_parse_THEN_get_two_event_objects(ISubject<ByteString, CtiEvent> target)
        {
            // arrange
            IObserver<CtiEvent> consumer = MockRepository.GenerateStub<IObserver<CtiEvent>>();

            var input = ByteString.FromString("Event: Trying\r\n" +
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

        [TestCaseSource(typeof(TestCasesStore), nameof(TestCasesStore.GetTestCasesForTransformator))]
        public void GIVEN_three_events_in_one_part_WHEN_parse_THEN_get_three_event_objects(ISubject<ByteString, CtiEvent> target)
        {
            // arrange
            IObserver<CtiEvent> consumer = MockRepository.GenerateStub<IObserver<CtiEvent>>();

            var input = ByteString.FromString("Event: Trying\r\n" +
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
                           "\r\n"+
                           "Event: Trying\r\n" +
                           "SessionID: PO-PIRIOS_15B0FF9B0BA3\r\n" +
                           "SourceCallerID: 0048123456783\r\n" +
                           "DestinationCallerID: 048121234563\r\n" +
                           "CallStartDate: 27/03/2017 15:34:34.283\r\n" +
                           "Timestamp: 1490621674283\r\n" +
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

            consumer.AssertWasCalled(f => f.OnNext(Arg<TryingEvent>.Matches(e =>
                e.SessionId == "PO-PIRIOS_15B0FF9B0BA2" &&
                e.SourceCallerId == "0048123456782" &&
                e.DestinationCallerId == "048121234562" &&
                e.CallStartDate == "27/03/2017 15:34:34.282" &&
                e.Timestamp == "1490621674282"
            )), f => f.Repeat.Times(1));

            consumer.AssertWasCalled(f => f.OnNext(Arg<TryingEvent>.Matches(e =>
                e.SessionId == "PO-PIRIOS_15B0FF9B0BA3" &&
                e.SourceCallerId == "0048123456783" &&
                e.DestinationCallerId == "048121234563" &&
                e.CallStartDate == "27/03/2017 15:34:34.283" &&
                e.Timestamp == "1490621674283"
            )), f => f.Repeat.Times(1));

            consumer.AssertWasCalled(f => f.OnCompleted());
            consumer.AssertWasNotCalled(f => f.OnError(Arg<Exception>.Is.Anything));
        }
    }
}
