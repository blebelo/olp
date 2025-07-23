using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;

namespace OnlineLearningPlatform.Web.Host.Swagger
{
    /// <summary>
    /// Enables Swagger to properly display file upload fields in endpoints using [FromForm] and IFormFile.
    /// This adds multipart/form-data encoding to support accurate UI rendering and avoids schema generation errors.
    /// </summary>
    public class AddFileUploadParamsOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.RequestBody == null ||
                !operation.RequestBody.Content.ContainsKey("multipart/form-data"))
            {
                return;
            }

            var content = operation.RequestBody.Content["multipart/form-data"];

            // Add encoding hints for known upload fields
            content.Encoding = new Dictionary<string, OpenApiEncoding>
            {
                { "file", new OpenApiEncoding { ContentType = "application/octet-stream" } },
                { "title", new OpenApiEncoding { ContentType = "text/plain" } },
                { "description", new OpenApiEncoding { ContentType = "text/plain" } }
                // Add other form field names if needed (e.g. lessonId, courseId)
            };
        }
    }
}