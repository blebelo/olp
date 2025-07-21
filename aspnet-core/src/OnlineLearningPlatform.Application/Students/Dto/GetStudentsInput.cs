using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace OnlineLearningPlatform.Students.Dto
{
    public class GetStudentsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
        public string AcademicLevel { get; set; }
    }
}
