using KainatTarar.Challange.Model.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KainatTarar.Challange.API
{
    public class Shared
    {
        public string SecretKey { get { return "9769aa4b-f346-450d-93da-d1f20a1b2650"; } }

        public string GenerateToken(LoginResult loginResult)
        {
            var claims = new[]
            {
                new Claim("Id", loginResult.Id.ToString()),
                new Claim("Username", loginResult.Username.ToString())
            };

            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(SecretKey));
            SigningCredentials creds = new(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(
                null, //_config["Jwt:Issuer"],
                null, //_config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public ClaimsPrincipal DecodeToken(string token)
        {
            token = token.Replace("Bearer ", "");
            var validations = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            };

            var jwtSecurityToken = new JwtSecurityTokenHandler().ValidateToken(token, validations, out var tokenSecure);
            return jwtSecurityToken;
        }

        public int GetUserId(string token)
        {
            ClaimsPrincipal jwtSecurityToken = DecodeToken(token: token);
            return int.Parse(jwtSecurityToken.Claims.FirstOrDefault(r => r.Type == "Id").Value);
        }
    }
}
