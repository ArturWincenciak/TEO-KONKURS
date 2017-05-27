namespace Common
{
    public class DialEvent : CtiEvent
    {
        public string Source { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public string SourceCallerId { get; set; } = string.Empty;
        public string DestinationCallerId { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string ActionId { get; set; } = string.Empty;
    }
}