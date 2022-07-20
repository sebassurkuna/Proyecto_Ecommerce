using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Proyecto.Ecommerce.Aplicacion.Servicios;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Authentication;
using System.Security.Claims;
using System.Text;

namespace Proyecto.Ecommerce.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtConfiguration jwtConfiguration;
        private readonly IClienteAppServicio cliente;

        public TokenController(IOptions<JwtConfiguration> options, IClienteAppServicio cliente)
        {
            this.jwtConfiguration = options.Value;
            this.cliente = cliente;
        }


        [HttpPost]
        public async Task<string> TokenAsync(string user, string password)
        {

            //1. Validar User.
            var clientes = await cliente.ObtenerClientesDtoAsync();
            var userTest = new List<string>();
            var passwordTest = new List<string>();
            foreach (var cliente in clientes)
            {
                userTest.Add(cliente.NombreUsuario);
            }

            foreach (var cliente in clientes)
            {
                passwordTest.Add(cliente.Contraseña);
            }

            if (userTest.Contains(user)==false || passwordTest.Contains(password)==false)
            {
                throw new AuthenticationException("User or Passowrd incorrect!");
            }

            //2. Generar claims
            //create claims details based on the user information
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, user),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserName", user),
                        //new Claim("Email", user.Email)
                        //Other...
            };


             var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfiguration.Key));
             var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
             var tokenDescriptor = new JwtSecurityToken(
                    jwtConfiguration.Issuer,
                    jwtConfiguration.Audience,
                    claims,
                    expires: DateTime.UtcNow.Add(jwtConfiguration.Expires),
                    signingCredentials: signIn);

              var jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

            return jwt;

        }
    }
}
