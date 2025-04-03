using Animeland.Application.Animes.DTOs.GetAnimeById;
using Animeland.Application.Animes.Services;
using Microsoft.AspNetCore.Mvc;

namespace Animeland.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AnimeController : ControllerBase
    {
        private readonly IAnimeService _animeService;

        public AnimeController(IAnimeService animeService)
        {
            this._animeService = animeService;
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType<GetAnimeByIdResponse>(StatusCodes.Status200OK)]
        public IActionResult Get(int id)
        {
            return Ok(_animeService.GetAanimeByIdAsync(new GetAnimeByIdRequest(id)));
        }
    }
}
