using api.sparrow.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace api.sparrow.Controllers
{
    [Route("public/[controller]")]
    [ApiController]
    public class PublicController : Controller
    {
        private readonly IHubContext<MessageHub, ISendMessage> _hubContext;
        public PublicController(IHubContext<MessageHub, ISendMessage> hubContext) {
            _hubContext = hubContext;
        }



        [HttpGet]
        [Route("/publictest")]
        public async Task<IActionResult> publicTest() {
            return Ok(_hubContext);
        }

        
    }
}
