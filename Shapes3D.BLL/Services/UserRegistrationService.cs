using Microsoft.AspNetCore.Identity;
using Shapes3D.BLL.Services.Interface;
using Shapes3D.BLL.UnitOfWork;
using Shapes3D.DAL.Entities;
using Shapes3D.UserIdentity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.Services
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IAuthentificationUnitOfWork _unitOfWork;

        public UserRegistrationService(UserManager<ApplicationUser> userManager,
            IAuthentificationUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<bool> CreateProfile(ApplicationUser user, string firstName, string lastName)
        {
            IList<string> role = await _userManager.GetRolesAsync(user);
            if (role.Contains("RegularUser"))
            {
                await _unitOfWork.RegularUserRepository.Add(new RegularUser(Guid.Parse(user.Id))
                {
                    FirstName = firstName,
                    LastName = lastName
                });
                await _unitOfWork.Save();
                return true;
            }
            else if (role.Contains("Admin"))
            {
                await _unitOfWork.AdminRepository.Add(new Admin(Guid.Parse(user.Id))
                {
                    FirstName = firstName,
                    LastName = lastName
                });
                await _unitOfWork.Save();
                return true;
            }
            else
            {
                throw new Exception("Role is not set");
            }
        }
    }
}
