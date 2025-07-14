using Abp.Domain.Entities.Auditing;
using OnlineLearningPlatform.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLearningPlatform.Domain.Person
{

    public class Persons : FullAuditedEntity<Guid>
    {
       public long UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }


    }
}



