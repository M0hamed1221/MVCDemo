using Microsoft.EntityFrameworkCore;
using Demo.DataAccess.Models.SharedModel; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.DataAccess.Data.Configuration
{
    internal class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(dept => dept.CreatedOn).HasDefaultValueSql("GETDATE()");
            /*If it null the default value will be assgined*/
            builder.Property(dept => dept.LastModifiedOn).HasComputedColumnSql("GETDATE()");
        }
    }
}
