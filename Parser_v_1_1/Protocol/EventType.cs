namespace v_1_1.Protocol
{
    public static class EventType
    {
        public const byte TRYING = Asci.T;
        public const byte RINGING = Asci.R;
        public const byte DIAL = Asci.D;
        public const byte HUNGUP_OR_HOLD = Asci.H;
        public const byte HANGUP = Asci.a;
        public const byte HOLD = Asci.o;
        public const byte LINK = Asci.L;
        public const byte PEER_STATUS = Asci.P;
        public const byte UNLINK = Asci.U;
        public const byte SESSION_CLOSE = Asci.S;
    }
}
