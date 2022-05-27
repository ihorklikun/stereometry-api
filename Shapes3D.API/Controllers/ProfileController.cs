using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shapes3D.API.Controllers.Base;
using Shapes3D.BLL.Models.User;
using Shapes3D.BLL.Services.Interface;
using Shapes3D.UserIdentity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes3D.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : BaseController
    {
        private readonly IProfileDataService _profileDataService;
        private readonly IProfileManager _profileManager;

        public ProfileController(IProfileDataService profileDataService, IProfileManager profileManager)
        {
            _profileDataService = profileDataService;
            _profileManager = profileManager;
        }

        [HttpGet]
        [Route("getMyInfo")]
        public async Task<IActionResult> GetMyInfo()
        {
            UserInfoViewModel profileInfo = null;

            try
            {
                
                if (User.IsInRole("RegularUser"))
                {
                    profileInfo = await _profileDataService.GetRegularUserProfileInfoById(GetUserId());
                }
                else if (User.IsInRole("Admin"))
                {
                    profileInfo = await _profileDataService.GetAdminProfileInfoById(GetUserId());
                }
                else
                {
                    throw new Exception("Invalid user role!");
                }
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }

            return Ok(profileInfo);
        }

        [HttpGet]
        [Route("getAll")]
        public async Task<IActionResult> GetAll()
        {
            List<UserInfoViewModel> usersInfoList = null;

            try
            {
                usersInfoList = (List<UserInfoViewModel>)await _profileDataService.GetAllUsersInfo();

                
                 
                //if (User.IsInRole("Admin"))
                //{
                //}
                //else
                //{
                //    throw new Exception("Invalid user role!");
                //}
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }

            return Ok(usersInfoList);
        }

        [HttpPut]
        [Route("info/update")]
        public async Task<IActionResult> UpdateMyInfo([FromBody] ProfileInfoViewModel userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model validation error!");
            }

            try
            {
                if (User.IsInRole("Student"))
                {
                    await _profileDataService.UpdateRegularUserProfileInfoById(userInfo, GetUserId());
                }
                else if (User.IsInRole("Admin"))
                {
                    await _profileDataService.UpdateAdminProfileInfoById(userInfo, GetUserId());
                }
                else
                {
                    throw new Exception("Invalid user role!");
                }
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }

            return Ok();
        }

        [HttpPut]
        [Route("password/update")]
        public async Task<IActionResult> UpdateMyPassword([FromBody] UpdatePasswordViewModel passwordModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model validation error!");
            }

            try
            {
                await _profileManager.UpdatePasswordByUserId(passwordModel, GetUserId());
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }

            return Ok();
        }

        [HttpGet]
        [Route("email")]
        public async Task<IActionResult> GetMyEmail()
        {
            string email = null;

            try
            {
                email = await _profileManager.GetEmailByUserId(GetUserId());
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }

            return Ok(email);
        }

        [HttpPut]
        [Route("email/update")]
        [Authorize]
        public async Task<IActionResult> UpdateMyEmail([FromBody] UpdateEmailViewModel emailModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model validation error!");
            }

            try
            {
                await _profileManager.UpdateEmailByUserId(emailModel, GetUserId());
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }

            return Ok();
        }
    }
}
