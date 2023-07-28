
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace NZWalks.API.Controllers
{
    [Route("api/[Controller]")]

    [ApiController]
   
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] StudentNames = new string[] { "Himanshu", "Abhishek" ,"Gaurav","Prashant" };
            return Ok(StudentNames);    
        }
    }
}