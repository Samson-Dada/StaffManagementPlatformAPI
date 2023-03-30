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
            CreateMap<Domain.Models.DepartmentDto, Domain.Entities.Department>();
            CreateMap<Domain.Entities.Department, Domain.Models.DepartmentWithStaffDto>();
           CreateMap<Staff, StaffDto>();

        }
    }
}
