using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RandomUserApiPasc.Application.Interface;
using RandomUserApiPasc.Domain.Models;
using RestSharp;

namespace RandomUserApiPasc.Application.Services
{
    public class UserRandomService : IUserRandomService
    {
        private readonly IConfiguration _configuration;

        public UserRandomService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<Results> GerarNovosUsuarios()
        {
            var baseUrl = _configuration.GetSection("BaseUrl").Value;

            var client = new RestClient(baseUrl);
            var request = new RestRequest(baseUrl, Method.Get);

            var response = await client.ExecuteAsync(request);

            var result = JsonConvert.DeserializeObject<Results>(response.Content);

            return result;
        }
    }
}
