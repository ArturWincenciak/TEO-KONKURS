using System;
using Common;
using v_1_1.Protocol;
using System.Reactive.Subjects;
using System.Reactive.Disposables;

namespace v_1_1
{
    public class CtiParser : ISubject<string, CtiEvent>
    {
        private IObserver<CtiEvent> observer;

        public void OnNext(string value)
        {
            Parse(value);
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


        private void Parse(string input)
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

        private void ParseTryingEvent(string input)
        {
            TryingEvent outputEvent = new TryingEvent();

            outputEvent.SessionId = input.Substring(Shift.Trying.SESSION_ID_IDX_SHIFT, Shift.SESSION_ID_VALU);

            int idx = Shift.Trying.SOURCE_CALLER_ID_IDX_SHIFT;
            for (int i = idx; ; i += 2)
            {
                switch ((byte)input[i])
                {
                    case Asci.CR:
                        {
                            outputEvent.SourceCallerId = input.Substring(idx, i - idx);
                            idx = i - 1;
                            goto LEAVE_FOR_1;
                        }
                    case Asci.LF:
                        {
                            outputEvent.SourceCallerId = input.Substring(idx, i - idx - 1);
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
                            outputEvent.DestinationCallerId = input.Substring(idx, i - idx);
                            idx = i - 1;
                            goto LEAVE_FOR_2;
                        }
                    case Asci.LF:
                        {
                            outputEvent.DestinationCallerId = input.Substring(idx, i - idx - 1);
                            idx = i - 2;
                            goto LEAVE_FOR_2;
                        }
                }
            }

        LEAVE_FOR_2:

            idx += Shift.Trying.CALL_START_DATE_SHIFT;
            int limit = idx + Shift.CALL_START_DATE_VALU;
            outputEvent.CallStartDate = input.Substring(idx, limit - idx);

            idx = limit + Shift.Trying.TIMESTAMP_SHIFT;
            limit = idx + Shift.TIMESTAMP_VALU;
            outputEvent.Timestamp = input.Substring(idx, limit - idx);

            observer.OnNext(outputEvent);
        }

        private CtiEvent ParseSessionCloseEvent(string input)
        {
            throw new NotImplementedException();
        }

        private CtiEvent ParseUnLinkEvent(string input)
        {
            throw new NotImplementedException();
        }

        private CtiEvent ParsePeerStatusEvent(string input)
        {
            throw new NotImplementedException();
        }

        private CtiEvent ParseLinkEvent(string input)
        {
            throw new NotImplementedException();
        }

        private CtiEvent ParseHoldEvent(string input)
        {
            throw new NotImplementedException();
        }

        private CtiEvent ParseHangupEvent(string input)
        {
            throw new NotImplementedException();
        }

        private CtiEvent ParseDialEvent(string input)
        {
            throw new NotImplementedException();
        }

        private CtiEvent ParseRingingEvent(string input)
        {
            throw new NotImplementedException();
        }
    }
}
