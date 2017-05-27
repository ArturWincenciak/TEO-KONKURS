namespace v_4_2.Protocol
{
    public static class Shift
    {
        public const int END_LINE = 2;
        public const int COLON_AND_SPACE = 2;
        public const int EVENT_TYPE = 7;
        public const int END_OF_FIRST_LINE = 15;
        public const int SESSION_ID_PROP = 9;
        public const int SESSION_ID_VALU = 22;
        public const int CALL_START_DATE_PROP = 13;
        public const int CALL_START_DATE_VALU = 23;
        public const int TIMESTAMP_PROP = 9;
        public const int TIMESTAMP_VALU = 13;
        public const int SOURCE_CALLER_ID_PROP = 14;
        public const int DESTINATION_CALLER_ID_PROP = 19;
        public const int ACTION_ID_PROP = 8;
        public const int SOURCE_PROP = 6;
        public const int DESTINATION_PROP = 11;
        public const int STATUS_PROP = 6;

        public static class Trying
        {
            public const int SESSION_ID_IDX_SHIFT = END_OF_FIRST_LINE + SESSION_ID_PROP + COLON_AND_SPACE;
            public const int SESSION_ID_LAST_IDX_SHIFT = SESSION_ID_IDX_SHIFT + SESSION_ID_VALU;
            public const int SOURCE_CALLER_ID_IDX_SHIFT = SESSION_ID_LAST_IDX_SHIFT + END_LINE + SOURCE_CALLER_ID_PROP + COLON_AND_SPACE;
            public const int DESTINATION_CALLER_ID_SHIFT = END_LINE + DESTINATION_CALLER_ID_PROP + COLON_AND_SPACE + 1;
            public const int CALL_START_DATE_SHIFT = END_LINE + CALL_START_DATE_PROP + COLON_AND_SPACE + 1;
            public const int TIMESTAMP_SHIFT = END_LINE + TIMESTAMP_PROP + COLON_AND_SPACE;
        }
    }
}
