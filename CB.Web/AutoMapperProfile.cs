using AutoMapper;
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
        }
    }
}
