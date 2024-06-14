using Microsoft.AspNetCore.Mvc;
using RandomUserApiPasc.Application.Interface;

namespace RandomUserApiPasc.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RandomUserController : ControllerBase
    {
        private readonly IUserRandomService _randomService;

        public RandomUserController(IUserRandomService randomService)
        {
            _randomService = randomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetNewUser()
        {
            var result = await _randomService.GerarNovosUsuarios();
            return Ok(result);
        }
    }
}
