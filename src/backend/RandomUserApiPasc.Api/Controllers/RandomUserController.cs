using Microsoft.AspNetCore.Mvc;
using RandomUserApiPasc.Application.Interface;
using RandomUserApiPasc.Infra.DTO.Request;

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
                return StatusCode(500, "Ocorreu um erro no servidor");
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
                return StatusCode(500, "Ocorreu um erro no servidor");
                throw;
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit(long id, UserRandomEditDTO user)
        {
            try
            {
                if (id <= 0) return BadRequest("Id não pode ser igual ou menor que 0");

                var userExist = await _randomService.GetUserById(id);

                if (userExist.Id <= 0) return NotFound();

                await _randomService.EditUser(id, user, userExist);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro no servidor");
                throw;
            }
        }
    }
}
