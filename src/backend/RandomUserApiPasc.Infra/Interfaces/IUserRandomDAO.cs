using RandomUserApiPasc.Domain.Models;
using RandomUserApiPasc.Infra.DTO;

namespace RandomUserApiPasc.Infra.Interfaces
{
    public interface IUserRandomDAO
    {
        Task<IEnumerable<UserDataDTO>> GetAllUsers();
    }
}
