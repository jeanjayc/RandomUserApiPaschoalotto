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
        public async Task<IActionResult> GenerateRandomUser()
        {
            try
            {
                var result = await _randomService.GenerateNewUser();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRandomUser()
        {
            try
            {
                var result = await _randomService.GetAllUsers();
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit()
        {
            return Ok();
        }
    }
}
