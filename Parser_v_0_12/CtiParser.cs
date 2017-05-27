using System;
using Common;

namespace v_0_12
{
    public class CtiParser : ICtiParser
    {
        public CtiEvent Parse(string input)
        {
            switch ((byte)input[CtiProtocol.SHIFT_FOR_EVENT_TYPE])
            {
                case CtiProtocol.T:
                    {
                        return ParseTryingEvent(input);
                    }
                case CtiProtocol.R:
                    {
                        return ParseRingingEvent(input);
                    }
                case CtiProtocol.D:
                    {
                        return ParseDialEvent(input);
                    }
                case CtiProtocol.H:
                    {
                        switch ((byte)input[CtiProtocol.SHIFT_FOR_EVENT_TYPE + 1])
                        {
                            case CtiProtocol.a:
                                {
                                    return ParseHangupEvent(input);
                                }
                            case CtiProtocol.o:
                                {
                                    return ParseHoldEvent(input);
                                }
                        }

                        throw new Exception("todo: create message...");
                    }
                case CtiProtocol.L:
                    {
                        return ParseLinkEvent(input);
                    }
                case CtiProtocol.P:
                    {
                        return ParsePeerStatusEvent(input);
                    }
                case CtiProtocol.U:
                    {
                        return ParseUnLinkEvent(input);
                    }
                case CtiProtocol.S:
                    {
                        return ParseSessionCloseEvent(input);
                    }
            }

            throw new Exception("todo: create message...");
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

        private CtiEvent ParseTryingEvent(string input)
        {
            TryingEvent e = new TryingEvent();

            e.SessionId = input.Substring(CtiProtocol.SESSION_ID_IDX_SHIFT, CtiProtocol.SESSION_ID_VALU_LEN);

            int idx = WithEndLineFound(CtiProtocol.SOURCE_CALLER_ID_IDX_SHIFT, input, value => e.SourceCallerId = value);
            idx = WithEndLineFound(idx += CtiProtocol.DESTINATION_CALLER_ID_SHIFT, input, value => e.DestinationCallerId = value);
           
            idx += CtiProtocol.CALL_START_DATE_SHIFT;
            int limit = idx + CtiProtocol.CALL_START_DATE_VALU_LEN;
            e.CallStartDate = input.Substring(idx, limit - idx);

            idx = limit + CtiProtocol.TIMESTAMP_SHIFT;
            limit = idx + CtiProtocol.TIMESTAMP_VALU_LEN;
            e.Timestamp = input.Substring(idx, limit - idx);

            return e;
        }

        private static int WithEndLineFound(int idx, string input, Action<string> onFoundPropertyValue)
        {
            for (int i = idx; ; i += 2)
            {
                switch ((byte)input[i])
                {
                    case CtiProtocol.CARRIAGE_RETURN:
                        {
                            onFoundPropertyValue(input.Substring(idx, i - idx));
                            idx = i - 1;
                            goto LEAVE_FOR_1;
                        }
                    case CtiProtocol.LINE_FEED:
                        {
                            onFoundPropertyValue(input.Substring(idx, i - idx - 1));
                            idx = i - 2;
                            goto LEAVE_FOR_1;
                        }
                }
            }

        LEAVE_FOR_1:
            return idx;
        }
    }
}
