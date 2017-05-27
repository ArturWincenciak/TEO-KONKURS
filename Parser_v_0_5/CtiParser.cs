using System;
using System.Text.RegularExpressions;
using Common;

namespace v_0_5
{
    public class CtiParser : ICtiParser
    {
        public CtiEvent Parse(string input)
        {
            int endOfFirstLineIndex = input.IndexOf(CtiProtocol.ENDL, StringComparison.Ordinal);
            string firstLine = input.Substring(0, endOfFirstLineIndex);

            switch (firstLine)
            {
                case CtiProtocol.PropertyType.EVENT + ": " + CtiProtocol.EventType.TRAYING:
                    {
                        return ParseTryingEvent(input);
                    }
                case CtiProtocol.PropertyType.EVENT + ": " + CtiProtocol.EventType.RINGING:
                    {
                        return ParseRingingEvent(input);
                    }
                case CtiProtocol.PropertyType.EVENT + ": " + CtiProtocol.EventType.DIAL:
                    {
                        return ParseDialEvent(input);
                    }
                case CtiProtocol.PropertyType.EVENT + ": " + CtiProtocol.EventType.HANGUP:
                    {
                        return ParseHangupEvent(input);
                    }
                case CtiProtocol.PropertyType.EVENT + ": " + CtiProtocol.EventType.HOLD:
                    {
                        return ParseHoldEvent(input);
                    }
                case CtiProtocol.PropertyType.EVENT + ": " + CtiProtocol.EventType.LINK:
                    {
                        return ParseLinkEvent(input);
                    }
                case CtiProtocol.PropertyType.EVENT + ": " + CtiProtocol.EventType.PEER_STATUS:
                    {
                        return ParsePeerStatusEvent(input);
                    }
                case CtiProtocol.PropertyType.EVENT + ": " + CtiProtocol.EventType.UN_LINK:
                    {
                        return ParseUnLinkEvent(input);
                    }
                case CtiProtocol.PropertyType.EVENT + ": " + CtiProtocol.EventType.SESSION_CLOSE:
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
