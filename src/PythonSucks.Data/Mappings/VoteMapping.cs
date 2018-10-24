using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PythonSucks.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PythonSucks.Data.Mappings
{
    public class VoteMapping : BaseMapping<Vote>
    {
        public override void Configure(EntityTypeBuilder<Vote> builder)
        {
            base.Configure(builder);
            builder.Property(m => m.IdentityUserId).IsRequired();
            builder.HasOne(typeof(IdentityUser)).WithMany().HasForeignKey("IdentityUserId");
            builder.Property(m => m.ReasonId).IsRequired();
            builder.HasOne(m => m.Reason).WithMany(m => m.Votes).HasForeignKey(m => m.ReasonId);
        }
    }
}
