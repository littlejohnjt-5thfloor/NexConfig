using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Data.Config
{
    public class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(p => p.DiscountCharges).HasColumnType("Money");
            builder.Property(p => p.DiscountExtraServices).HasColumnType("Money");
            builder.Property(p => p.DiscountTimePasses).HasColumnType("Money");
            builder.Property(p => p.Price).HasColumnType("Money");
            builder.Property(p => p.SignUpFee).HasColumnType("Money");
        }
    }
}
