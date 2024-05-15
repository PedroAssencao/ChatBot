using Chatbot.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Chatbot.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        protected readonly ChatRepository _chatRepository;

        public ChatController(ChatRepository chatRepository)
        {
            _chatRepository = chatRepository;
        }

        [HttpGet("/chats")]
        public async Task<IActionResult> getAll() => Ok(await _chatRepository.BuscarChatsComObjetos());
    }
}
