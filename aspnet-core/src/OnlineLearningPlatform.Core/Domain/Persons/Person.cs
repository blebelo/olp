using System;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities.Auditing;
using OnlineLearningPlatform.Authorization.Users;

namespace OnlineLearningPlatform.Domain.Persons
{

    public class Person : FullAuditedEntity<Guid>
    {
       public long UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }

    }
}