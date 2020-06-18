using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using apiCatalanaContables.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace apiCatalanaContables.Controllers.Auth
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly catalanacontablesContext _context;

        public TokenController(IConfiguration config, catalanacontablesContext context)
        {
            _configuration = config;
            _context = context;
        }

        [HttpPost("getempleado")]
        public async Task<IActionResult> getEmpleado(Usuarios userData)
        {
            UsuariosAuth _userData = new UsuariosAuth();
            _userData.Usuario = userData.Usuario;
            _userData.Password = userData.Password;

            if (_userData.Usuario != null && _userData.Password != null)
            {
                /* var user = await _context.Usuarios.Include(d => d.Departamento).Include(a => a.Area).Include(ca => ca.Cargo).
                 Include(emp => emp.Empresa).Include(rol => rol.Rol).
                 FirstOrDefaultAsync(u => u.Usuario == _userData.Usuario && u.Password == _userData.Password);
                  return Ok(user);*/

                var user = await _context.Usuarios.Include(c => c.Cargo).ThenInclude(dp => dp.Departamento).ThenInclude(ar => ar.Area).ThenInclude(emp => emp.Empresa).
                  FirstOrDefaultAsync(u => u.Usuario == _userData.Usuario && u.Password == _userData.Password);
                return Ok(user);
            }
            else
            {
                return BadRequest("Invalid credentials");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsuariosAuth userData)
        {
            UsuariosAuth _userData = new UsuariosAuth();
            _userData.Usuario = userData.Usuario;
            _userData.Password = userData.Password;

            if (_userData.Usuario != null && _userData.Password != null)
            {
                var user = await GetUser(_userData.Usuario, _userData.Password);
                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.Id.ToString()),
                    new Claim("nombres", user.Nombres),
                    new Claim("apellidos", user.Apellidos),
                    new Claim("usuario", user.Usuario),
                   // new Claim("rol", user.Rol.Rol),
                    //new Claim("empresa", user.Empresa.Empresa),
                    //new Claim("area", user.Area.Area),
                    //new Claim("depa", user.Departamento.Departamento),
                   // new Claim("cargo", user.Cargo.Cargo),
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    //var token1 = new JwtSecurityTokenHandler().WriteToken(token);
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                    //return Ok(token);
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<Usuarios> GetUser(string usuario, string password)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.Usuario == usuario && u.Password == password);
        }
    }
}
