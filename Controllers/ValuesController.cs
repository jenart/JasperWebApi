using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Jasper.Messaging;
using JasperWebApi.Commands;
using JasperWebApi.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JasperWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IMessageContext _bus;
        private readonly ILogger _log;

        public ValuesController(IMessageContext bus, ILogger<ValuesController> log)
        {
            _bus = bus;
            _log = log;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<string>> GetMessage()
        {
            var sw = Stopwatch.StartNew();
            try
            {
                _log.LogInformation($"Begin GetMessage()...");
                var msg = await _bus.Invoke<string>(new GetMessageQuery());
                sw.Stop();

                return new JsonResult(
                    new
                    {
                        msg,
                        duration = $"{sw.Elapsed.TotalMilliseconds}ms"
                    });
            }
            finally
            {
                _log.LogInformation($"End GetMessage() [{sw.ElapsedMilliseconds}ms]");
            }
            
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<string>> SendMessage()
        {
            var sw = Stopwatch.StartNew();
            try
            {
                _log.LogInformation($"Begin SendMessage()...");
                var now = DateTime.UtcNow;
                await _bus.Send(new SendMessageCommand($"Boo! [{now}]"));
                sw.Stop();

                return new JsonResult(
                    new
                    {
                        msg = now,
                        duration = $"{sw.Elapsed.TotalMilliseconds}ms"
                    });
            }
            finally
            {
                _log.LogInformation($"End SendMessage() [{sw.ElapsedMilliseconds}ms]");
            }
        }


//        // GET api/values/5
//        [HttpGet("{id}")]
//        public ActionResult<string> Get(int id)
//        {
//            return "value";
//        }
//
//        // POST api/values
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//        }
//
//        // PUT api/values/5
//        [HttpPut("{id}")]
//        public void Put(int id, [FromBody] string value)
//        {
//        }
//
//        // DELETE api/values/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
    }
}
