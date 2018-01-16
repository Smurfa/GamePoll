using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamePoll.Core.Models;
using GamePoll.Core.Repositories.Entities;
using Microsoft.AspNetCore.Mvc;
using GamePoll.Core.Services.GameData;
using Microsoft.AspNetCore.Http;

namespace GamePoll.Api.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private readonly IGameService _service;

        public GamesController(IGameService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult>Get()
        {
            var games = await _service.GetGamesAsync();
            if (games == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var game = await _service.GetGameAsync(id);
            if (game == null)
            {
                return NotFound(id);
            }
            return Ok(game);
        }

        [HttpPost]
        public async Task<IActionResult>Post([FromBody]GameModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(await _service.AddGameAsync(value));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]GameModel value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(await _service.UpdateGameAsync(value));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }
            if (await _service.DeleteGameAsync(id))
            {
                return Ok();
            }
            return NotFound(id);
        }
    }
}
