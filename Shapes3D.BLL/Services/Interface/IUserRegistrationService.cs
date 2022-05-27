using Shapes3D.DAL.Entities;
using Shapes3D.UserIdentity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.Services.Interface
{
    public interface IUserRegistrationService
    {
        public Task<bool> CreateProfile(ApplicationUser user, string firstName, string lastName);
    }
}
