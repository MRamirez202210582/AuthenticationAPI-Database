using BCryptNet = BCrypt.Net.BCrypt;
using AuthenticationAPI_Database.Data.Interface;

namespace AuthenticationAPI_Database.Data.Services
{
    public class HashingServices:IHashingServices
    {
        public string HashPassword(string password)
        {
            return BCryptNet.HashPassword(password);
        }

        public bool VerifyPasword(string pasword, string PasswordHashing) { 
            return BCryptNet.Verify(pasword, PasswordHashing);
        }
    }
}
