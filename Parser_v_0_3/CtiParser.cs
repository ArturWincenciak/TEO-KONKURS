using System;
using System.Text.RegularExpressions;
using Common;

namespace v_0_3
{
    public class CtiParser : ICtiParser
    {
        public CtiEvent Parse(string input)
        {
            int endOfFirstLineIndex = input.IndexOf(CtiProtocol.ENDL, StringComparison.Ordinal);
            string firstLine = input.Substring(0, endOfFirstLineIndex);

            switch (firstLine)
            {
                case CtiProtocol.PropertyType.EVENT + ": " + CtiProtocol.EventType.DIAL:
                    {
                        return new DialEvent
                        {
                            ActionId = Parse(input, CtiProtocol.PropertyType.ACTION_ID),
                            SessionId = Parse(input, CtiProtocol.PropertyType.SESSION_ID),
                            Timestamp = Parse(input, CtiProtocol.PropertyType.TIMESTAMP),
                            Source = Parse(input, CtiProtocol.PropertyType.SOURCE),
                            Destination = Parse(input, CtiProtocol.PropertyType.DESTINATION),
                            SourceCallerId = Parse(input, CtiProtocol.PropertyType.SOURCE_CALLER_ID),
                            DestinationCallerId = Parse(input, CtiProtocol.PropertyType.DESTINATION_CALLER_ID),
                            Status = Parse(input, CtiProtocol.PropertyType.STATUS)
                        };
                    }

                case CtiProtocol.PropertyType.EVENT + ": " + CtiProtocol.EventType.RINGING:
                    {
                        return new RingingEvent
                        {
                            SessionId = Parse(input, CtiProtocol.PropertyType.SESSION_ID),
                            Timestamp = Parse(input, CtiProtocol.PropertyType.TIMESTAMP),
                            SourceCallerId = Parse(input, CtiProtocol.PropertyType.SOURCE_CALLER_ID),
                            DestinationCallerId = Parse(input, CtiProtocol.PropertyType.DESTINATION_CALLER_ID)
                        };
                    }

                case CtiProtocol.PropertyType.EVENT + ": " + CtiProtocol.EventType.HANGUP:
                    {
                        return new HangupEvent
                        {
                            SessionId = Parse(input, CtiProtocol.PropertyType.SESSION_ID),
                            Timestamp = Parse(input, CtiProtocol.PropertyType.TIMESTAMP),
                            Channel = Parse(input, CtiProtocol.PropertyType.CHANNEL),
                            CallerId = Parse(input, CtiProtocol.PropertyType.CALLER_ID),
                            Cause = Parse(input, CtiProtocol.PropertyType.CAUSE),
                            CauseTxt = Parse(input, CtiProtocol.PropertyType.CAUSE_TXT),
                            SoftHangupSrc = Parse(input, CtiProtocol.PropertyType.SOFT_HANGUP_SRC),
                            SoftHangupDest = Parse(input, CtiProtocol.PropertyType.SOFT_HANGUP_DEST),
                        }; ;
                    }

                case CtiProtocol.PropertyType.EVENT + ": " + CtiProtocol.EventType.HOLD:
                    {
                        return new HoldEvent
                        {
                            SessionId = Parse(input, CtiProtocol.PropertyType.SESSION_ID),
                            Timestamp = Parse(input, CtiProtocol.PropertyType.TIMESTAMP),
                            Channel = Parse(input, CtiProtocol.PropertyType.CHANNEL),
                            Status = Parse(input, CtiProtocol.PropertyType.STATUS)
                        }; ;
                    }

                case CtiProtocol.PropertyType.EVENT + ": " + CtiProtocol.EventType.LINK:
                    {
                        return new LinkEvent
                        {
                            SessionId = Parse(input, CtiProtocol.PropertyType.SESSION_ID),
                            Timestamp = Parse(input, CtiProtocol.PropertyType.TIMESTAMP),
                            Source = Parse(input, CtiProtocol.PropertyType.SOURCE),
                            Destination = Parse(input, CtiProtocol.PropertyType.DESTINATION),
                            SourceCallerId = Parse(input, CtiProtocol.PropertyType.SOURCE_CALLER_ID),
                            DestinationCallerId = Parse(input, CtiProtocol.PropertyType.DESTINATION_CALLER_ID),
                        };
                    }

                case CtiProtocol.PropertyType.EVENT + ": " + CtiProtocol.EventType.UN_LINK:
                    {
                        return new UnLinkEvent
                        {
                            SessionId = Parse(input, CtiProtocol.PropertyType.SESSION_ID),
                            Timestamp = Parse(input, CtiProtocol.PropertyType.TIMESTAMP),
                            SoftHangupSrc = Parse(input, CtiProtocol.PropertyType.SOFT_HANGUP_SRC),
                            SoftHangupDest = Parse(input, CtiProtocol.PropertyType.SOFT_HANGUP_DEST),
                            Source = Parse(input, CtiProtocol.PropertyType.SOURCE),
                            Destination = Parse(input, CtiProtocol.PropertyType.DESTINATION),
                            SourceCallerId = Parse(input, CtiProtocol.PropertyType.SOURCE_CALLER_ID),
                            DestinationCallerId = Parse(input, CtiProtocol.PropertyType.DESTINATION_CALLER_ID)
                        };
                    }

                case CtiProtocol.PropertyType.EVENT + ": " + CtiProtocol.EventType.PEER_STATUS:
                    {
                        return new PeerStatusEvent
                        {
                            SessionId = Parse(input, CtiProtocol.PropertyType.SESSION_ID),
                            Timestamp = Parse(input, CtiProtocol.PropertyType.TIMESTAMP),
                            Peer = Parse(input, CtiProtocol.PropertyType.PEER),
                            PeerStatus = Parse(input, CtiProtocol.PropertyType.PEER_STATUS),
                        };
                    }

                case CtiProtocol.PropertyType.EVENT + ": " + CtiProtocol.EventType.SESSION_CLOSE:
                    {
                        return new SessionCloseEvent
                        {
                            SessionId = Parse(input, CtiProtocol.PropertyType.SESSION_ID),
                            Timestamp = Parse(input, CtiProtocol.PropertyType.TIMESTAMP)
                        }; ;
                    }

                case CtiProtocol.PropertyType.EVENT + ": " + CtiProtocol.EventType.TRAYING:
                    {
                        return new TryingEvent
                        {
                            SessionId = Parse(input, CtiProtocol.PropertyType.SESSION_ID),
                            Timestamp = Parse(input, CtiProtocol.PropertyType.TIMESTAMP),
                            CallStartDate = Parse(input, CtiProtocol.PropertyType.CALL_START_DATE),
                            SourceCallerId = Parse(input, CtiProtocol.PropertyType.SOURCE_CALLER_ID),
                            DestinationCallerId = Parse(input, CtiProtocol.PropertyType.DESTINATION_CALLER_ID)
                        };
                    }
            }

            throw new Exception("todo: create message...");
        }

        private static string Parse(string input, string valueType)
        {
            int firstIndexOfType = input.IndexOf(valueType + ":", StringComparison.Ordinal);
            if (firstIndexOfType == -1)
            {
                return string.Empty;
            }

            int lastIndexOfType = firstIndexOfType + valueType.Length;
            int firstIndexOfValue = lastIndexOfType + 2;
            int lastIndexOfValue = input.IndexOf(value: '\r', startIndex: firstIndexOfValue);
            int lengthOfValue = lastIndexOfValue - firstIndexOfValue;
            string result = input.Substring(firstIndexOfValue, lengthOfValue);
            return result;
        }
    }
}
