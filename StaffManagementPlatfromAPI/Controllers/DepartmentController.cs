using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StaffManagementPlatfromAPI.Domain.Models;
using StaffManagementPlatfromAPI.Domain.Repositories.UnitOfWork;

namespace StaffManagementPlatfromAPI.Controllers
{
    [Route("api/departments")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        [HttpGet]
        public async Task<ActionResult> GetAllDepartment()
        {
           var department =  await _unitOfWork.Department.GetAllAsync();

            return Ok(department);
        }

        [HttpGet("{id}")]
        public ActionResult GetDepartmentById(int id)
        {
            var getWithId = _unitOfWork.Department.GetById(id);
            return Ok(getWithId);
        }

        [HttpGet("{id}/description")]
        public ActionResult GetDepartmentDescription(int id)
        {
            if(!_unitOfWork.Department.IsExist(id))
            {
                return NotFound();
            }
            var description = _unitOfWork.Department.DepartmentDescription(id);
            return Ok(description);
        }


        [HttpGet("staffs")]
        public ActionResult GetDepartmentWithStaff()
        {
            var departmentWitStaff = _unitOfWork.Department.DepartmentWithStaff();
            return Ok(departmentWitStaff);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] Department department)
        {
            try
            {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(department is null)
            {
                return BadRequest("Department object is null");
            }
          await  _unitOfWork.Department.Create(department);
            return CreatedAtAction(nameof(GetDepartmentById), 
                new {id = department.Id},department);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }

        }


        [HttpPut("{id}/description")]
        public ActionResult UpdateDepartmentDescription(int id,[FromBody] string description)
        {
             _unitOfWork.Department.GetById(id);
            if (string.IsNullOrWhiteSpace(description))
            {
                return NotFound();
            }
            _unitOfWork.Save();
            return Ok();
        }


        [HttpPatch("{id}/description")]
        public IActionResult PartialUpdateDescription(int id, JsonPatchDocument<Department> patchDescription, string description)
        {
         var department =  _unitOfWork.Department.GetById(id);
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
            _unitOfWork.Department.Update(department);
            try
            {
                _unitOfWork.Save(); 
            }
            catch (DbUpdateConcurrencyException) 
            {
                if (!_unitOfWork.Department.IsExist(id))
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

        [HttpDelete]
        public IActionResult DeleteDepartment(int id)
        {
            try
            {
                var departmentToDelete = _unitOfWork.Department.GetById(id);

                /*
                     if (departmentToDelete == null)
                        {
                            return NotFound();
                        }
                 */
                var departmentId = _unitOfWork.Department.IsExist(id);
                if (departmentId is false)
                {
                    return NotFound("Department Id cannot be found!");
                }
                _unitOfWork.Department.Delete(departmentToDelete);
                _unitOfWork.Save();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting department");

            }
        }

        /*
         [HttpDelete("{id}")]
public IActionResult DeleteDepartment(int id)
{
    try
    {
        var departmentToDelete = _unitOfWork.Department.GetById(id);
        if (departmentToDelete == null)
        {
            return NotFound();
        }

        _unitOfWork.Department.Delete(departmentToDelete);
        _unitOfWork.Save();

        return NoContent();
    }
    catch (Exception ex)
    {
        return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting department");
    }
}

         */
    }
}
