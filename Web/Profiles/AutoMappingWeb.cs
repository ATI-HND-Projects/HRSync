using AuthLayer.Model;
using AutoMapper;
using DataAccessLayer.Models;
using Web.Models;

namespace Web.Profiles
{
    public class AutoMappingWeb : Profile
    {
        public AutoMappingWeb()
        {
            CreateMap<RegisterVM, AccountRegister>();

            CreateMap<LoginRequestVM, UserLogin>();

            CreateMap<DepartmentVM, Department>().ReverseMap();

            CreateMap<UserRoleVM, UserRoles>().ReverseMap();
        }
    }
}
