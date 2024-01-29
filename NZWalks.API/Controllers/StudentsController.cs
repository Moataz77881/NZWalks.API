using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult HetAllStudents() {

            string[] studentName = { "moataz", "mohab", "mohamed" };
            return Ok(studentName);
        }
    }
}
