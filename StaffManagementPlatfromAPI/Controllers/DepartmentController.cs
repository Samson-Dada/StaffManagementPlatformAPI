using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.DataAccess.Context;
using StaffManagementPlatfromAPI.Domain.Entities;
using StaffManagementPlatfromAPI.Domain.Models;
using StaffManagementPlatfromAPI.Domain.Repositories.ModelRepository;
using StaffManagementPlatfromAPI.Domain.Repositories.UnitOfWork;

namespace StaffManagementPlatfromAPI.Controllers
{/// <summary>
/// Department Controller that hadles all request response cylce for all HTTPS Verb that is use
/// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/departments")]
  
    public class DepartmentController : ControllerBase
    {

        private readonly ApplicationContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        /// <summary>
        /// The unit of work is use to handle data logic implimentation layer between the entities of the project,
        /// The mapper is used to map object of entities and object of model to abstract non needed data from user
        /// </summary>
        /// <param name="unitOfWork">UnitOfWork</param>
        /// <param name="mapper"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public DepartmentController(IUnitOfWork unitOfWork, 
            IMapper mapper,
            ApplicationContext context)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context;
        }

        /* Working */
        /// <summary>
        /// Get All Departments
        /// </summary>
        /// <returns>Return a list of Department</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentGetDto>>> GetAllDepartment()
        {
           var allDepartment =  await _unitOfWork.DepartmentRepository.GetAllAsync();
            var departmentMapp = _mapper.Map<IEnumerable<DepartmentGetDto>>(allDepartment);
            return Ok(departmentMapp);
        }

        /// <summary>
        /// Get a Department by ID
        /// </summary>
        /// <param name="id">The id is the Department to get</param>
        /// <returns>An ActionResult  of department ID</returns>
        /// <response code="200">Returns the requested Staff</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet("{id}", Name ="GetDepartmentById")]
        public IActionResult GetDepartmentById(int id)
        {
            var departmentById = _unitOfWork.DepartmentRepository.GetByIdAsync(id);
            if(departmentById == null)
            {
                return NotFound("Id does not exits!");
            }
            var map = _mapper.Map<DepartmentGetDto>(departmentById);
            return Ok(map);
        }

        /// <summary>
        /// Get department descriptions
        /// </summary>
        /// <param name="id">The id of the department to get the description</param>
        /// <returns>An ActionResult of department Description</returns>

        [HttpGet("{id}/descriptions")]
        public IActionResult GetDepartmentDescription(int id)
        {
            if(!_unitOfWork.DepartmentRepository.IsExist(id))
            {
                return NotFound();
            }
            var description = _unitOfWork.DepartmentRepository.DepartmentDescription(id);
            return Ok(description);
        }

        /*working partially, generating us expected id*/
        /// <summary>
        /// Create or post new Department with name and description
        /// </summary>
        /// <param name="departmentCreateDto">The departments name and description to post</param>
        /// <returns>ActionResult of the Department ot create</returns>
        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentCreateDto departmentCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var department = _mapper.Map<Department>(departmentCreateDto);

                await _unitOfWork.DepartmentRepository.Create(department);
                await _unitOfWork.SaveAsync();
                var createdDepartmentDto = _mapper.Map<DepartmentGetDto>(department);

                return CreatedAtAction(nameof(GetDepartmentById), new { id = createdDepartmentDto.Id }, createdDepartmentDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create department: {ex.Message}");
            }
        }

        /// <summary>
        /// Update the Department, name and Description
        /// </summary>
        /// <param name="id">Department ID</param>
        /// <param name="departmentDto">Department to updatr</param>
        /// <returns>ACtionResult of the department to update</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, DepartmentGetDto departmentDto)
        {
            try
            {

                var department = await _unitOfWork.DepartmentRepository.GetByIdAsync(id);

                if (department is null)
                {
                    return NotFound();
                }
                _mapper.Map(departmentDto, department);
                departmentDto.Name = departmentDto.Name;
                departmentDto.Description = departmentDto.Description;
                _unitOfWork.DepartmentRepository.Update(department);
                await _unitOfWork.SaveAsync();
                var updateDepartment = _mapper.Map<DepartmentGetDto>(department);
                return Ok(updateDepartment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the department. {ex.Message}");
            }
        }

        /// <summary>
        /// Update the entire description of the provided ID
        /// </summary>
        /// <param name="id">Department ID</param>
        /// <param name="description">Description to update to</param>
        /// <returns>An ActionResult of the Description</returns>
        /*Not Working*/
        [HttpPut("{id}/descriptions")]
        public async Task<IActionResult> UpdateDepartmentDescription(int id, [FromBody] string description)
        {
            try
            {
                var department = await _unitOfWork.DepartmentRepository.GetByIdAsync(id);
                if (department == null)
                {
                    return NotFound();
                }
                if (string.IsNullOrWhiteSpace(description))
                {
                    return BadRequest("Description cannot be empty.");
                }
                department.Description = description;
                _unitOfWork.DepartmentRepository.Update(department);
                await _unitOfWork.SaveAsync();
                var updatedDto = _mapper.Map<DepartmentDto>(department);
                return Ok(updatedDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update department. {ex.Message}");
            }
        }

        /// <summary>
        ///  Update the Existing descrption of the id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="patchDescription"> Description to add</param>
        /// <param name="description">Existing Description</param>
        /// <returns> An ActionResult of the update description</returns>
        /*Not Working*/
        [HttpPatch("{id}/descriptions")]
        public async Task<IActionResult> PartialUpdateDescription(int id, JsonPatchDocument<Department> patchDescription, string description)
        {
         var department = await  _unitOfWork.DepartmentRepository.GetByIdAsync(id);
            if (department is null)
            {
                return NotFound();
            }
            patchDescription.ApplyTo(department, ModelState);
            if(string.IsNullOrWhiteSpace(description))
            {
                return NotFound();
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _unitOfWork.DepartmentRepository.Update(department);
            try
            {
              await  _unitOfWork.SaveAsync(); 
            }
            catch (DbUpdateConcurrencyException) 
            {
                if (!_unitOfWork.DepartmentRepository.IsExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            
            }
            return Ok(department);
        }
        /// <summary>
        /// Delete a department with ID
        /// </summary>
        /// <param name="id">Department ID to delete</param>
        /// <returns>ActionResult of the department to delete</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
                var departmentToDelete = await _unitOfWork.DepartmentRepository.GetByIdAsync(id);


            if (departmentToDelete == null)
            {
                return NotFound();
            }

            try
            {
                var departmentId = _unitOfWork.DepartmentRepository.IsExist(id);
                if (departmentId is false)
                {
                    return NotFound("Department Id cannot be found!");
                }
                _unitOfWork.DepartmentRepository.Delete(departmentToDelete);
                await _unitOfWork.SaveAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting department");

            }
        }

        /// <summary>
        /// Get list of staff from a department using department Id
        /// </summary>
        /// <param name="id">Department id</param>
        /// <returns>An ActionResult StaffDto, to retrieve list of staff from department</returns>
        [HttpGet("{id}/staffs")]
        public async Task<IActionResult> GetStaffInDepartment(int id)
        {
            var staffs = await _unitOfWork.StaffRepository.GetStaffByDepartmentId(id);
            var map = _mapper.Map<IEnumerable<StaffGetDto>>(staffs);
            return Ok(map);
        }


        /// <summary>
        /// Create a new Staff with the existing department id
        /// </summary>
        /// <param name="departmentId"> Enter department id</param>
        /// <param name="staffForCreationDto">Staff data source to create new staff</param>
        /// <returns>An ActionResult of new created Staff of deaprtment id</returns>
        [HttpPost("{id}/staffs")]
        public async Task<IActionResult> CreateDepartmentWithStaff(int departmentId, [FromBody]
        StaffForCreationDto staffForCreationDto)
        {
            var staff = _mapper.Map<Staff>(staffForCreationDto);
            var department = await _unitOfWork.DepartmentRepository.CreateStaffWithDepartmentId(departmentId);
            var mappStaff = _mapper.Map<StaffGetDto>(staff);
            department.Staffs.Add(staff);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetStaffInDepartment),
                new { departmentId, mappStaff.Id }, mappStaff);
        }
    }
}
