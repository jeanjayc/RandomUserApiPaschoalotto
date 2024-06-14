using RandomUserApiPasc.Domain.Models;
using RandomUserApiPasc.Infra.DTO;
using RandomUserApiPasc.Infra.DTO.Request;

namespace RandomUserApiPasc.Application.Interface
{
    public interface IUserRandomService
    {
        Task<Results> GenerateNewUser();
        Task<IEnumerable<UserDataDTO>> GetAllUsers();
        Task<UserDataDTO> GetUserById(long id);
        Task EditUser(long id, UserRandomEditDTO userEdit, UserDataDTO user);
    }
}
