namespace RandomUserApiPasc.Infra.Interfaces
{
    public interface IUserRandomRepository
    {
        Task AddNewRandomUser(string json);
    }
}
