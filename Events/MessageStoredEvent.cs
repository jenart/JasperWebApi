
namespace JasperWebApi.Events
{
    public class MessageStoredEvent
    {
        public string EvtMsg { get; }

        public MessageStoredEvent(string evtMsg)
        {
            EvtMsg = evtMsg;
        }
    }
}
