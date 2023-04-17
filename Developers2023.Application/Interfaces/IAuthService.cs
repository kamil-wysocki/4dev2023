namespace Developers2023.Application.Interfaces
{
    public interface IAuthService
    {
        string GetToken(string username, string password);
    }
}
