namespace AuthenticationAPI_Database.Data.Interface
{
    public interface IUsuarioCommandServices
    {
        void InsertUsuario(string correo, string contrasena);

    }
}
