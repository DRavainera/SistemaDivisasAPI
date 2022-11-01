using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SistemaDivisasAPI.Data;
using SistemaDivisasAPI.Models;
using SistemaDivisasAPI.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ConfigurationManager = SistemaDivisasAPI.Data.ConfigurationManager;

namespace SistemaDivisasAPI.Mediator
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, LoginQueryResponse>
    {
        protected readonly ApplicationDbContext _context;

        public LoginQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LoginQueryResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var listaClientes = await _context.Cliente.ToListAsync();

            var tokenString = String.Empty;

            foreach (var cliente in listaClientes)
            {
                if (request.Usuario == cliente.Usuario && request.Contrasenia == cliente.Contrasenia)
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:SigningKey"]));

                    var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var tokenOptions = new JwtSecurityToken(issuer: ConfigurationManager.AppSetting["JWT:Issuer"],
                        audience: ConfigurationManager.AppSetting["JWT:Audience"],
                        claims: new List<Claim>(), expires: DateTime.Now.AddMinutes(7200), signingCredentials: signingCredentials);

                    tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                }
            }

            var token = new LoginQueryResponse()
            {
                Token = tokenString
            };

            return token;
        }
    }
}
