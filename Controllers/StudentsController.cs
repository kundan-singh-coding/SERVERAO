using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SWICN.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Student")]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetStudentData()
        {
            return Ok("Access Granted - Students Data");
        }

        [HttpGet("admin")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAdminData()
        {
            return Ok("Access Granted - Admin Data");
        }
    }
}

