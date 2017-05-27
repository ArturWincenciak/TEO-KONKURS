namespace Common
{
    public class HangupEvent : CtiEvent
    {
        public string Channel { get; set; }
        public string CallerId { get; set; }
        public string Cause { get; set; }
        public string CauseTxt { get; set; }
        public string SoftHangupSrc { get; set; }
        public string SoftHangupDest { get; set; }
    }
}