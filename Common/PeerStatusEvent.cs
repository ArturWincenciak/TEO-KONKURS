namespace Common
{
    public class PeerStatusEvent : CtiEvent
    {
        public string Peer { get; set; }
        public string PeerStatus { get; set; }
    }
}