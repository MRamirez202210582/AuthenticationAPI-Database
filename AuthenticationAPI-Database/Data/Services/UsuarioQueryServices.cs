using AuthenticationAPI_Database.Data.Interface;
using AuthenticationAPI_Database.Model;

namespace AuthenticationAPI_Database.Data.Services
{
    public class UsuarioQueryServices:IUsuarioQueryServices
    {
        public readonly AppDbContext dbContext;

        public UsuarioQueryServices(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Usuario> GetAll()
        {
            return dbContext.Usuario.ToList();
        }
    }
}
