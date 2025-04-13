using Demo.DataAccess.Models.DepartmentModels;
using Demo.DataAccess.Models.EmployeeModels;
using Demo.DataAccess.Models.SharedModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Configuration
{
    class EmployeeConfiguration : BaseEntityConfiguration<Employee>, IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).HasColumnType("varchar(50)");
            builder.Property(e => e.Address).HasColumnType("varchar(150)");
            builder.Property(e => e.Salary).HasColumnType("Decimal(10,2)");

            builder.Property(e => e.Email).HasColumnType("varchar(50)");
            builder.Property(e => e.PhoneNumber).HasColumnType("varchar(11)");
            builder.Property(e => e.Gender).HasConversion
               (
               valueToAddInDb => valueToAddInDb.ToString(),
               valueToReadFromDb => (Gender)Enum.Parse(typeof(Gender), valueToReadFromDb)
               
               ).HasColumnType("varchar(6)");

            builder.Property(e => e.EmployeeType).HasConversion
                (
                valueToAddInDb => valueToAddInDb.ToString(),
                valueToReadFromDb => (EmployeeType)Enum.Parse(typeof(EmployeeType), valueToReadFromDb)
                ).HasColumnType("varchar(8)"); ;
            base.Configure(builder);
        }
    }
}
