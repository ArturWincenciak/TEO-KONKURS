namespace Common
{
    public class TryingEvent : CtiEvent
    {
        public string SourceCallerId { get; set; }
        public string DestinationCallerId { get; set; }
        public string CallStartDate { get; set; }
    }
}