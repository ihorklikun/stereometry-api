using Shapes3D.BLL.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shapes3D.BLL.UnitOfWork;
using Shapes3D.BLL.Models.User;
using Shapes3D.DAL.Entities;

namespace Shapes3D.BLL.Services
{
    public class ProfileDataService : IProfileDataService
    {
        private readonly IAuthentificationUnitOfWork _unitOfWork;
        private readonly IProfileManager _profileManager;
        private readonly IMapper _mapper;

        public ProfileDataService(IAuthentificationUnitOfWork unitOfWork, IMapper mapper, IProfileManager profileManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _profileManager = profileManager;
        }

        public async Task<UserInfoViewModel> GetRegularUserProfileInfoById(Guid id)
        {
            //var student = await _unitOfWork.StudentRepository.GetById(id);
            var student = await _unitOfWork.RegularUserRepository.FirstOrDefault(x => x.IdLink == id);
            var email = await _profileManager.GetEmailByUserId(id);
            if (student == null)
            {
                throw new Exception("Student with this id was not found!");
            }

            var profileInfo = _mapper.Map<RegularUser, UserInfoViewModel>(student);
            profileInfo.Email = email;

            return profileInfo;
        }

        public async Task<UserInfoViewModel> GetAdminProfileInfoById(Guid id)
        {
            var admin = await _unitOfWork.AdminRepository.FirstOrDefault(x => x.IdLink == id);
            var email = await _profileManager.GetEmailByUserId(id);

            if (admin == null)
            {
                throw new Exception("Admin with this id was not found!");
            }

            var profileInfo = _mapper.Map<Admin, UserInfoViewModel>(admin);
            profileInfo.Email = email;

            return profileInfo;
        }

        public async Task UpdateRegularUserProfileInfoById(ProfileInfoViewModel model, Guid id)
        {
            var user = await _unitOfWork.RegularUserRepository.GetById(id);

            if (user == null)
            {
                throw new Exception("Employee with this id was not found!");
            }

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;

            await _unitOfWork.Save();
        }

        public async Task UpdateAdminProfileInfoById(ProfileInfoViewModel model, Guid id)
        {
            var admin = await _unitOfWork.AdminRepository.GetById(id);

            if (admin == null)
            {
                throw new Exception("Admin with this id was not found!");
            }

            admin.FirstName = model.FirstName;
            admin.LastName = model.LastName;

            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<UserInfoViewModel>> GetAllUsersInfo()
        {
            List<UserInfoViewModel> userList = new List<UserInfoViewModel>();

            var users = (await _unitOfWork.RegularUserRepository.GetAll()).ToList();

            if (users == null)
            {
                throw new Exception("Students not found!");
            }

            foreach (var item in users)
            {
                var email = await _profileManager.GetEmailByUserId(item.IdLink);
                var user = _mapper.Map<RegularUser, UserInfoViewModel>(item);
                user.Email = email;
                userList.Add(user);
            }

            var admins = (await _unitOfWork.AdminRepository.GetAll()).ToList();

            if (admins == null)
            {
                throw new Exception("Admins not found!");
            }

            foreach (var item in admins)
            {
                var email = await _profileManager.GetEmailByUserId(item.IdLink);
                var user = _mapper.Map<Admin, UserInfoViewModel>(item);
                user.Email = email;
                userList.Add(user);
            }

            return userList;
        }
    }
}
