using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wordle.Api.Data;
using Wordle.Api.Services;

namespace Wordle.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerService _service;
        public PlayerController(PlayerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Player> Get()
        {
            return _service.GetPlayers();

        }

        [HttpPost]
        public IActionResult Post([FromBody] PlayerPost score)
        {
            _service.Update(score.Name, score.Score);
            return Ok();
        }
        public class PlayerPost
        {
            public string? Name { get; set; }
            public int Score { get; set; }
        }
    }
}
