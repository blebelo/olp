using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLearningPlatform.Domain.Person;

namespace OnlineLearningPlatform.Domain.Students
{
    public class Student : Persons
    {
        public string StudentId { get; set; }
        public DateTime EnrollmentDate { get; set; } = DateTime.UtcNow;
    }
}
