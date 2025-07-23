using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineLearningPlatform.Web.Host.Controllers.Dtos
{
    public class UploadLessonVideoRequestDto
    {
        [Required]
        [FromForm(Name = "file")]
        public IFormFile File { get; set; }

        [FromForm(Name = "title")]
        public string Title { get; set; }

        [FromForm(Name = "description")]
        public string Description { get; set; }
    }
}