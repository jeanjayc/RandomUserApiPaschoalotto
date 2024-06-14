using RandomUserApiPasc.Domain.Models;
using RandomUserApiPasc.Infra.DTO;

namespace RandomUserApiPasc.Infra.Interfaces
{
    public interface IUserRandomDAO
    {
        Task<UserDataDTO> GetUserById(long id);
        Task<IEnumerable<UserDataDTO>> GetAllUsers();
    }
}
