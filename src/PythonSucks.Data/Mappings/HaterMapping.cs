using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PythonSucks.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PythonSucks.Data.Mappings
{
    public class HaterMapping : BaseMapping<Hater>
    {
        public override void Configure(EntityTypeBuilder<Hater> builder)
        {
            base.Configure(builder);
            builder.Property(m => m.ChildTrauma).IsRequired();
            builder.Property(m => m.Name).IsRequired();

            //seed
            builder.HasData(
            new Hater()
            {
                Id = new Guid("59a7731a-a094-4550-a62e-9782dbc05bd6"),
                ChildTrauma = "His bike was pink.",
                Name = "Gonzalo",
                Surname = "Rubio",
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            },
            new Hater()
            {
                Id = Guid.NewGuid(),
                ChildTrauma = "He saw his parents in bed.",
                Name = "Jorge",
                Surname = "Jardines",
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            });
        }
    }
}
