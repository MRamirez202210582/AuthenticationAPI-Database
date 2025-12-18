using AuthenticationAPI_Database.Model;

namespace AuthenticationAPI_Database.Data.Interface
{
    public interface IUsuarioQueryServices
    {
        List<Usuario> GetAll();
    }
}
