using RandomUserApiPasc.Domain.Models.ValueObjects;
using RandomUserApiPasc.Infra.DTO;
using RandomUserApiPasc.Infra.DTO.Request;

namespace RandomUserApiPasc.Infra.Interfaces
{
    public interface IUserRandomRepository
    {
        Task AddNewRandomUser(string json);
        Task EditUser(long id, UserRandomEditDTO userEdit, UserDataDTO user);
    }
}
