using Demo.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Configuration
{
    class DepartmentConfigruation : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(dept => dept.Id).UseIdentityColumn(10,10);
            builder.Property(dept => dept.Name).HasColumnType("Varchar(20)");
            builder.Property(dept => dept.Code).HasColumnType("Varchar(20)");
            builder.Property(dept => dept.CreatedOn).HasDefaultValueSql("GETDATE()");
            /*If it null the default value will be assgined*/
            builder.Property(dept => dept.LastModifiedOn).HasComputedColumnSql("GETDATE()");


        }
    }
}
