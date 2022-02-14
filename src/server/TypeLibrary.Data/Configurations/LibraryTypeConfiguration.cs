﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TypeLibrary.Data.Models;

namespace TypeLibrary.Data.Configurations
{
    public class LibraryTypeConfiguration : IEntityTypeConfiguration<LibraryTypeLibDm>

    {
        public void Configure(EntityTypeBuilder<LibraryTypeLibDm> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("LibraryType");
            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.ParentId).HasColumnName("ParentId");
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired();
            builder.Property(p => p.Version).HasColumnName("Version").IsRequired();
            builder.Property(p => p.FirstVersionId).HasColumnName("FirstVersionId").IsRequired();
            builder.Property(p => p.Iri).HasColumnName("Iri").IsRequired(false).HasDefaultValue(null);
            builder.Property(p => p.Aspect).HasColumnName("Aspect").IsRequired().HasConversion<string>();
            builder.Property(p => p.PurposeId).HasColumnName("PurposeId").IsRequired(false);
            builder.Property(p => p.Description).HasColumnName("Description").IsRequired(false).HasDefaultValue(null);
            builder.Property(p => p.UpdatedBy).HasColumnName("UpdatedBy").IsRequired(false).HasDefaultValue(null);
            builder.Property(p => p.Updated).HasColumnName("Updated").IsRequired(false).HasDefaultValue(null);
            builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy").IsRequired().HasDefaultValue("Unknown");
            builder.Property(p => p.Created).HasColumnName("Created").IsRequired().HasDefaultValue(DateTime.MinValue.ToUniversalTime());

            builder.HasOne(x => x.Parent).WithMany(y => y.Children).HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Purpose).WithMany(y => y.LibraryTypes).HasForeignKey(x => x.PurposeId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Rds).WithMany(y => y.LibraryTypes).HasForeignKey(x => x.RdsId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Collections).WithMany(y => y.Types).UsingEntity<Dictionary<string, object>>("LibraryType_Collection",
                x => x.HasOne<CollectionLibDm>().WithMany().HasForeignKey("CollectionId"),
                x => x.HasOne<LibraryTypeLibDm>().WithMany().HasForeignKey("LibraryTypeId"),
                x => x.ToTable("LibraryType_Collection"));
        }
    }
}
