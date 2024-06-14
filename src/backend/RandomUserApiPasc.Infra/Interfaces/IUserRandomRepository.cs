using RandomUserApiPasc.Domain.Models;
using RandomUserApiPasc.Domain.Models.ValueObjects;

namespace RandomUserApiPasc.Infra.Interfaces
{
    public interface IUserRandomRepository
    {
        Task AddNewRandomUser(string json);
    }
}
