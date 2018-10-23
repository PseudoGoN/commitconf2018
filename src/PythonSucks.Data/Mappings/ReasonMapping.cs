using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PythonSucks.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PythonSucks.Data.Mappings
{
    public class ReasonMapping : BaseMapping<Reason>
    {
        public override void Configure(EntityTypeBuilder<Reason> builder)
        {
            base.Configure(builder);
            builder.Property(m => m.HaterId).IsRequired();

            builder.HasOne<Hater>(m=>m.Hater).WithMany(m => m.Reasons).HasForeignKey(m => m.HaterId);

            builder.Property(m => m.RageLevel).IsRequired();
            builder.Property(m => m.Title).IsRequired();
            builder.HasData(
                new Reason()
                {
                    Id = new Guid("59a7731a-a094-4550-a62e-9782dbc05bd6"),
                    Description = "Python grammar is not as easy as people say.",
                    HaterId = new Guid("59a7731a-a094-4550-a62e-9782dbc05bd6"),
                    RageLevel = 2,
                    Title = "Grammar",
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow
                },
                new Reason()
                {
                    Id = Guid.NewGuid(),
                    Description = "No interfaces! WTF!",
                    HaterId = new Guid("59a7731a-a094-4550-a62e-9782dbc05bd6"),
                    RageLevel = 5,
                    Title = "Interfaces",
                    CreateDate = DateTime.UtcNow,
                    UpdateDate = DateTime.UtcNow
                }
            );
        }
    }
}
