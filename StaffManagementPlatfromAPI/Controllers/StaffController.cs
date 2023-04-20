using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.Domain.Entities;
using StaffManagementPlatfromAPI.Domain.Models;
using StaffManagementPlatfromAPI.Domain.Repositories.UnitOfWork;

namespace StaffManagementPlatfromAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
   // [Authorize]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [ApiController]
    [Route("api/v{version:apiVersion}/staffs")]

    public class StaffController : ControllerBase
    {
      
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        /// <summary>
        /// The unit of work is use to handle data logic implimentation layer between the entities of the project,
        /// The mapper is used to map object of entities and object of model to abstract non needed data from user
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="mapper"></param>
        /// <exception cref="ArgumentNullException"></exception>
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
        /// <summary>
        ///  get a staff fullname by id
        /// </summary>
        /// <param name="id">The id of the staff fullname you want to get</param>
        /// <returns>Returns the requested Staff fullname by id</returns>
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


       /// <summary>
       ///  Get Fullname of a staff
       /// </summary>
       /// <param name="fullNames">The fullname of the staff you want to get</param>
       /// <returns>Returns the requested staff fullname by names</returns>
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
        /// <summary>
        /// Get staff by id 
        /// </summary>
        /// <param name="id">The id of the staff you want to get</param>
        /// <returns>Returns the staff details by ID</returns>
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


        /// <summary>
        /// Create or post a new staff to database
        /// </summary>
        /// <param name="staffCreationDto">Enter basic details of the staff to create </param>
        /// <returns>Return a succesfull or OK after create or post method is done</returns>
        /// 

        /*[HttpPost]
        public async Task<ActionResult<Staff>> CreateNewStaff([FromBody] Staff staff)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
               await _unitOfWork.StaffRepository.Create(staff);
               await _unitOfWork.SaveAsync();
                return CreatedAtAction("GetStaffById", new {id =staff.Id},staff );

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating a new staff member. {ex.Message}");

            }
        }
        */



        [HttpPost]
        //Task<ActionResult<PointOfInterestDto>>
        public async Task<ActionResult<Staff>> CreateNewStaff([FromBody] StaffFullDto staffCreationDto)
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

         
        /*

        [HttpPost]
        public async Task<ActionResult> CreateNewStaff(StaffForCreationDto staffCreationDto)
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
                Console.WriteLine($"Error message: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception message: {ex.InnerException.Message}");

                }
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating a new staff member. {ex.Message}");

            }
        }
        */
        /*
        [HttpPost]
        public async Task<ActionResult> CreateNewStaff(StaffForCreationDto staffCreationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var department = await _unitOfWork.DepartmentRepository.GetDepartmentByName(staffCreationDto.DepartmentName);
                if (department == null)
                {
                    return BadRequest($"Department with name {staffCreationDto.DepartmentName} does not exist.");
                }

                var staffEntity = _mapper.Map<Staff>(staffCreationDto);
                staffEntity.DepartmentId = department.Id;

                await _unitOfWork.StaffRepository.Create(staffEntity);
                await _unitOfWork.SaveAsync();

                var staffDto = _mapper.Map<StaffForCreationDto>(staffEntity);
                return CreatedAtAction("GetStaffById", new { id = staffDto.Id }, staffDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error message: {ex.Message}");
                if (ex.InnerException != null)
                {
                    Console.WriteLine($"Inner exception message: {ex.InnerException.Message}");
                }
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while creating a new staff member. {ex.Message}");
            }
        }
        */


        /// <summary>
        ///  Delete a staff provided the ID is entered
        /// </summary>
        /// <param name="id">The ID of the staff you want to delete</param>
        /// <returns>Return no content after a successfull request response cylce is done</returns>
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
