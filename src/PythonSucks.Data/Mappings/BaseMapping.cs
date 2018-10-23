using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PythonSucks.Model;
using PythonSucks.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PythonSucks.Data.Mappings
{
    public class BaseMapping<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).IsRequired();
            builder.Property(m => m.CreateDate).IsRequired();
            builder.Property(m => m.UpdateDate).IsRequired();
        }
    }
}
