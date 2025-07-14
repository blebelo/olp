using Microsoft.AspNetCore.Identity;
using OnlineLearningPlatform.Domain.Persons;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Domain.Instructors
{
    public class Instructor: Person
    {
        public string Bio { get; set; }

    }
}
