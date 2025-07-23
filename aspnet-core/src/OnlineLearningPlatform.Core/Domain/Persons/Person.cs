using Abp.Domain.Entities.Auditing;
using OnlineLearningPlatform.Authorization.Users;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLearningPlatform.Domain.Persons
{

    public abstract class Person : FullAuditedEntity<Guid>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [NotMapped]
        public string UserName { get; set; }
        public string Email { get; set; }
        [NotMapped]
        public string Password { get; set; }
        public virtual User UserAccount { get; set; }
    }
}
