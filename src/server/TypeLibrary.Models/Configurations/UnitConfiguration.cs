﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TypeLibrary.Models.Data;

namespace TypeLibrary.Models.Configurations
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.ToTable("Unit");
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired();
            builder.Property(p => p.Description).HasColumnName("Description").IsRequired(false);
            builder.Property(p => p.Iri).HasColumnName("Iri").IsRequired(false);
        }
    }
}