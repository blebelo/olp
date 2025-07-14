using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace OnlineLearningPlatform.Services.StudentServices.DTOs
{
    public class StudentDTO : EntityDto<Guid>
    {
        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
    }
}
