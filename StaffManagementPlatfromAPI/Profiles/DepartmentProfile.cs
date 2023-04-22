using AutoMapper;
using StaffManagementPlatfromAPI.Domain.Entities;
using StaffManagementPlatfromAPI.Domain.Models;

namespace StaffManagementPlatfromAPI.Profiles
{
    public class DepartmentProfile: Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department, DepartmentGetDto>();
            CreateMap<DepartmentCreateDto, Department>();
         



            //
            CreateMap<Department, DepartmentDescriptionUpdateDto>();
            
            CreateMap<DepartmentGetDto, Department>();
            CreateMap<Department, DepartmentWithStaffDto>();
        }
    }
}
