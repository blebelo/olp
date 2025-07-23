using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineLearningPlatform.Courses;
using OnlineLearningPlatform.Lessons.Dto;
using OnlineLearningPlatform.Web.Host.S3FileStorage;
using OnlineLearningPlatform.Web.Host.Controllers.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/courses")]
[ApiController]
public class CourseLessonUploadController : ControllerBase
{
    private readonly ICourseAppService _courseAppService;
    private readonly IFileStorageService _fileStorageService;

    public CourseLessonUploadController(
        ICourseAppService courseAppService,
        IFileStorageService fileStorageService)
    {
        _courseAppService = courseAppService;
        _fileStorageService = fileStorageService;
    }

    [HttpPost("{courseId}/lessons/upload")]
    public async Task<IActionResult> UploadLessonVideo(Guid courseId, [FromForm] UploadLessonVideoRequestDto input)
    {
        if (input.File == null || input.File.Length == 0)
            return BadRequest("No video file was provided.");

        var lessonId = Guid.NewGuid();
        var s3Key = $"courses/{courseId}/lessons/{lessonId}/video.mp4";
        var bucketName = "olp-s3";

        using var stream = input.File.OpenReadStream();
        await _fileStorageService.UploadAsync(bucketName, s3Key, stream);

        var videoUrl = $"https://{bucketName}.s3.eu-north-1.amazonaws.com/{s3Key}";

        var lessonDto = new LessonDto
        {
            Id = lessonId,
            Title = input.Title,
            Description = input.Description,
            VideoLink = videoUrl,
            IsCompleted = false,
            StudyMaterialLinks = new List<string>()
        };

        await _courseAppService.AddLessonAsync(courseId, lessonDto);
        return Ok(lessonDto);
    }
}