using AuthenticationAPI_Database.Data.Interface;
using AuthenticationAPI_Database.Model;

namespace AuthenticationAPI_Database.Data.Services
{
    public class UsuarioCommandServices:IUsuarioCommandServices
    {
        public readonly AppDbContext dbContext;
        public readonly IHashingServices hashingServices;

        public UsuarioCommandServices(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void InsertUsuario( string correo, string contrasena)
        {
            var usuario = new Usuario {correo=correo,contrasena=hashingServices.HashPassword(contrasena) };
            dbContext.Add(usuario);
            dbContext.SaveChangess();
        }
    }
}
