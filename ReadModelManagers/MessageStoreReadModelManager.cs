using System.Threading.Tasks;
using JasperWebApi.Events;
using Microsoft.Extensions.Logging;

namespace JasperWebApi.ReadModelManagers
{
    public class MessageStoreReadModelManager
    {
        private readonly ILogger _log;

        public MessageStoreReadModelManager(ILogger<MessageStoreReadModelManager> log)
        {
            _log = log;
        }

        public Task Handle(MessageStoredEvent evt)
        {
            // Process the subscribed message - save to lightweight read model
            _log.LogDebug($"******* MessageStoreReadModelManager - EvtMsg: [{evt.EvtMsg}]");

            return Task.CompletedTask;
        }
    }
}
