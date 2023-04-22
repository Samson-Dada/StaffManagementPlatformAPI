using AutoMapper;
using StaffManagementPlatfromAPI.Domain.Entities;
using StaffManagementPlatfromAPI.Domain.Models;

namespace StaffManagementPlatfromAPI.Profiles
{
    public class DepartmentProfile: Profile
    {
        public DepartmentProfile()
        {
            // Mapping for Get() request
            CreateMap<Department, DepartmentGetDto>();


            // 
            CreateMap<Department, DepartmentGetDto>();
            CreateMap<DepartmentCreateDto, Department>();

            // Mapping for Post() Request
            CreateMap<DepartmentGetDto, Department>();
            CreateMap<Department, DepartmentWithStaffDto>();
        }
    }
}
