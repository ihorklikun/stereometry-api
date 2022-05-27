using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shapes3D.BLL.Models.User;
using Shapes3D.BLL.Services.Interface;
using Shapes3D.BLL.UnitOfWork;
using Shapes3D.UserIdentity.Data;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.Services
{
    public class AuthManager : IAuthManager
    {
        private readonly IAuthentificationUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;
        private ApplicationUser _user;

        public AuthManager(IAuthentificationUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _unitOfWork = unitOfWork;
        }
        public async Task<string> CreateToken()
        {
            var signinCredentials = GetSigninCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOptions(signinCredentials, claims);

            
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signinCredentials, List<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var options = new JwtSecurityToken(
                    issuer: jwtSettings.GetSection("Issuer").Value,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings.GetSection("Lifetime").Value)),
                    signingCredentials: signinCredentials);

            return options;
        }

        public async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName),
                new Claim(ClaimTypes.NameIdentifier, _user.Id)
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }

        public async Task<bool> RemoveUserById(Guid userId)
        {
            var _user = await _userManager.FindByIdAsync(userId.ToString());
            if (_user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(_user);
                var result = await _userManager.DeleteAsync(_user);
                if (result.Succeeded)
                {
                    if (userRoles.Contains("Admin"))
                    {
                        var admin = await _unitOfWork.AdminRepository.GetByIdLink(userId);
                        await _unitOfWork.AdminRepository.Remove(admin);
                        return true;
                    }
                    else
                    {
                        var regualrUser = await _unitOfWork.RegularUserRepository.GetByIdLink(userId);
                        await _unitOfWork.RegularUserRepository.Remove(regualrUser);
                        await _unitOfWork.Save();
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return false;
            }

        }

        private SigningCredentials GetSigninCredentials()
        {
            var key = _configuration.GetSection("Jwt").GetSection("Key").Value;
            var secret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        public async Task<bool> ValidateUser(LoginUserViewModel userModel)
        {
            _user = await _userManager.FindByNameAsync(userModel.Email);
            bool ok = (_user != null) && (await _userManager.CheckPasswordAsync(_user, userModel.Password));
            return ok;
        }
    }
}
