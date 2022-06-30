using AutoMapper;
using ClassLibraryDto;
using ClassLibraryDto.Admin;
using Rbac.Entity;

namespace Rbac.Application
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Menu,EditMenuDto>().ReverseMap();
            CreateMap<Admin,AddAdmin>().ReverseMap();
            CreateMap<UserInfor, Admin>().ReverseMap();
            CreateMap<Role,Role>().ReverseMap();
        }
    }
}
