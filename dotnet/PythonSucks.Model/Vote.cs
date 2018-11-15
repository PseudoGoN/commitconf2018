using Microsoft.AspNetCore.Identity;
using PythonSucks.Repository;
using System;

namespace PythonSucks.Model
{
    public class Vote : BaseEntity
    {
        public string IdentityUserId { get; set; }
        
        public Guid ReasonId { get; set; }

        public virtual Reason Reason { get; set; }
    }
}
