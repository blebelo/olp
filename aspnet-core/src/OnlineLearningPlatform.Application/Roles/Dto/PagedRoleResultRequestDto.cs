﻿using Abp.Application.Services.Dto;

namespace OnlineLearningPlatform.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

