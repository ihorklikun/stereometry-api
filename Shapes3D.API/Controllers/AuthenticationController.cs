using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shapes3D.API.Controllers.Base;
using Shapes3D.BLL.Services.Interface;
using Shapes3D.UserIdentity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shapes3D.BLL.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Shapes3D.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IAuthManager _authManager;
        private readonly IUserRegistrationService _userRegistrationService;

        public AuthenticationController(
            UserManager<ApplicationUser> userManager,
            IMapper mapper,
            IAuthManager authManager,
            IUserRegistrationService userRegistrationService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _authManager = authManager;
            _userRegistrationService = userRegistrationService;
        }

        [NonAction]
        private async Task<IActionResult> RegisterUser(RegisterUserViewModel userModel, string role)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = _mapper.Map<ApplicationUser>(userModel);
                user.UserName = userModel.Email;

                var result = await _userManager.CreateAsync(user, userModel.Password);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                await _userManager.AddToRoleAsync(user, role);

                await _userRegistrationService.CreateProfile(user, userModel.FirstName, userModel.LastName);

                if (!await _authManager.ValidateUser(userModel))
                {
                    return Unauthorized();
                }

                return Accepted(new
                {
                    Token = await _authManager.CreateToken()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> RegisterRegularUser([FromBody] RegisterUserViewModel userModel)
        {
            //var res = RegisterUser(userModel, "RegularUser").Result;
            //return res;

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = _mapper.Map<ApplicationUser>(userModel);
                user.UserName = userModel.Email;

                var result = await _userManager.CreateAsync(user, userModel.Password);
                if (!result.Succeeded)
                {
                    return BadRequest(result.Errors);
                }

                await _userManager.AddToRoleAsync(user, "RegularUser");

                await _userRegistrationService.CreateProfile(user, userModel.FirstName, userModel.LastName);

                if (!await _authManager.ValidateUser(userModel))
                {
                    return Unauthorized();
                }

                return Accepted(new
                {
                    Token = await _authManager.CreateToken()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterUserViewModel userModel)
        {
            return await RegisterUser(userModel, "Admin");
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginUserViewModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                if (!await _authManager.ValidateUser(userModel))
                {
                    return Unauthorized();
                }

                return Accepted(new
                {
                    Token = await _authManager.CreateToken()
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("[action]")]
        public async Task<IActionResult> RemoveUserById(Guid userId)
        {
            try
            {
                var result = await _authManager.RemoveUserById(userId);
                if (!result)
                {
                    return BadRequest("Error");
                }

                return Accepted();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
