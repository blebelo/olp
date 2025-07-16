using Abp.Domain.Entities.Auditing;
using OnlineLearningPlatform.Authorization.Users;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineLearningPlatform.Domain.Entities
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
        public string Bio { get; set; }
        public long UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
