﻿using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.DataAccess.Context;
using StaffManagementPlatfromAPI.Domain.Entities;
using StaffManagementPlatfromAPI.Domain.Repositories.ModelRepository;

namespace StaffManagementPlatfromAPI.DataAccess.Implimentations
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        private readonly ApplicationContext _dbContext;
        public DepartmentRepository(ApplicationContext dbContex) : base(dbContex)
        {
           _dbContext = dbContex;
        }

        //public async Task<IEnumerable<Department>> GetAllDepartment()
        //{
        //    var allDepartment = await _dbContext.Departments.OrderBy(d => d.Name).ToListAsync();
        //    return allDepartment;
        //}

        public string DepartmentDescription(int id)
        {
            var departmentDesc = _dbContext.Departments.FirstOrDefault(x => x.Id == id);
            return departmentDesc?.Description;
        }
        public IEnumerable<Department> DepartmentWithStaff()
        {
            var departmentWitStaff =  _dbContext.Departments.Include(s => s.Staffs).ToList();
            return departmentWitStaff;  
        }

        public async void UpdateDepartmentDescription(int id, string description)
        {
          var department = await GetById(id);
            if (department == null)
            {
                throw new ArgumentException($"Department with ID {id} does not exist.");
            }
            department.Description = description;
            _dbContext.SaveChanges();
            
        }
        
    }
}
