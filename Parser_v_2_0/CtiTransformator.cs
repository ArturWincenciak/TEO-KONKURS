using System;
using System.Reactive.Disposables;
using System.Reactive.Subjects;
using Akka.Configuration.Hocon;
using Akka.IO;
using Common;

namespace v_2_0
{
    public class CtiTransformator : ISubject<ByteString, CtiEvent>
    {
        private string buffer = string.Empty;
        private IObserver<CtiEvent> observer;

        public void OnNext(ByteString value)
        {
            buffer += value.DecodeString();

            bool foundDelimiter;
            do
            {
                foundDelimiter = false;
                for (int i = 0; i < buffer.Length - 2; i += 4)
                {
                    switch ((byte)buffer[i])
                    {
                        case CtiProtocol.CARRIAGE_RETURN:
                            {
                                if (buffer[i + CtiProtocol.SHIFT_FOR_DELIMITER] == CtiProtocol.CARRIAGE_RETURN && buffer.Length > i + 3)
                                {
                                    foundDelimiter = true;
                                    switch ((byte)buffer[CtiProtocol.SHIFT_FOR_EVENT_TYPE])
                                    {
                                        case CtiProtocol.T:
                                            {
                                                TryingEvent e = new TryingEvent();

                                                e.SessionId = buffer.Substring(CtiProtocol.SESSION_ID_IDX_SHIFT, CtiProtocol.SESSION_ID_VALU_LEN);

                                                int idx = CtiProtocol.SOURCE_CALLER_ID_IDX_SHIFT;
                                                for (int k = idx; ; k += 2)
                                                {
                                                    switch ((byte)buffer[k])
                                                    {
                                                        case CtiProtocol.CARRIAGE_RETURN:
                                                            {
                                                                e.SourceCallerId = buffer.Substring(idx, k - idx);
                                                                idx = k - 1;
                                                                goto LEAVE_FOR_1;
                                                            }
                                                        case CtiProtocol.LINE_FEED:
                                                            {
                                                                e.SourceCallerId = buffer.Substring(idx, k - idx - 1);
                                                                idx = k - 2;
                                                                goto LEAVE_FOR_1;
                                                            }
                                                    }
                                                }

                                            LEAVE_FOR_1:

                                                idx += CtiProtocol.DESTINATION_CALLER_ID_SHIFT;
                                                for (int k = idx; ; k += 2)
                                                {
                                                    switch ((byte)buffer[k])
                                                    {
                                                        case CtiProtocol.CARRIAGE_RETURN:
                                                            {
                                                                e.DestinationCallerId = buffer.Substring(idx, k - idx);
                                                                idx = k - 1;
                                                                goto LEAVE_FOR_2;
                                                            }
                                                        case CtiProtocol.LINE_FEED:
                                                            {
                                                                e.DestinationCallerId = buffer.Substring(idx, k - idx - 1);
                                                                idx = k - 2;
                                                                goto LEAVE_FOR_2;
                                                            }
                                                    }
                                                }

                                            LEAVE_FOR_2:

                                                idx += CtiProtocol.CALL_START_DATE_SHIFT;
                                                int limit = idx + CtiProtocol.CALL_START_DATE_VALU_LEN;
                                                e.CallStartDate = buffer.Substring(idx, limit - idx);

                                                idx = limit + CtiProtocol.TIMESTAMP_SHIFT;
                                                limit = idx + CtiProtocol.TIMESTAMP_VALU_LEN;
                                                e.Timestamp = buffer.Substring(idx, limit - idx);

                                                observer.OnNext(e);

                                                string cleanUpBuffer = buffer.Remove(0, i + 4);
                                                buffer = cleanUpBuffer;
                                                goto FIND_NEXT_DELIMITER;
                                            }
                                        case CtiProtocol.R:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        case CtiProtocol.D:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        case CtiProtocol.H:
                                            {
                                                switch ((byte)buffer[CtiProtocol.SHIFT_FOR_EVENT_TYPE + 1])
                                                {
                                                    case CtiProtocol.a:
                                                        {
                                                            throw new NotImplementedException();
                                                        }
                                                    case CtiProtocol.o:
                                                        {
                                                            throw new NotImplementedException();
                                                        }
                                                }

                                                throw new Exception("todo: create message...");
                                            }
                                        case CtiProtocol.L:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        case CtiProtocol.P:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        case CtiProtocol.U:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        case CtiProtocol.S:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        default:
                                            {
                                                throw new Exception("todo: create message...");
                                            }
                                    }
                                }
                                else if (buffer[i - CtiProtocol.SHIFT_FOR_DELIMITER] == CtiProtocol.CARRIAGE_RETURN && buffer.Length > i + 3)
                                {
                                    foundDelimiter = true;
                                    switch ((byte)buffer[CtiProtocol.SHIFT_FOR_EVENT_TYPE])
                                    {
                                        case CtiProtocol.T:
                                            {
                                                TryingEvent e = new TryingEvent();

                                                e.SessionId = buffer.Substring(CtiProtocol.SESSION_ID_IDX_SHIFT, CtiProtocol.SESSION_ID_VALU_LEN);

                                                int idx = CtiProtocol.SOURCE_CALLER_ID_IDX_SHIFT;
                                                for (int k = idx; ; k += 2)
                                                {
                                                    switch ((byte)buffer[k])
                                                    {
                                                        case CtiProtocol.CARRIAGE_RETURN:
                                                            {
                                                                e.SourceCallerId = buffer.Substring(idx, k - idx);
                                                                idx = k - 1;
                                                                goto LEAVE_FOR_1;
                                                            }
                                                        case CtiProtocol.LINE_FEED:
                                                            {
                                                                e.SourceCallerId = buffer.Substring(idx, k - idx - 1);
                                                                idx = k - 2;
                                                                goto LEAVE_FOR_1;
                                                            }
                                                    }
                                                }

                                            LEAVE_FOR_1:

                                                idx += CtiProtocol.DESTINATION_CALLER_ID_SHIFT;
                                                for (int k = idx; ; k += 2)
                                                {
                                                    switch ((byte)buffer[k])
                                                    {
                                                        case CtiProtocol.CARRIAGE_RETURN:
                                                            {
                                                                e.DestinationCallerId = buffer.Substring(idx, k - idx);
                                                                idx = k - 1;
                                                                goto LEAVE_FOR_2;
                                                            }
                                                        case CtiProtocol.LINE_FEED:
                                                            {
                                                                e.DestinationCallerId = buffer.Substring(idx, k - idx - 1);
                                                                idx = k - 2;
                                                                goto LEAVE_FOR_2;
                                                            }
                                                    }
                                                }

                                            LEAVE_FOR_2:

                                                idx += CtiProtocol.CALL_START_DATE_SHIFT;
                                                int limit = idx + CtiProtocol.CALL_START_DATE_VALU_LEN;
                                                e.CallStartDate = buffer.Substring(idx, limit - idx);

                                                idx = limit + CtiProtocol.TIMESTAMP_SHIFT;
                                                limit = idx + CtiProtocol.TIMESTAMP_VALU_LEN;
                                                e.Timestamp = buffer.Substring(idx, limit - idx);

                                                observer.OnNext(e);

                                                string cleanUpBuffer = buffer.Remove(0, i + 2);
                                                buffer = cleanUpBuffer;
                                                goto FIND_NEXT_DELIMITER;
                                            }
                                        case CtiProtocol.R:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        case CtiProtocol.D:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        case CtiProtocol.H:
                                            {
                                                switch ((byte)buffer[CtiProtocol.SHIFT_FOR_EVENT_TYPE + 1])
                                                {
                                                    case CtiProtocol.a:
                                                        {
                                                            throw new NotImplementedException();
                                                        }
                                                    case CtiProtocol.o:
                                                        {
                                                            throw new NotImplementedException();
                                                        }
                                                }

                                                throw new Exception("todo: create message...");
                                            }
                                        case CtiProtocol.L:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        case CtiProtocol.P:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        case CtiProtocol.U:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        case CtiProtocol.S:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        default:
                                            {
                                                throw new Exception("todo: create message...");
                                            }
                                    }
                                }
                                break;
                            }
                        case CtiProtocol.LINE_FEED:
                            {
                                if (buffer[i + CtiProtocol.SHIFT_FOR_DELIMITER] == CtiProtocol.LINE_FEED)
                                {
                                    foundDelimiter = true;
                                    switch ((byte)buffer[CtiProtocol.SHIFT_FOR_EVENT_TYPE])
                                    {
                                        case CtiProtocol.T:
                                            {
                                                TryingEvent e = new TryingEvent();

                                                e.SessionId = buffer.Substring(CtiProtocol.SESSION_ID_IDX_SHIFT, CtiProtocol.SESSION_ID_VALU_LEN);

                                                int idx = CtiProtocol.SOURCE_CALLER_ID_IDX_SHIFT;
                                                for (int k = idx; ; k += 2)
                                                {
                                                    switch ((byte)buffer[k])
                                                    {
                                                        case CtiProtocol.CARRIAGE_RETURN:
                                                            {
                                                                e.SourceCallerId = buffer.Substring(idx, k - idx);
                                                                idx = k - 1;
                                                                goto LEAVE_FOR_1;
                                                            }
                                                        case CtiProtocol.LINE_FEED:
                                                            {
                                                                e.SourceCallerId = buffer.Substring(idx, k - idx - 1);
                                                                idx = k - 2;
                                                                goto LEAVE_FOR_1;
                                                            }
                                                    }
                                                }

                                            LEAVE_FOR_1:

                                                idx += CtiProtocol.DESTINATION_CALLER_ID_SHIFT;
                                                for (int k = idx; ; k += 2)
                                                {
                                                    switch ((byte)buffer[k])
                                                    {
                                                        case CtiProtocol.CARRIAGE_RETURN:
                                                            {
                                                                e.DestinationCallerId = buffer.Substring(idx, k - idx);
                                                                idx = k - 1;
                                                                goto LEAVE_FOR_2;
                                                            }
                                                        case CtiProtocol.LINE_FEED:
                                                            {
                                                                e.DestinationCallerId = buffer.Substring(idx, k - idx - 1);
                                                                idx = k - 2;
                                                                goto LEAVE_FOR_2;
                                                            }
                                                    }
                                                }

                                            LEAVE_FOR_2:

                                                idx += CtiProtocol.CALL_START_DATE_SHIFT;
                                                int limit = idx + CtiProtocol.CALL_START_DATE_VALU_LEN;
                                                e.CallStartDate = buffer.Substring(idx, limit - idx);

                                                idx = limit + CtiProtocol.TIMESTAMP_SHIFT;
                                                limit = idx + CtiProtocol.TIMESTAMP_VALU_LEN;
                                                e.Timestamp = buffer.Substring(idx, limit - idx);

                                                observer.OnNext(e);

                                                string cleanUpBuffer = buffer.Remove(0, i + 3);
                                                buffer = cleanUpBuffer;
                                                goto FIND_NEXT_DELIMITER;
                                            }
                                        case CtiProtocol.R:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        case CtiProtocol.D:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        case CtiProtocol.H:
                                            {
                                                switch ((byte)buffer[CtiProtocol.SHIFT_FOR_EVENT_TYPE + 1])
                                                {
                                                    case CtiProtocol.a:
                                                        {
                                                            throw new NotImplementedException();
                                                        }
                                                    case CtiProtocol.o:
                                                        {
                                                            throw new NotImplementedException();
                                                        }
                                                }

                                                throw new Exception("todo: create message...");
                                            }
                                        case CtiProtocol.L:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        case CtiProtocol.P:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        case CtiProtocol.U:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        case CtiProtocol.S:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        default:
                                            {
                                                throw new Exception("todo: create message...");
                                            }
                                    }
                                }
                                else if (buffer[i - CtiProtocol.SHIFT_FOR_DELIMITER] == CtiProtocol.LINE_FEED)
                                {
                                    foundDelimiter = true;
                                    switch ((byte)buffer[CtiProtocol.SHIFT_FOR_EVENT_TYPE])
                                    {
                                        case CtiProtocol.T:
                                            {
                                                TryingEvent e = new TryingEvent();

                                                e.SessionId = buffer.Substring(CtiProtocol.SESSION_ID_IDX_SHIFT, CtiProtocol.SESSION_ID_VALU_LEN);

                                                int idx = CtiProtocol.SOURCE_CALLER_ID_IDX_SHIFT;
                                                for (int k = idx; ; k += 2)
                                                {
                                                    switch ((byte)buffer[k])
                                                    {
                                                        case CtiProtocol.CARRIAGE_RETURN:
                                                            {
                                                                e.SourceCallerId = buffer.Substring(idx, k - idx);
                                                                idx = k - 1;
                                                                goto LEAVE_FOR_1;
                                                            }
                                                        case CtiProtocol.LINE_FEED:
                                                            {
                                                                e.SourceCallerId = buffer.Substring(idx, k - idx - 1);
                                                                idx = k - 2;
                                                                goto LEAVE_FOR_1;
                                                            }
                                                    }
                                                }

                                            LEAVE_FOR_1:

                                                idx += CtiProtocol.DESTINATION_CALLER_ID_SHIFT;
                                                for (int k = idx; ; k += 2)
                                                {
                                                    switch ((byte)buffer[k])
                                                    {
                                                        case CtiProtocol.CARRIAGE_RETURN:
                                                            {
                                                                e.DestinationCallerId = buffer.Substring(idx, k - idx);
                                                                idx = k - 1;
                                                                goto LEAVE_FOR_2;
                                                            }
                                                        case CtiProtocol.LINE_FEED:
                                                            {
                                                                e.DestinationCallerId = buffer.Substring(idx, k - idx - 1);
                                                                idx = k - 2;
                                                                goto LEAVE_FOR_2;
                                                            }
                                                    }
                                                }

                                            LEAVE_FOR_2:

                                                idx += CtiProtocol.CALL_START_DATE_SHIFT;
                                                int limit = idx + CtiProtocol.CALL_START_DATE_VALU_LEN;
                                                e.CallStartDate = buffer.Substring(idx, limit - idx);

                                                idx = limit + CtiProtocol.TIMESTAMP_SHIFT;
                                                limit = idx + CtiProtocol.TIMESTAMP_VALU_LEN;
                                                e.Timestamp = buffer.Substring(idx, limit - idx);

                                                observer.OnNext(e);

                                                string cleanUpBuffer = buffer.Remove(0, i + 1);
                                                buffer = cleanUpBuffer;
                                                goto FIND_NEXT_DELIMITER;
                                            }
                                        case CtiProtocol.R:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        case CtiProtocol.D:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        case CtiProtocol.H:
                                            {
                                                switch ((byte)buffer[CtiProtocol.SHIFT_FOR_EVENT_TYPE + 1])
                                                {
                                                    case CtiProtocol.a:
                                                        {
                                                            throw new NotImplementedException();
                                                        }
                                                    case CtiProtocol.o:
                                                        {
                                                            throw new NotImplementedException();
                                                        }
                                                }

                                                throw new Exception("todo: create message...");
                                            }
                                        case CtiProtocol.L:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        case CtiProtocol.P:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        case CtiProtocol.U:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        case CtiProtocol.S:
                                            {
                                                throw new NotImplementedException();
                                            }
                                        default:
                                            {
                                                throw new Exception("todo: create message...");
                                            }
                                    }
                                }
                                break;
                            }
                    }
                }
            FIND_NEXT_DELIMITER:;
            } while (foundDelimiter);
        }

        public void OnError(Exception error)
        {
            string cleanUpBuffer = buffer.Remove(0, buffer.Length);
            buffer = cleanUpBuffer;
            observer.OnError(error);
        }

        public void OnCompleted()
        {
            string cleanUpBuffer = buffer.Remove(0, buffer.Length);
            buffer = cleanUpBuffer;
            observer.OnCompleted();
        }

        public IDisposable Subscribe(IObserver<CtiEvent> observer)
        {
            this.observer = observer;
            return Disposable.Empty;
        }
    }
}
