using Microsoft.Extensions.DependencyInjection;
using Shapes3D.BLL.Services;
using Shapes3D.BLL.Services.Interface;
using Shapes3D.BLL.UnitOfWork;
using Shapes3D.UserIdentity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes3D.API.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddRepository(this IServiceCollection service)
        {
            service.AddTransient<IAuthentificationUnitOfWork, AuthentificationUnitOfWork>();
            service.AddTransient<IProfileManager, ProfileManager<ApplicationUser>>();
            service.AddTransient<IProfileDataService, ProfileDataService>();

            service.AddTransient<IShapeUnitOfWork, ShapeUnitOfWork>();
            service.AddTransient<IShapeService, ShapeService>();

            service.AddTransient<IShapeTypeService, ShapeTypeService>();
            return service;
        }
    }
}
