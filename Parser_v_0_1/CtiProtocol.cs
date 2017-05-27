namespace v_0_1
{
    public static class CtiProtocol
    {
        public static string DELIMITER = "\r\n\r\n";

        public static class EventType
        {
            public static string TRAYING = "Trying";
            public static string RINGING = "Ringing";
            public static string DIAL = "Dial";
            public static string HANGUP = "Hangup";
            public static string HOLD = "Hold";
            public static string LINK = "Link";
            public static string PEER_STATUS = "PeerStatus";
            public static string UN_LINK = "UnLink";
            public static string SESSION_CLOSE = "SessionClose";
        }

        public static class PropertyType
        {
            public static string EVENT = "Event";
            public static string SESSION_ID = "SessionID";
            public static string TIMESTAMP = "Timestamp";
            public static string CALL_START_DATE = "CallStartDate";
            public static string SOURCE = "Source";
            public static string DESTINATION = "Destination";
            public static string SOURCE_CALLER_ID = "SourceCallerID";
            public static string DESTINATION_CALLER_ID = "DestinationCallerID";
            public static string STATUS = "Status";
            public static string ACTION_ID = "ActionID";

            public static string SOFT_HANGUP_SRC = "SoftHangupSrc";
            public static string SOFT_HANGUP_DEST = "SoftHangupDest";

            public static string CHANNEL = "Channel";
            public static string CALLER_ID = "CallerID";
            public static string CAUSE = "Cause";
            public static string CAUSE_TXT = "Cause-txt";

            public static string PEER_STATUS = "PeerStatus";
            public static string PEER = "Peer";
        }
    }
}
