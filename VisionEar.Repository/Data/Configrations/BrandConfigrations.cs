using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionEar.Core.Entities;

namespace VisionEar.Repository.Data.Configrations
{
    public class BrandConfigrations : IEntityTypeConfiguration<Brands>
    {
        public void Configure(EntityTypeBuilder<Brands> builder)
        {
            builder.Property(B=>B.brand_name).IsRequired()
                                       .HasMaxLength(100);
        }
    }
}
