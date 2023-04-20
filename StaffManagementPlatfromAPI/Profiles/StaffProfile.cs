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
                .ForMember(dest => dest.Email, options => options.MapFrom(src => src.Email))
                .ForMember(dest => dest.Phone, options => options.MapFrom(src => src.Phone))
                .ForMember(dest => dest.DepartmentName, options => options.MapFrom(src => src.Department.Name));


            // use for mapping  to create new staff
            CreateMap<StaffForCreationDto, Staff>()
                .ForMember(dest => dest.DateOfBirth, options => options.MapFrom(src => src.Age))
                //.ForPath(dest => dest.Department.Name, options => options.MapFrom(src => src.DepartmentName))
                .ForMember(dest => dest.Phone, options => options.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Role, options => options.MapFrom(src => src.Role))
                //.ForMember(dest => dest.Id, options => options.MapFrom(src => src.DepartmentId))
                .ForMember(dest => dest.FirstName, options => options.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, options => options.MapFrom(src => src.LastName));
                



            /*
             {
  "age": 38,
  "firstName": "John",
  "lastName": "Deo",
  "email": "johnd@mail.com",
  "departmentName": "IT & Software Development",
  "phoneNumber": "+2347884456677",
  "departmentId": 0
}
             */

            //use for mapping to get() full Staff Details

            CreateMap<Staff, StaffFullDto>()
                .ForMember(dest => dest.FullName, options => options.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Age, options => options.MapFrom(src => src.DateOfBirth))
                .ForPath(dest => dest.DepartmentName, options => options.MapFrom(src => src.Department.Name))
                .ForMember(dest => dest.Address, options => options.MapFrom(src => src.Address))
                .ForMember(dest => dest.Role, options => options.MapFrom(src => src.Role))
                .ForMember(dest => dest.HireDate, options => options.MapFrom(src => src.HireDate));



            // use for mapping to 
            CreateMap<Staff, StaffFullDto>();
            CreateMap<StaffDto, Staff>();
            CreateMap<Staff, StaffDto>();


            //use for mapping to get() full names
            //CreateMap<Staff, StaffFullnameDto>()
            // .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}
