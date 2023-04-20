using AutoMapper;
using StaffManagementPlatfromAPI.Domain.Entities;
using StaffManagementPlatfromAPI.Domain.Models;

namespace StaffManagementPlatfromAPI.Profiles
{
    public class DepartmentProfile: Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentDto, Department>();
            CreateMap<Department, DepartmentWithStaffDto>();
           // CreateMap<Staff, StaffDto>();
            CreateMap<DepartmentDescriptionUpdateDto, Department>();
            CreateMap<StaffDto, Staff>();
            CreateMap<Staff, StaffDto>();
        }
    }
}
