using Shapes3D.BLL.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.Services.Interface
{
    public interface IProfileManager
    {
        public Task<string> GetEmailByUserId(Guid id);
        public Task UpdateEmailByUserId(UpdateEmailViewModel model, Guid id);
        public Task UpdatePasswordByUserId(UpdatePasswordViewModel model, Guid id);
    }
}
