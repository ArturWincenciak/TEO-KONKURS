namespace v_0_3
{
    public static class CtiProtocol
    {
        public const string DELIMITER = "\r\n\r\n";
        public const string ENDL = "\r\n";

        public static class EventType
        {
            public const string TRAYING = "Trying";
            public const string RINGING = "Ringing";
            public const string DIAL = "Dial";
            public const string HANGUP = "Hangup";
            public const string HOLD = "Hold";
            public const string LINK = "Link";
            public const string PEER_STATUS = "PeerStatus";
            public const string UN_LINK = "UnLink";
            public const string SESSION_CLOSE = "SessionClose";
        }

        public static class PropertyType
        {
            public const string EVENT = "Event";
            public const string SESSION_ID = "SessionID";
            public const string TIMESTAMP = "Timestamp";
            public const string CALL_START_DATE = "CallStartDate";
            public const string SOURCE = "Source";
            public const string DESTINATION = "Destination";
            public const string SOURCE_CALLER_ID = "SourceCallerID";
            public const string DESTINATION_CALLER_ID = "DestinationCallerID";
            public const string STATUS = "Status";
            public const string ACTION_ID = "ActionID";

            public const string SOFT_HANGUP_SRC = "SoftHangupSrc";
            public const string SOFT_HANGUP_DEST = "SoftHangupDest";

            public const string CHANNEL = "Channel";
            public const string CALLER_ID = "CallerID";
            public const string CAUSE = "Cause";
            public const string CAUSE_TXT = "Cause-txt";

            public const string PEER_STATUS = "PeerStatus";
            public const string PEER = "Peer";
        }
    }
}
