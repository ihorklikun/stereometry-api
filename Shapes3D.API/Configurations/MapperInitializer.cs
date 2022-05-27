using AutoMapper;
using Shapes3D.BLL.Models.Shape;
using Shapes3D.BLL.Models.ShapeType;
using Shapes3D.BLL.Models.User;
using Shapes3D.DAL.Entities;
using Shapes3D.UserIdentity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shapes3D.API.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<ApplicationUser, RegisterUserViewModel>().ReverseMap();
            CreateMap<Admin, UserInfoViewModel>()
                .ForMember("Role", opt => opt.MapFrom(a => "Admin"));
            CreateMap<RegularUser, UserInfoViewModel>()
                .ForMember("Role", opt => opt.MapFrom(e => "RegularUser"));
            
            CreateMap<RegularUser, ProfileInfoViewModel>();
            CreateMap<Admin, ProfileInfoViewModel>();

            CreateMap<Shape, GetShapeViewModel>().ReverseMap();
            CreateMap<ShapeType, GetShapeTypeViewModel>().ReverseMap();
        }
    }
}
