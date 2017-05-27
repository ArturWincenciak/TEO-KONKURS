using System;
using System.Text.RegularExpressions;
using Common;

namespace v_0_9
{
    public class CtiParser : ICtiParser
    {
        public CtiEvent Parse(string input)
        {
            switch (input[CtiProtocol.SHIFT_FOR_EVENT_TYPE])
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
                        switch (input[CtiProtocol.SHIFT_FOR_EVENT_TYPE + 1])
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

            int idx = CtiProtocol.FIRST_TRYING_LINE_LEN + CtiProtocol.SESSION_ID_PROP_LEN + CtiProtocol.COLON_AND_SPACE_LEN;
            int limit = idx + CtiProtocol.SESSION_ID_VALU_LEN;
            e.SessionId = input.Substring(idx, CtiProtocol.SESSION_ID_VALU_LEN);

            idx = limit + CtiProtocol.END_LINE_LEN + CtiProtocol.SOURCE_CALLER_ID_PROP_LEN + CtiProtocol.COLON_AND_SPACE_LEN;
            for (int i = idx; ; i++)
            {
                if (input[i + 1] == CtiProtocol.CARRIAGE_RETURN && input[i + 2] == CtiProtocol.LINE_FEED)
                {
                    e.SourceCallerId = input.Substring(idx, i - idx + 1);
                    idx = i;
                    break;
                }
            }

            idx += CtiProtocol.END_LINE_LEN + CtiProtocol.DESTINATION_CALLER_ID_PROP_LEN + CtiProtocol.COLON_AND_SPACE_LEN + 1;
            for (int i = idx; ; i++)
            {
                if (input[i + 1] == CtiProtocol.CARRIAGE_RETURN && input[i + 2] == CtiProtocol.LINE_FEED)
                {
                    e.DestinationCallerId = input.Substring(idx, i - idx + 1);
                    idx = i;
                    break;
                }
            }

            idx += CtiProtocol.END_LINE_LEN + CtiProtocol.CALL_START_DATE_PROP_LEN + CtiProtocol.COLON_AND_SPACE_LEN + 1;
            limit = idx + CtiProtocol.CALL_START_DATE_VALU_LEN;
            e.CallStartDate = input.Substring(idx, limit - idx);

            idx = limit + CtiProtocol.END_LINE_LEN + CtiProtocol.TIMESTAMP_PROP_LEN + CtiProtocol.COLON_AND_SPACE_LEN;
            limit = idx + CtiProtocol.TIMESTAMP_VALU_LEN;
            e.Timestamp = input.Substring(idx, limit - idx);

            return e;
        }
    }
}
