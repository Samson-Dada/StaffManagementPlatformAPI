using AutoMapper;
using StaffManagementPlatfromAPI.Domain.Entities;
using StaffManagementPlatfromAPI.Domain.Models;
using StaffManagementPlatfromAPI.Utilities;

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
                .ForMember(dest => dest.DepartmentName, options => options.MapFrom(src => src.Department.ToString()));

            // not yet tested
            CreateMap<StaffForCreationDto, Staff>()
                .ForMember(dest => $"{dest.FirstName} {dest.LastName}", opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.DateOfBirth.GetCurrentAge(), opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.Department.ToString(), opt => opt.MapFrom(src => src.DepartmentName))
                .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId));

        }
    }

}
