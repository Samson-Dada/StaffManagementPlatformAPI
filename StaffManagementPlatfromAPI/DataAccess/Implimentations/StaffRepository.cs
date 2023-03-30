using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.DataAccess.Context;
using StaffManagementPlatfromAPI.Domain.Entities;
using StaffManagementPlatfromAPI.Domain.Repositories.ModelRepository;
using System;

namespace StaffManagementPlatfromAPI.DataAccess.Implimentations
{
    public class StaffRepository : BaseRepository<Staff>, IStaffRepository
    {
        private readonly ApplicationContext _context;
        public StaffRepository(ApplicationContext context) : base(context)
        {
            _context= context;
        }

       public async Task<IEnumerable<Staff>> GetStaffByDepartment(int DepartmentId)
        {
         var filterStaff = await  _context.Staffs
                .Where(s => s.DepartmentId == DepartmentId)
                .ToListAsync();
            return filterStaff;
        }

        public Task<bool> StaffExistsAsync(int StaffId)
        {
            //_context.Staffs.AnyAsync(x=> x.Id == StaffId);
            var checkStaffById = _context.Staffs.AnyAsync(x => x.Equals(StaffId));
            return checkStaffById;
        }

        public async Task<bool> SaveChangesAsync()
        {
            var save = await _context.SaveChangesAsync() >= 0;
            return save;
        }

        public async Task<IEnumerable<Staff>> GetFullNameAsync(string searchNames)
        {
            var collection = _context.Staffs as IQueryable<Staff>;
            if (string.IsNullOrWhiteSpace(searchNames))
            {
                return  await GetAllAsync();       
            }
            if(!string.IsNullOrWhiteSpace(searchNames))
            {
                searchNames = searchNames.Trim();
                collection = collection.Where(x => x.FirstName.Contains(searchNames));

            }
            return await collection.OrderBy( c => c.FirstName).ToListAsync();
           //var searchQuery = await  _context.Set<Staff>().Where(s =>
           // s.FirstName.Contains(searchNames) &&
           // s.LastName.Contains(searchNames)).ToListAsync();
           // return searchQuery;
        }

        //public Task<Staff> GetByNameAsync(string name)
        //{
        //     _context.Staffs.OrderBy(x => x.FirstName && x.LastName == name);
        //}

        //public async Task<Staff> GetByFullNameAsync(string firstName, string lastName, int staffId)
        //{
        //    //return await _context.Staffs.Select(x => x.FirstName && x.LastName == id ); 
        //    //return  await _context.Staffs.AnyAsync(s => s.Id == staffId && s.FirstName == firstName&& s.LastName == lastName);
        //    // return await _context.Cities.AnyAsync(c => c.Id == cityId && c.Name == cityName);
        //    //return await _context.Cities.OrderBy(c => c.Name).ToListAsync();

        //}

    }
}
