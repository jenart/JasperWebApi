using System.Threading.Tasks;
using Jasper.Messaging;
using JasperWebApi.Events;
using Microsoft.Extensions.Logging;

namespace JasperWebApi.Commands.CommandHandlers
{
    public class SendMessageCommandHandler
    {
        private readonly IMessageContext _bus;
        private readonly ILogger _log;

        public SendMessageCommandHandler(IMessageContext bus, ILogger<SendMessageCommandHandler> log)
        {
            _bus = bus;
            _log = log;
        }

        public async Task Handle(SendMessageCommand cmd)
        {
            // you would save to the Db here
            _log.LogDebug($"%%%%%%% The message is [{cmd.Msg}]");

            // then raise an event to any interested party
            var evt = new MessageStoredEvent(cmd.Msg);
            await _bus.Enqueue(evt);
        }
    }
}
