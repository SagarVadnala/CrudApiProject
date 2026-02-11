using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class EmployeeConfiguration :IEntityTypeConfiguration<Customer>
    {
       

        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(e => e.Id); // Set Id as primary key
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(50); // Set maximum length for FirstName  
            builder.Property(e => e.Lastname).IsRequired().HasMaxLength(50); // Set maximum length for LastName
            builder.Property(e => e.Age).IsRequired(); // Make Age required
            builder.Property(e => e.Address).IsRequired().HasMaxLength(200); // Set maximum length for Address
            builder.Property(e => e.Gender).IsRequired().HasMaxLength(10);
        }

    }
}
