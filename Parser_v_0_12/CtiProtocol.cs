namespace v_0_12
{
    public static class CtiProtocol
    {
        public const byte T = 84;
        public const byte R = 82;
        public const byte D = 68;
        public const byte H = 72;
        public const byte a = 97;
        public const byte o = 111;
        public const byte L = 76;
        public const byte P = 80;
        public const byte U = 85;
        public const byte S = 83;
        public const byte SHIFT_FOR_EVENT_TYPE = 7;

        public const byte CARRIAGE_RETURN = 13;
        public const byte LINE_FEED = 10;

        public const int SHIFT_FOR_DELIMITER = 2;
    
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

        public const int SESSION_ID_IDX_SHIFT = FIRST_TRYING_LINE_LEN + SESSION_ID_PROP_LEN + COLON_AND_SPACE_LEN;
        public const int SESSION_ID_LAST_IDX_SHIFT = SESSION_ID_IDX_SHIFT + SESSION_ID_VALU_LEN;
        public const int SOURCE_CALLER_ID_IDX_SHIFT = SESSION_ID_LAST_IDX_SHIFT + END_LINE_LEN + SOURCE_CALLER_ID_PROP_LEN + COLON_AND_SPACE_LEN;
        public const int DESTINATION_CALLER_ID_SHIFT = END_LINE_LEN + DESTINATION_CALLER_ID_PROP_LEN + COLON_AND_SPACE_LEN + 1;
        public const int CALL_START_DATE_SHIFT = END_LINE_LEN + CALL_START_DATE_PROP_LEN + COLON_AND_SPACE_LEN + 1;
        public const int TIMESTAMP_SHIFT = END_LINE_LEN + TIMESTAMP_PROP_LEN + COLON_AND_SPACE_LEN;
    }
}
