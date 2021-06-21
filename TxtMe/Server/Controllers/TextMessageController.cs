using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using TxtMe.Server.Hubs;
using TxtMe.Shared;

namespace TxtMe.Server.Controllers
{
    [ApiController]
    public class TextMessageController : ControllerBase
    {
        readonly IHubContext<TextMessageReceivedHub> hubContext;

        public TextMessageController(IHubContext<TextMessageReceivedHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        [HttpPost("[Controller]")]
        public async Task<IActionResult> Index([FromBody]TextMessageModel model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }
            
            await hubContext.Clients.All.SendAsync("TextMessageReceived", model.From, model.To, model.Message);

            return Ok();
        }
    }
}
