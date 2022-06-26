using AutoMapper;
using ClassLibraryDto;
using Rbac.Entity;

namespace Rbac.Application
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Menu,EditMenuDto>().ReverseMap();
            CreateMap<Admin,AddAdmin>().ReverseMap();
        }
    }
}
