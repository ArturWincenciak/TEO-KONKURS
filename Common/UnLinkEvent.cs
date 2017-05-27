namespace Common
{
    public class UnLinkEvent : CtiEvent
    {
        public string SoftHangupSrc { get; set; }
        public string SoftHangupDest { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string SourceCallerId { get; set; }
        public string DestinationCallerId { get; set; }
    }
}
