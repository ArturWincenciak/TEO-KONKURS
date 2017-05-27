namespace Common
{
    public class LinkEvent : CtiEvent
    {
        public string Source { get; set; }
        public string Destination { get; set; }
        public string SourceCallerId { get; set; }
        public string DestinationCallerId { get; set; }
    }
}