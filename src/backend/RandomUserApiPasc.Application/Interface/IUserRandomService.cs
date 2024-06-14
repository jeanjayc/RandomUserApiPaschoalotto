using RandomUserApiPasc.Domain.Models;

namespace RandomUserApiPasc.Application.Interface
{
    public interface IUserRandomService
    {
        Task<Results> GenerateNewUser();
    }
}
