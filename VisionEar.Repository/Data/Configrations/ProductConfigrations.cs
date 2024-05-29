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
    public class ProductConfigrations : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.Property(p=>p.product_name).IsRequired();
            builder.Property(p => p.description).IsRequired();
            builder.Property(p => p.price).IsRequired()
                                          .HasColumnType("decimal(16,2)");
            builder.Property(p => p.picture_url).IsRequired();
            builder.HasOne(p => p.Brands)
                .WithMany()
                .HasForeignKey(p=>p.brand_id);
            builder.HasOne(p=>p.Categories) 
                .WithMany()
                .HasForeignKey(p=>p.category_id);
            builder.Property(p=>p.code)
                .ValueGeneratedOnAdd();



        }
    }
}
