using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.DataAccess.Context;
using StaffManagementPlatfromAPI.Domain.Models;
using StaffManagementPlatfromAPI.Domain.Repositories.ModelRepository;
using System;

namespace StaffManagementPlatfromAPI.DataAccess.Implimentations
{
    public class StaffRepository : BaseRepository<Staff>, IStaffRepository
    {
        private readonly ApplicationContext _context;
        public StaffRepository(ApplicationContext context): base(context) { }
      

        public Task<Staff> GetByIdAsync(int id)
        {
            return _context.Staffs.FirstOrDefaultAsync(s => s.Id == id);

        }

        public IEnumerable<Staff> GetAllStaff(int countStaff)
        {
            //return _context.Staffs.Select( x => x.Staffs).Take(count).ToList();
            var allStaff = _context.Staffs.Take(countStaff).ToList();
            return allStaff;
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
