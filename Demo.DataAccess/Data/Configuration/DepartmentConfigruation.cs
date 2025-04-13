using Demo.DataAccess.Models.DepartmentModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Configuration
{
    class DepartmentConfigruation : BaseEntityConfiguration<Department>,IEntityTypeConfiguration<Department>
    {
        public new void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(dept => dept.Id).UseIdentityColumn(10,10);
            builder.Property(dept => dept.Name).HasColumnType("Varchar(20)");
            builder.Property(dept => dept.Code).HasColumnType("Varchar(20)");
            base.Configure(builder);


        }
    }
}
