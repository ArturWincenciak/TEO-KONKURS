using System;
using Common;
using System.Reactive.Subjects;
using System.Reactive.Disposables;
using v_4_2.Protocol;

namespace v_4_2
{
    public class CtiParser : ISubject<CycleByteBuffer, CtiEvent>
    {
        private IObserver<CtiEvent> observer;

        public void OnNext(CycleByteBuffer value)
        {
            try
            {
                Parse(value);
            }
            catch (Exception error)
            {
                observer.OnError(error);
            }
        }

        public void OnError(Exception error)
        {
            observer.OnError(error);
        }

        public void OnCompleted()
        {
            observer.OnCompleted();
        }

        public IDisposable Subscribe(IObserver<CtiEvent> observer)
        {
            this.observer = observer;
            return Disposable.Empty;
        }


        private void Parse(CycleByteBuffer input)
        {
            switch ((byte)input[Shift.EVENT_TYPE])
            {
                case EventType.TRYING:
                    {
                        ParseTryingEvent(input);
                        break;
                    }
                case EventType.RINGING:
                    {
                        ParseRingingEvent(input);
                        break;
                    }
                case EventType.DIAL:
                    {
                        ParseDialEvent(input);
                        break;
                    }
                case EventType.HUNGUP_OR_HOLD:
                    {
                        switch ((byte)input[Shift.EVENT_TYPE + 1])
                        {
                            case EventType.HANGUP:
                                {
                                    ParseHangupEvent(input);
                                    break;
                                }
                            case EventType.HOLD:
                                {
                                    ParseHoldEvent(input);
                                    break;
                                }
                            default:
                                {
                                    observer.OnError(new Exception($"Input: '{input}' has incorrect signature of event type."));
                                    break;
                                }
                        }
                        break;
                    }
                case EventType.LINK:
                    {
                        ParseLinkEvent(input);
                        break;
                    }
                case EventType.PEER_STATUS:
                    {
                        ParsePeerStatusEvent(input);
                        break;
                    }
                case EventType.UNLINK:
                    {
                        ParseUnLinkEvent(input);
                        break; 
                    }
                case EventType.SESSION_CLOSE:
                    {
                        ParseSessionCloseEvent(input);
                        break;
                    }
                default:
                    {
                        observer.OnError(new Exception($"Input: '{input}' has incorrect signature of event type."));
                        break;
                    }
            }
        }

        private void ParseTryingEvent(CycleByteBuffer input)
        {
            TryingEvent outputEvent = new TryingEvent();

            outputEvent.SessionId = input.ToString(Shift.Trying.SESSION_ID_IDX_SHIFT, Shift.SESSION_ID_VALU);

            int idx = Shift.Trying.SOURCE_CALLER_ID_IDX_SHIFT;
            for (int i = idx; ; i += 2)
            {
                switch ((byte)input[i])
                {
                    case Asci.CR:
                        {
                            outputEvent.SourceCallerId = input.ToString(idx, i - idx);
                            idx = i - 1;
                            goto LEAVE_FOR_1;
                        }
                    case Asci.LF:
                        {
                            outputEvent.SourceCallerId = input.ToString(idx, i - idx - 1);
                            idx = i - 2;
                            goto LEAVE_FOR_1;
                        }
                }
            }

        LEAVE_FOR_1:

            idx += Shift.Trying.DESTINATION_CALLER_ID_SHIFT;
            for (int i = idx; ; i += 2)
            {
                switch ((byte)input[i])
                {
                    case Asci.CR:
                        {
                            outputEvent.DestinationCallerId = input.ToString(idx, i - idx);
                            idx = i - 1;
                            goto LEAVE_FOR_2;
                        }
                    case Asci.LF:
                        {
                            outputEvent.DestinationCallerId = input.ToString(idx, i - idx - 1);
                            idx = i - 2;
                            goto LEAVE_FOR_2;
                        }
                }
            }

        LEAVE_FOR_2:

            idx += Shift.Trying.CALL_START_DATE_SHIFT;
            int limit = idx + Shift.CALL_START_DATE_VALU;
            outputEvent.CallStartDate = input.ToString(idx, limit - idx);

            idx = limit + Shift.Trying.TIMESTAMP_SHIFT;
            limit = idx + Shift.TIMESTAMP_VALU;
            outputEvent.Timestamp = input.ToString(idx, limit - idx);

            observer.OnNext(outputEvent);
        }

        private CtiEvent ParseSessionCloseEvent(CycleByteBuffer input)
        {
            throw new NotImplementedException();
        }

        private CtiEvent ParseUnLinkEvent(CycleByteBuffer input)
        {
            throw new NotImplementedException();
        }

        private CtiEvent ParsePeerStatusEvent(CycleByteBuffer input)
        {
            throw new NotImplementedException();
        }

        private CtiEvent ParseLinkEvent(CycleByteBuffer input)
        {
            throw new NotImplementedException();
        }

        private CtiEvent ParseHoldEvent(CycleByteBuffer input)
        {
            throw new NotImplementedException();
        }

        private CtiEvent ParseHangupEvent(CycleByteBuffer input)
        {
            throw new NotImplementedException();
        }

        private CtiEvent ParseDialEvent(CycleByteBuffer input)
        {
            throw new NotImplementedException();
        }

        private CtiEvent ParseRingingEvent(CycleByteBuffer input)
        {
            throw new NotImplementedException();
        }
    }
}
