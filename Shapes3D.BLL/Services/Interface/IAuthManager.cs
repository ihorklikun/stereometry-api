﻿using Shapes3D.BLL.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Shapes3D.BLL.Services.Interface
{
    public interface IAuthManager
    {
        Task<string> CreateToken();
        Task<bool> ValidateUser(LoginUserViewModel userModel);
        Task<List<Claim>> GetClaims();
        Task<bool> RemoveUserById(Guid userId);
    }
}
