﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TypeLibrary.Models.Models.Data;

namespace TypeLibrary.Models.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<CategoryDm>
    {
        public void Configure(EntityTypeBuilder<CategoryDm> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired();
            builder.Property(p => p.Description).HasColumnName("Description").IsRequired(false);
            builder.Property(p => p.CompanyId).HasColumnName("CompanyId").IsRequired(false).HasDefaultValue(null);
            builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy").IsRequired();
            builder.Property(p => p.Created).HasColumnName("Created").IsRequired();
            builder.Property(p => p.UpdatedBy).HasColumnName("UpdatedBy").IsRequired(false).HasDefaultValue(null);
            builder.Property(p => p.Updated).HasColumnName("Updated").IsRequired(false).HasDefaultValue(null);
            
        }
    }
}