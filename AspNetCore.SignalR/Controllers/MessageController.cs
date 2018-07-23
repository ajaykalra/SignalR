using System;
using AspNetCore.SignalR.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AspNetCore.SignalR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<GeneralHub, IGeneralHubClient> _generalHubContext;

        public MessageController(IHubContext<GeneralHub, IGeneralHubClient> hubContext)
        {
            _generalHubContext = hubContext;
        }
        // GET: api/Message
        [HttpGet]
        public string Get()
        {
            return "Message Controller is running";
        }

        // POST: api/Message
        [HttpPost]
        public string Post([FromBody] Message message)
        {
            string retMessage = string.Empty;

            try
            {
                _generalHubContext.Clients.All.BroadcastMessage(message.MessageType, message.Payload);
                retMessage = "success";
            }
            catch (Exception e)
            {
                retMessage = e.ToString();
            }

            return retMessage;
        }
    }
}
