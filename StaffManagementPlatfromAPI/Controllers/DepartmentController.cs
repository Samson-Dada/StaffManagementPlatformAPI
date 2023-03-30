using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.Domain.Entities;
using StaffManagementPlatfromAPI.Domain.Models;
using StaffManagementPlatfromAPI.Domain.Repositories.UnitOfWork;

namespace StaffManagementPlatfromAPI.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork= unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
           _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetAllDepartment()
        {
           var department =  await _unitOfWork.DepartmentRepository.GetAllAsync();
            var departmentMapp = _mapper.Map<IEnumerable<DepartmentDto>>(department);
            return Ok(departmentMapp);
        }

        [HttpGet("{id}", Name ="GetDepartmentById")]
        public IActionResult GetDepartmentById(int id)
        {
            var departmentById = _unitOfWork.DepartmentRepository.GetById(id);
            if(departmentById == null)
            {
                return NotFound("Id does not exits!");
            }
            var map = _mapper.Map<DepartmentDto>(departmentById);
            return Ok(map);
        }

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


        [HttpGet("{id}/staffs")]
        public async Task<ActionResult<IEnumerable<StaffDto>>> GetStaffInDepartment(int id)
        {

            var department = await _unitOfWork.DepartmentRepository.GetById(id);
            if(department is null)
            {
                return NotFound("Department not found");
            }
            var staffInDepartment = await _unitOfWork.StaffRepository.GetStaffByDepartment(department.Id);

            var map = _mapper.Map<IEnumerable<StaffDto>>(staffInDepartment).ToList();
            return Ok(map);
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentDto>> CreateDepartment([FromBody] DepartmentDto departmentDto)
        {
            try
            {
                var department = _mapper.Map<Department>(departmentDto);

              await  _unitOfWork.DepartmentRepository.Create(department);
                 _unitOfWork.Save();
                var createdDepartmentDto = _mapper.Map<DepartmentDto>(department);

                return CreatedAtAction(nameof(GetDepartmentById), new { id = createdDepartmentDto.Id }, createdDepartmentDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create department: {ex.Message}");
            }
        }
         


        [HttpPut("{id}/descriptions")]
        public IActionResult UpdateDepartmentDescription(int id,[FromBody] string description)
        {
             _unitOfWork.DepartmentRepository.GetById(id);
            if (string.IsNullOrWhiteSpace(description))
            {
                return NotFound();
            }
            _unitOfWork.Save();
            return Ok();
        }


        [HttpPatch("{id}/descriptions")]
        public async Task<IActionResult> PartialUpdateDescription(int id, JsonPatchDocument<Department> patchDescription, string description)
        {
         var department = await  _unitOfWork.DepartmentRepository.GetById(id);
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
                _unitOfWork.Save(); 
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                var departmentToDelete = await _unitOfWork.DepartmentRepository.GetById(id);

                /*
                     if (departmentToDelete == null)
                        {
                            return NotFound();
                        }
                 */
                var departmentId = _unitOfWork.DepartmentRepository.IsExist(id);
                if (departmentId is false)
                {
                    return NotFound("Department Id cannot be found!");
                }
                _unitOfWork.DepartmentRepository.Delete(departmentToDelete);
                _unitOfWork.Save();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting department");

            }
        }
    }
}
