namespace AuthenticationAPI_Database.Data.Interface
{
    public interface IHashingServices
    {
        string HashPassword(string password); 
        
        bool VerifyPasword(string pasword,string PasswordHashing);

    }
}
