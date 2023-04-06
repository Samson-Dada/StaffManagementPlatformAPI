using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.Domain.Entities;
using StaffManagementPlatfromAPI.Domain.Models;
using StaffManagementPlatfromAPI.Domain.Repositories.UnitOfWork;

namespace StaffManagementPlatfromAPI.Controllers
{
    [Authorize]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/staffs")]
    public class StaffController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StaffController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ??
                throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        /// <summary>
        /// Get a list of Staff
        /// </summary>
        /// <returns></returns>

        //Working
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffFullDto>>> GetStaffs()
        {
            var allStaff = await _unitOfWork.StaffRepository.GetAllAsync();
            var mapStaff = _mapper.Map<IEnumerable<StaffFullDto>>(allStaff);
            return Ok(mapStaff);
        }
        /// <summary>
        /// Get a Staff by id
        /// </summary>
        /// <param name="id">The id is the staff to get</param>
        /// <returns>An ActionResult of {StaffFullDto} </returns>
        /// <response code="200">Returns the requested Staff</response>
        [HttpGet("{id}", Name = "GetStaffById")]
        [ProducesResponseType(typeof(StaffFullDto), 200)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<StaffFullDto>> GetStaffById(int id)
        {
            var getWithId = await _unitOfWork.StaffRepository.GetByIdAsync(id);
            if (getWithId is null)
            {
                return NotFound("Id cannot be found");
            }
            var mapId = _mapper.Map<StaffFullDto>(getWithId);
            return Ok(mapId);
        }

        // Working
        [HttpGet("{id}/fullnames")]
        public async Task<ActionResult<StaffFullnameDto>> GetStaffFullNamesByNames(int id)
        {
            var staffFullName = await _unitOfWork.StaffRepository.GetByIdAsync(id);

            if (staffFullName == null)
            {
                return NotFound();
            }
            var staffFullnameDto = _mapper.Map<StaffFullnameDto>(staffFullName);
            return Ok(staffFullnameDto);
        }


       // Working
        [HttpGet("fullNames")]
        public async Task<ActionResult<StaffPartialDetailsDto>> GetWithFullName(string fullNames)
        {
            var staffFullName = await _unitOfWork.StaffRepository.GetStaffByFullNameAsync(fullNames);
            if (staffFullName is null)
            {
                return NotFound($"Staff {staffFullName} does not exist");
            }
            var fullNameDto = _mapper.Map<StaffPartialDetailsDto>(staffFullName);
            return Ok(fullNameDto);
        }


        // Working partially (unable to return department name but return null)
        [HttpGet("{id}/staffs")]
        public async Task<ActionResult<StaffPartialDetailsDto>> GetStaffPartialDetails(int id)
        {
            var staff = await _unitOfWork.StaffRepository.GetByIdAsync(id);
            if (staff is null)
            {
                return NotFound();
            }
            var mapStaff = _mapper.Map<StaffPartialDetailsDto>(staff);
            return (Ok(mapStaff));
        }


        [HttpPost]
        public async Task<ActionResult<Staff>> CreateNewStaff([FromBody] StaffForCreationDto staffCreationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var staffEntity = _mapper.Map<Staff>(staffCreationDto);
                await _unitOfWork.StaffRepository.Create(staffEntity);
                await _unitOfWork.SaveAsync();
                var staffDto = _mapper.Map<Staff>(staffEntity);
                return CreatedAtAction("GetStaffById", new { id = staffDto.Id }, staffDto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating a new staff member. {ex.Message}");

            }
        }

        //Working
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            try
            {
                var staffToDelete = await _unitOfWork.StaffRepository.GetByIdAsync(id);
                var staffId = _unitOfWork.StaffRepository.IsExist(id);
                if (staffId is false)
                {
                    return NotFound("Staff Id cannot be found!");
                }
                _unitOfWork.StaffRepository.Delete(staffToDelete);
                await _unitOfWork.SaveAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting Staff");

            }
        }
    }
}
