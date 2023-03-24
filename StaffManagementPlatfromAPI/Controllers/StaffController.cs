using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StaffManagementPlatfromAPI.Domain.Repositories.UnitOfWork;

namespace StaffManagementPlatfromAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
      private readonly  IUnitOfWork _unitOfWork;
        public StaffController(IUnitOfWork _unitOfWork)
        {
            _unitOfWork = _unitOfWork ?? throw new ArgumentNullException();
        }
    }
}
