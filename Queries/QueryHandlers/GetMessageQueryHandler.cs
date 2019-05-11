using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace JasperWebApi.Queries.QueryHandlers
{
    public class GetMessageQueryHandler
    {
        private readonly ILogger _log;

        public GetMessageQueryHandler(ILogger<GetMessageQueryHandler> log)
        {
            _log = log;
        }

        public Task<string> Handle(GetMessageQuery query)
        {
            _log.LogDebug($"Hello Jasper!! [{DateTime.UtcNow}]");
            return Task.FromResult($"Hello Jasper!! [{DateTime.UtcNow}]");
        }
    }
}
