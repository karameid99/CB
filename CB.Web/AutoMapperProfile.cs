using AutoMapper;
using CB.Models.DTOs.Client;
using CB.Models.DTOs.Role;
using CB.Models.DTOs.Supervisor;
using CB.Models.Entities.Auth;

namespace CB.Web.AutoMapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SupervisorCreateDto, CBUser>();
            CreateMap<CBUser, SupervisorUpdateDto>()
                .ForMember(x => x.Password, x => x.Ignore());
            CreateMap<RoleCreateDto, Role>();
            CreateMap<Role, RoleUpdateDto>();

            CreateMap<ClientCreateDto, CBUser>();

            CreateMap<CBUser, ClientUpdateDto>()
    .ForMember(x => x.Password, x => x.Ignore());
        }
    }
}
