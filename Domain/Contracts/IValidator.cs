namespace EvilCorp.SlackStorage.WebBusinessApi.Domain.Contracts
{
    public interface IValidator
    {
        bool IsValidId(string id);
    }
}