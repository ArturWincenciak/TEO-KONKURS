namespace v_0_6
{
    public static class CtiProtocol
    {
        public const string DELIMITER = "\r\n\r\n";
        public const string ENDL = "\r\n";

        public const int CARRIAGE_RETURN = 13;
        public const int LINE_FEED = 10;

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
        }

        public const int FIRST_TRYING_LINE_LEN = 15;
        public const int END_LINE_LEN = 2;
        public const int COLON_AND_SPACE_LEN = 2;
        public const int SESSION_ID_PROP_LEN = 9;
        public const int SESSION_ID_VALU_LEN = 22;
        public const int CALL_START_DATE_PROP_LEN = 13;
        public const int CALL_START_DATE_VALU_LEN = 23;
        public const int TIMESTAMP_PROP_LEN = 9;
        public const int TIMESTAMP_VALU_LEN = 13;
        public const int SOURCE_CALLER_ID_PROP_LEN = 14;
        public const int DESTINATION_CALLER_ID_PROP_LEN = 19;
        public const int ACTION_ID_PROP_LEN = 8;
        public const int SOURCE_PROP_LEN = 6;
        public const int DESTINATION_PROP_LEN = 11;
        public const int STATUS_PROP_LEN = 6;
    }
}
