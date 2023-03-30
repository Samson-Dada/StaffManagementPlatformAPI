using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.Domain.Entities;
using StaffManagementPlatfromAPI.Domain.Repositories.ModelRepository;
using StaffManagementPlatfromAPI.Domain.Repositories.UnitOfWork;

namespace StaffManagementPlatfromAPI.Controllers
{
    [ApiController]
    [Route("api/staffs")]
    public class StaffController : ControllerBase
    {
      //private readonly  IUnitOfWork _unitOfWork;
        private readonly IUnitOfWork _unitOfWork;

        public StaffController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }


        //[HttpGet]
        //public async Task<ActionResult> GetStaffs()
        //{
        //    var allStaff =  await  _unitOfWork.Staff.GetAllAsync();
        //    return Ok(allStaff);
        //}

        [HttpGet("{id}")]
        public IActionResult GetStaffById(int id)
        {
            var getWithId = _unitOfWork.StaffRepository.GetById(id);
            if (getWithId is null)
            {
                return NotFound("Id cannot be found");
            }
            return Ok(getWithId);
        }

        [HttpGet]
        public async Task<ActionResult<List<Staff>>> GetStaffFullNamesByNames([FromQuery] string searchNames)
        {
            var staffNamesList= await _unitOfWork.StaffRepository.GetFullNameAsync(searchNames);
            return Ok(staffNamesList);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            try
            {
                var staffToDelete = await _unitOfWork.DepartmentRepository.GetById(id);
                /*
                     if (departmentToDelete == null)
                        {
                            return NotFound();
                        }
                 */
                var staffId = _unitOfWork.DepartmentRepository.IsExist(id);
                if (staffId is false)
                {
                    return NotFound("Staff Id cannot be found!");
                }
                _unitOfWork.DepartmentRepository.Delete(staffToDelete);
                _unitOfWork.Save();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting Staff");

            }
        }

        [HttpPost]
        public IActionResult CreateStaff([FromBody] Staff staff)
        {

            if(!ModelState.IsValid)
            {
                return BadRequest();
            }
            _unitOfWork.StaffRepository.Create(staff);
            _unitOfWork.Save();
            return CreatedAtAction(nameof(GetStaffById), new Staff {Id = staff.Id }, staff);
        }
    }
}
