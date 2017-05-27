namespace Common
{
    public class RingingEvent : CtiEvent
    {
        public string SourceCallerId { get; set; }
        public string DestinationCallerId { get; set; }
    }
}