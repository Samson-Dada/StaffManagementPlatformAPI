using AutoMapper;
using StaffManagementPlatfromAPI.Domain.Entities;
using StaffManagementPlatfromAPI.Domain.Models;
 
namespace StaffManagementPlatfromAPI.Profiles
{
    public class StaffProfile : Profile
    {
        public StaffProfile()
        {
            CreateMap<Staff, StaffFullDto>();

            //use for mapping to get() full names
            CreateMap<Staff, StaffFullnameDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            //use for mapping to get() partial detials of staff
            CreateMap<Staff, StaffPartialDetailsDto>()
                .ForMember(dest => dest.FullName, options => options.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Email, options => options.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, options => options.MapFrom(src => src.Phone))
                .ForMember(dest => dest.DepartmentName, options => options.MapFrom(src => src.Department.Name));

            //
            CreateMap<Staff, StaffFullnameDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }

}
