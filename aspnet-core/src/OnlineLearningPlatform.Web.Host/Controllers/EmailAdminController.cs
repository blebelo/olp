using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.EmailService;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Web.Host.Controllers
{
    [Route("api/email")]
    [ApiController]
    public class EmailAdminController : ControllerBase
    {
        private readonly EmailAdminService _emailAdminService;

        public EmailAdminController(EmailAdminService emailAdminService)
        {
            _emailAdminService = emailAdminService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendEmail([FromBody] SendEmailDto dto)
        {
            await _emailAdminService.SendEmail(dto.Subject, dto.ToEmail, dto.Username, dto.Message);
            return Ok(new { message = "Email sent (if no error)!" });
        }
    }

    public class SendEmailDto
    {
        public string Subject { get; set; }
        public string ToEmail { get; set; }
        public string Username { get; set; }
        public string Message { get; set; }
    }
}
