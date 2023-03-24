using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using StaffManagementPlatfromAPI.Domain.Models;
using StaffManagementPlatfromAPI.Domain.Repositories.UnitOfWork;
using System.Collections.Generic;

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
        public async Task<ActionResult> GetAll()
        {
           var department =  await _unitOfWork.Department.GetAllAsync();

            return Ok(department);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
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
            var description = _unitOfWork.Department.GetDepartmentDescription(id);
            return Ok(description);
        }


        [HttpGet("staffs")]
        public ActionResult GetDepartmentWithStaff(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }
            var departmentWitStaff = _unitOfWork.Department.GetDepartmentWithStaff();
            return Ok(departmentWitStaff);
        }

        //[HttpPost]
        //public IActionResult CreateDepartment(Department department)
        //{
        //    _unitOfWork.Department.Create(department);
        //}


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
    }
}
