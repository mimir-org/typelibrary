using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TypeLibrary.Data.Models;

namespace TypeLibrary.Data.Configurations
{
    public class InterfaceConfiguration : IEntityTypeConfiguration<InterfaceLibDm>
    {
        public void Configure(EntityTypeBuilder<InterfaceLibDm> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Interface");
            builder.Property(p => p.Id).HasColumnName("Id").IsRequired().HasMaxLength(127);
            builder.Property(p => p.Iri).HasColumnName("Iri").IsRequired().HasMaxLength(255);
            builder.Property(p => p.ContentReferences).HasColumnName("ContentReferences");
            builder.Property(p => p.Deleted).HasColumnName("Deleted").IsRequired().HasDefaultValue(0);
            builder.Property(p => p.Name).HasColumnName("Name").IsRequired().HasMaxLength(63);
            builder.Property(p => p.RdsCode).HasColumnName("RdsCode").IsRequired().HasMaxLength(127);
            builder.Property(p => p.RdsName).HasColumnName("RdsName").IsRequired().HasMaxLength(127);
            builder.Property(p => p.PurposeName).HasColumnName("PurposeName").HasMaxLength(127);
            builder.Property(p => p.ParentId).HasColumnName("ParentId").HasMaxLength(127);
            builder.Property(p => p.Version).HasColumnName("Version").IsRequired().HasMaxLength(7);
            builder.Property(p => p.FirstVersionId).HasColumnName("FirstVersionId").IsRequired().HasMaxLength(127);
            builder.Property(p => p.Aspect).HasColumnName("Aspect").IsRequired().HasConversion<string>().HasMaxLength(31);
            builder.Property(p => p.Description).HasColumnName("Description").HasDefaultValue(null).HasMaxLength(511);
            builder.Property(p => p.Created).HasColumnName("Created").IsRequired().HasDefaultValue(DateTime.MinValue.ToUniversalTime()).HasMaxLength(63);
            builder.Property(p => p.CreatedBy).HasColumnName("CreatedBy").IsRequired().HasMaxLength(63);

            builder.HasOne(x => x.Parent).WithMany(y => y.Children).HasForeignKey(x => x.ParentId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Terminal).WithMany(y => y.Interfaces).HasForeignKey(x => x.TerminalId).OnDelete(DeleteBehavior.NoAction);
            builder.Property(p => p.TerminalId).HasColumnName("Interface_TerminalId");
        }
    }
}