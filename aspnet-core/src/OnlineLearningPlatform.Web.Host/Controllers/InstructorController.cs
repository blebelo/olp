//using Microsoft.AspNetCore.Mvc;
//using OnlineLearningPlatform.Controllers;
//using OnlineLearningPlatform.Domain.Instructor;
//using OnlineLearningPlatform.InstructorsApp;
//using System.Threading.Tasks;

//namespace OnlineLearningPlatform.Web.Host.Controllers
//{
//    [Route("api/instructors")]
//    public class InstructorController : OnlineLearningPlatformControllerBase
//    {
//        private readonly InstructorAppService _instructorAppService;

//        public InstructorController(InstructorAppService instructorAppService)
//        {
//            _instructorAppService = instructorAppService;
//        }

//        // POST: api/instructors/signup
//        [HttpPost("signup")]
//        public async Task<IActionResult> SignUp([FromBody] InstructorDto input)
//        {
//            await _instructorAppService.CreateInstructorAsync(input);
//            return Ok(new { Message = "Instructor registered successfully." });
//        }
//    }
//}
