using AuthenticationAPI_Database.Model;

namespace AuthenticationAPI_Database.Data.Interface
{
    public interface ITokenServices
    {
        string GenerateToken(Usuario usuario);
        Task<int?> ValidateToken(string token);
    }
}
