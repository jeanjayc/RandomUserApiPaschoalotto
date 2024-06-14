using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RandomUserApiPasc.Application.Interface;
using RandomUserApiPasc.Domain.Models;
using RandomUserApiPasc.Infra.DTO;
using RandomUserApiPasc.Infra.Interfaces;
using RestSharp;

namespace RandomUserApiPasc.Application.Services
{
    public class UserRandomService : IUserRandomService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRandomRepository _userRepository;
        private readonly IUserRandomDAO _userRandomDAO;

        public UserRandomService(IConfiguration configuration, IUserRandomRepository userRepository, IUserRandomDAO userRandomDAO)
        {
            _configuration = configuration;
            _userRepository = userRepository;
            _userRandomDAO = userRandomDAO;
        }

        public async Task<Results> GenerateNewUser()
        {
            var baseUrl = _configuration.GetSection("BaseUrl").Value;

            var client = new RestClient(baseUrl);
            var request = new RestRequest(baseUrl, Method.Get);

            var response = await client.ExecuteAsync(request);

            var result = JsonConvert.DeserializeObject<Results>(response.Content);

            await _userRepository.AddNewRandomUser(response.Content);

            return result;
        }

        public async Task<IEnumerable<UserDataDTO>> GetAllUsers()
        {
            return await _userRandomDAO.GetAllUsers();
        }
    }
}
