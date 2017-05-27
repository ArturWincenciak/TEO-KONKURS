using System;
using System.Text.RegularExpressions;
using Common;

namespace v_0_1
{
    public class CtiParser : ICtiParser
    {
        public CtiEvent Parse(string input)
        {
            DialEvent dialEvent;
            if (TryParse(input, out dialEvent))
            {
                return dialEvent;
            }

            RingingEvent ringingEvent;
            if (TryParse(input, out ringingEvent))
            {
                return ringingEvent;
            }

            HangupEvent hangupEvent;
            if (TryParse(input, out hangupEvent))
            {
                return hangupEvent;
            }

            HoldEvent holdEvent;
            if (TryParse(input, out holdEvent))
            {
                return holdEvent;
            }

            LinkEvent linkEvent;
            if (TryParse(input, out linkEvent))
            {
                return linkEvent;
            }

            UnLinkEvent unLinkEvent;
            if (TryParse(input, out unLinkEvent))
            {
                return unLinkEvent;
            }

            PeerStatusEvent peerStatusEvent;
            if (TryParse(input, out peerStatusEvent))
            {
                return peerStatusEvent;
            }

            SessionCloseEvent sessionCloseEvent;
            if (TryParse(input, out sessionCloseEvent))
            {
                return sessionCloseEvent;
            }

            TryingEvent tryingEvent;
            if (TryParse(input, out tryingEvent))
            {
                return tryingEvent;
            }

            throw new Exception("todo: create message...");
        }

        private static bool TryParse(string input, out TryingEvent e)
        {
            e = null;
            if (Regex.IsMatch(input, $@"\A{CtiProtocol.PropertyType.EVENT}: {CtiProtocol.EventType.TRAYING}"))
            {
                e = new TryingEvent
                {
                    SessionId = Parse(input, CtiProtocol.PropertyType.SESSION_ID),
                    Timestamp = Parse(input, CtiProtocol.PropertyType.TIMESTAMP),
                    CallStartDate = Parse(input, CtiProtocol.PropertyType.CALL_START_DATE),
                    SourceCallerId = Parse(input, CtiProtocol.PropertyType.SOURCE_CALLER_ID),
                    DestinationCallerId = Parse(input, CtiProtocol.PropertyType.DESTINATION_CALLER_ID)
                };
                return true;
            }

            return false;
        }

        private static bool TryParse(string input, out RingingEvent e)
        {
            e = null;
            if (Regex.IsMatch(input, $@"\A{CtiProtocol.PropertyType.EVENT}: {CtiProtocol.EventType.RINGING}"))
            {
                e = new RingingEvent
                {
                    SessionId = Parse(input, CtiProtocol.PropertyType.SESSION_ID),
                    Timestamp = Parse(input, CtiProtocol.PropertyType.TIMESTAMP),
                    SourceCallerId = Parse(input, CtiProtocol.PropertyType.SOURCE_CALLER_ID),
                    DestinationCallerId = Parse(input, CtiProtocol.PropertyType.DESTINATION_CALLER_ID)
                };
                return true;
            }

            return false;
        }

        private static bool TryParse(string input, out DialEvent e)
        {
            e = null;
            if (Regex.IsMatch(input, $@"\A{CtiProtocol.PropertyType.EVENT}: {CtiProtocol.EventType.DIAL}"))
            {
                e = new DialEvent
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
                return true;
            }

            return false;
        }

        private static bool TryParse(string input, out HangupEvent e)
        {
            e = null;
            if (Regex.IsMatch(input, $@"\A{CtiProtocol.PropertyType.EVENT}: {CtiProtocol.EventType.HANGUP}"))
            {
                e = new HangupEvent
                {
                    SessionId = Parse(input, CtiProtocol.PropertyType.SESSION_ID),
                    Timestamp = Parse(input, CtiProtocol.PropertyType.TIMESTAMP),
                    Channel = Parse(input, CtiProtocol.PropertyType.CHANNEL),
                    CallerId = Parse(input, CtiProtocol.PropertyType.CALLER_ID),
                    Cause = Parse(input, CtiProtocol.PropertyType.CAUSE),
                    CauseTxt = Parse(input, CtiProtocol.PropertyType.CAUSE_TXT),
                    SoftHangupSrc = Parse(input, CtiProtocol.PropertyType.SOFT_HANGUP_SRC),
                    SoftHangupDest = Parse(input, CtiProtocol.PropertyType.SOFT_HANGUP_DEST),
                };
                return true;
            }

            return false;
        }

        private static bool TryParse(string input, out HoldEvent e)
        {
            e = null;
            if (Regex.IsMatch(input, $@"\A{CtiProtocol.PropertyType.EVENT}: {CtiProtocol.EventType.HOLD}"))
            {
                e = new HoldEvent
                {
                    SessionId = Parse(input, CtiProtocol.PropertyType.SESSION_ID),
                    Timestamp = Parse(input, CtiProtocol.PropertyType.TIMESTAMP),
                    Channel = Parse(input, CtiProtocol.PropertyType.CHANNEL),
                    Status = Parse(input, CtiProtocol.PropertyType.STATUS)
                };
                return true;
            }

            return false;
        }

        private static bool TryParse(string input, out LinkEvent e)
        {
            e = null;
            if (Regex.IsMatch(input, $@"\A{CtiProtocol.PropertyType.EVENT}: {CtiProtocol.EventType.LINK}"))
            {
                e = new LinkEvent
                {
                    SessionId = Parse(input, CtiProtocol.PropertyType.SESSION_ID),
                    Timestamp = Parse(input, CtiProtocol.PropertyType.TIMESTAMP),
                    Source = Parse(input, CtiProtocol.PropertyType.SOURCE),
                    Destination = Parse(input, CtiProtocol.PropertyType.DESTINATION),
                    SourceCallerId = Parse(input, CtiProtocol.PropertyType.SOURCE_CALLER_ID),
                    DestinationCallerId = Parse(input, CtiProtocol.PropertyType.DESTINATION_CALLER_ID),
                };
                return true;
            }

            return false;
        }

        private static bool TryParse(string input, out PeerStatusEvent e)
        {
            e = null;
            if (Regex.IsMatch(input, $@"\A{CtiProtocol.PropertyType.EVENT}: {CtiProtocol.EventType.PEER_STATUS}"))
            {
                e = new PeerStatusEvent
                {
                    SessionId = Parse(input, CtiProtocol.PropertyType.SESSION_ID),
                    Timestamp = Parse(input, CtiProtocol.PropertyType.TIMESTAMP),
                    Peer = Parse(input, CtiProtocol.PropertyType.PEER),
                    PeerStatus = Parse(input, CtiProtocol.PropertyType.PEER_STATUS),
                };
                return true;
            }

            return false;
        }

        private static bool TryParse(string input, out UnLinkEvent e)
        {
            e = null;
            if (Regex.IsMatch(input, $@"\A{CtiProtocol.PropertyType.EVENT}: {CtiProtocol.EventType.UN_LINK}"))
            {
                e = new UnLinkEvent
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
                return true;
            }

            return false;
        }

        private static bool TryParse(string input, out SessionCloseEvent e)
        {
            e = null;
            if (Regex.IsMatch(input, $@"\A{CtiProtocol.PropertyType.EVENT}: {CtiProtocol.EventType.SESSION_CLOSE}"))
            {
                e = new SessionCloseEvent
                {
                    SessionId = Parse(input, CtiProtocol.PropertyType.SESSION_ID),
                    Timestamp = Parse(input, CtiProtocol.PropertyType.TIMESTAMP)
                };
                return true;
            }

            return false;
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
