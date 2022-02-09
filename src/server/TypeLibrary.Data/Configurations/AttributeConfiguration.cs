﻿using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mimirorg.Common.Converters;
using Mimirorg.TypeLibrary.Models.Data;

namespace TypeLibrary.Data.Configurations
{
    public class AttributeConfiguration : IEntityTypeConfiguration<AttributeLibDm>
    {
        public void Configure(EntityTypeBuilder<AttributeLibDm> builder)
        {
            var stringComparer = new StringHashSetValueComparer();
            var stringConverter = new StringHashSetValueConverter();

            builder.HasKey(x => x.Id);
            builder.ToTable("Attribute");
            builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
            builder.Property(p => p.Entity).HasColumnName("Entity").IsRequired();
            builder.Property(p => p.Aspect).HasColumnName("Aspect").IsRequired().HasConversion<string>();
            builder.Property(p => p.SelectValuesString).HasColumnName("SelectValuesString").IsRequired(false);
            builder.Property(p => p.SelectType).HasColumnName("Select").IsRequired().HasConversion<string>();
            builder.Property(p => p.Discipline).HasColumnName("Discipline").IsRequired().HasConversion<string>();
            builder.Property(p => p.Tags).HasColumnName("Tags").IsRequired(false).HasConversion(stringConverter, stringComparer);

            builder.HasOne(x => x.Condition).WithMany(y => y.Attributes).HasForeignKey(x => x.ConditionId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Qualifier).WithMany(y => y.Attributes).HasForeignKey(x => x.QualifierId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Source).WithMany(y => y.Attributes).HasForeignKey(x => x.SourceId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Format).WithMany(y => y.Attributes).HasForeignKey(x => x.FormatId).OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.Units).WithMany(y => y.Attributes).UsingEntity<Dictionary<string, object>>("Attribute_Unit",
                x => x.HasOne<UnitLibDm>().WithMany().HasForeignKey("UnitId"),
                x => x.HasOne<AttributeLibDm>().WithMany().HasForeignKey("AttributeId"),
                x => x.ToTable("Attribute_Unit")
            );

            builder.HasMany(x => x.Nodes).WithMany(y => y.Attributes).UsingEntity<Dictionary<string, object>>("Attribute_Node",
                x => x.HasOne<NodeLibDm>().WithMany().HasForeignKey("NodeId"),
                x => x.HasOne<AttributeLibDm>().WithMany().HasForeignKey("AttributeId"),
                x => x.ToTable("Attribute_Node")
            );

            builder.HasMany(x => x.Transports).WithMany(y => y.Attributes).UsingEntity<Dictionary<string, object>>("Attribute_Transport",
                x => x.HasOne<TransportLibDm>().WithMany().HasForeignKey("TransportId"),
                x => x.HasOne<AttributeLibDm>().WithMany().HasForeignKey("AttributeId"),
                x => x.ToTable("Attribute_Transport")
            );

            builder.HasMany(x => x.SimpleTypes).WithMany(y => y.Attributes).UsingEntity<Dictionary<string, object>>("Attribute_Simple",
                x => x.HasOne<SimpleLibDm>().WithMany().HasForeignKey("SimpleId"),
                x => x.HasOne<AttributeLibDm>().WithMany().HasForeignKey("AttributeId"),
                x => x.ToTable("Attribute_Simple")
            );

            builder.HasMany(x => x.Interfaces).WithMany(y => y.Attributes).UsingEntity<Dictionary<string, object>>("Attribute_Interface",
                x => x.HasOne<InterfaceLibDm>().WithMany().HasForeignKey("InterfaceId"),
                x => x.HasOne<AttributeLibDm>().WithMany().HasForeignKey("AttributeId"),
                x => x.ToTable("Attribute_Interface")
            );
        }
    }
}