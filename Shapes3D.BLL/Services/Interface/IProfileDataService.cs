using Shapes3D.BLL.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.Services.Interface
{
    public interface IProfileDataService
    {
        public Task<UserInfoViewModel> GetRegularUserProfileInfoById(Guid id);
        public Task<IEnumerable<UserInfoViewModel>> GetAllUsersInfo();
        public Task<UserInfoViewModel> GetAdminProfileInfoById(Guid id);
        public Task UpdateRegularUserProfileInfoById(ProfileInfoViewModel model, Guid id);
        public Task UpdateAdminProfileInfoById(ProfileInfoViewModel model, Guid id);
    }
}
