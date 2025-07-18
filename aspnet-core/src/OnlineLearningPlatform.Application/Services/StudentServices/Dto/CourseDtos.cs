using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using OnlineLearningPlatform.Domain.Courses;
using OnlineLearningPlatform.Domain.Students;

namespace OnlineLearningPlatform.Services.StudentServices.Dto
{
    [AutoMap(typeof(Course))]
    public class CourseDtos : EntityDto<Guid>
    {
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Description { get; set; }
        public bool IsPublished { get; set; }
        public string Instructor { get; set; }
    }
}
