using AutoMapper;

namespace StaffManagementPlatfromAPI.Profiles
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
            CreateMap<Domain.Entities.Staff, Domain.Models.StaffDto>()
            .ForMember(dest => dest.Name, opt =>
                opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<Domain.Models.StaffDto, Domain.Entities.Staff>();
        }
    }
}
