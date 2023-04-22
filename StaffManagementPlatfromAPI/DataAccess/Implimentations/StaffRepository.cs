using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.DataAccess.Context;
using StaffManagementPlatfromAPI.Domain.Entities;
using StaffManagementPlatfromAPI.Domain.Repositories.ModelRepository;

namespace StaffManagementPlatfromAPI.DataAccess.Implimentations
{
    public class StaffRepository : BaseRepository<Staff>, IStaffRepository
    {
        private readonly ApplicationContext _context;
        public StaffRepository(ApplicationContext context) : base(context)
        {
            _context= context;
        }


        public async Task<List<Staff>> GetAllAsyncStaff()
        {
            //var allEntity = await _dbSet.ToListAsync();
            var allEntity = await _context.Staffs.Where(x => x.Id == 1).ToListAsync();
            return allEntity;
        }

        public async Task<IEnumerable<Staff>> GetStaffByDepartmentId(int DepartmentId)
        {
         var filterStaff = await  _context.Staffs.Where(s => s.DepartmentId == DepartmentId)
                .ToListAsync();
            return filterStaff;
        }
     

        public  async Task<bool> StaffExistsAsync(int StaffId)
        {
            if( StaffId  == 0)
            {
                throw new ArgumentException(null, nameof(StaffId));
            }
            var checkStaffById =await _context.Staffs.AnyAsync(x => x.Equals(StaffId));
            return checkStaffById;
        }
         

        //
        public async Task<IEnumerable<Staff>> GetAllFullNameAsync(string searchNames)
        {
            return await _context.Staffs.ToListAsync();
        }

      
        public async Task<Staff> GetStaffByFullNameAsync(string fullName)
        {

            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(fullName));
            }

            var nameComponents = fullName.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            if (nameComponents.Length == 1)
            {
                // Search for staff member with first or last name matching full name
                var staff = await _context.Staffs.FirstOrDefaultAsync(s =>
                    s.FirstName == fullName ||
                    s.LastName == fullName);

                return staff;
            }
            else if (nameComponents.Length == 2)
            {
                // Search for staff member with matching first and last name components
                var firstName = nameComponents[0];
                var lastName = nameComponents[1];

                var staff = await _context.Staffs.FirstOrDefaultAsync(s =>
                    s.FirstName == firstName &&
                    s.LastName == lastName);

                return staff;
            }
            else
            {
                // Full name contains more than two components; cannot search for staff member
                return null;
            }
        }
    }
}
