using AuthenticationAPI_Database.Data.Interface;
using AuthenticationAPI_Database.Data.Resource;
using AuthenticationAPI_Database.Data.Services;
using AuthenticationAPI_Database.Data.Token.JWT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI_Database.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthenticationController(IHashingServices hashingServices,IUsuarioCommandServices usuarioCommandServices,IUsuarioQueryServices usuarioQueryServices, ITokenServices tokenServices) : Controller
    {
        [HttpPost("LogIn")]
        public IActionResult LogIn(LoginResource loginResource)
        {
            var usuario = usuarioQueryServices.GetAll().FirstOrDefault(u => u.correo == loginResource.correo);
            if (usuario == null)
            {
                return Unauthorized(new { Message = "UsuarioInvalido" });
            }

            if (!hashingServices.VerifyPasword(loginResource.contrasena, usuario.contrasena))
            {
                return Unauthorized();
            }
            var token = tokenServices.GenerateToken(usuario);
            return Ok(new { token = token });
        }

        [HttpPost("SignIn")]
        public IActionResult SignIn(SignInResource signInResource)
        {
            var usuario = usuarioQueryServices.GetAll().FirstOrDefault(u => u.correo == signInResource.correo);
            if (usuario != null)
            {
                return Unauthorized(new { Message = "UsuarioInvalido" });
            }
            string contrasenaEncriptada = hashingServices.HashPassword(signInResource.contrasena);
            usuarioCommandServices.InsertUsuario(signInResource.correo, signInResource.contrasena);
            return Ok();
        }
    }
}
