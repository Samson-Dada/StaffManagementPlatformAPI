using AutoMapper;
using StaffManagementPlatfromAPI.Domain.Entities;
using StaffManagementPlatfromAPI.Domain.Models;
using StaffManagementPlatfromAPI.Utilities;

namespace StaffManagementPlatfromAPI.Profiles
{
    /// <summary>
    /// Mapping profile class for Staff
    /// </summary>
    public class StaffProfile : Profile
    {
        /// <summary>
        /// Mapping profile between Staff entities and other variance of Staff models
        /// </summary>
        public StaffProfile()
        {
            //use for mapping to get() full names
            CreateMap<Staff, StaffFullnameDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            //use for mapping to get() partial detials of staff
            CreateMap<Staff, StaffPartialDetailsDto>()
                .ForMember(dest => dest.FullName, options => options.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.DepartmentName, options => options.MapFrom(src => src.Department.Name));


            // use for mapping  to create new staff
            CreateMap<StaffForCreationDto, Staff>()
                .ForPath(dest => dest.Department.Name, options => options.MapFrom(src => src.DepartmentName));

            // use for mapping to get staff to the destination
            CreateMap<Staff, StaffGetDto>();

            // CreateMap<StaffForCreationDto2, Staff>();

            //use for mapping to get() full Staff Details
            CreateMap<StaffFullDto, Staff>();

            // use for mapping to 
            CreateMap<Staff, StaffFullDto>();
        }
    }
}

