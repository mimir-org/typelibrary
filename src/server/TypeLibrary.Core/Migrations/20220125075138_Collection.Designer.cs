﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TypeLibrary.Data;

#nullable disable

namespace TypeLibrary.Core.Migrations
{
    [DbContext(typeof(TypeLibraryDbContext))]
    [Migration("20220125075138_Collection")]
    partial class Collection
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AttributeType_Unit", b =>
                {
                    b.Property<string>("AttributeTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UnitId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AttributeTypeId", "UnitId");

                    b.HasIndex("UnitId");

                    b.ToTable("AttributeType_Unit", (string)null);
                });

            modelBuilder.Entity("NodeType_AttributeType", b =>
                {
                    b.Property<string>("AttributeTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("NodeTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AttributeTypeId", "NodeTypeId");

                    b.HasIndex("NodeTypeId");

                    b.ToTable("NodeType_AttributeType", (string)null);
                });

            modelBuilder.Entity("SimpleType_AttributeType", b =>
                {
                    b.Property<string>("AttributeTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SimpleTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AttributeTypeId", "SimpleTypeId");

                    b.HasIndex("SimpleTypeId");

                    b.ToTable("SimpleType_AttributeType", (string)null);
                });

            modelBuilder.Entity("SimpleType_NodeType", b =>
                {
                    b.Property<string>("NodeTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SimpleTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("NodeTypeId", "SimpleTypeId");

                    b.HasIndex("SimpleTypeId");

                    b.ToTable("SimpleType_NodeType", (string)null);
                });

            modelBuilder.Entity("TerminalType_AttributeType", b =>
                {
                    b.Property<string>("AttributeTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TerminalTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AttributeTypeId", "TerminalTypeId");

                    b.HasIndex("TerminalTypeId");

                    b.ToTable("TerminalType_AttributeType", (string)null);
                });

            modelBuilder.Entity("TransportType_AttributeType", b =>
                {
                    b.Property<string>("AttributeTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TransportTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AttributeTypeId", "TransportTypeId");

                    b.HasIndex("TransportTypeId");

                    b.ToTable("TransportType_AttributeType", (string)null);
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.AttributeType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<string>("Aspect")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Aspect");

                    b.Property<string>("ConditionId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Discipline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Discipline");

                    b.Property<string>("Entity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Entity");

                    b.Property<string>("FormatId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("InterfaceTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("QualifierId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SelectType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SelectType");

                    b.Property<string>("SelectValuesString")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SelectValuesString");

                    b.Property<string>("SourceId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Tags");

                    b.HasKey("Id");

                    b.HasIndex("ConditionId");

                    b.HasIndex("FormatId");

                    b.HasIndex("InterfaceTypeId");

                    b.HasIndex("QualifierId");

                    b.HasIndex("SourceId");

                    b.ToTable("AttributeType", (string)null);
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.BlobData", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Data");

                    b.Property<string>("Discipline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Discipline");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("BlobData", (string)null);
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.Collection", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Iri")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Iri");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Collection", (string)null);
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.Condition", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Iri")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Iri");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Condition", (string)null);
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.Format", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Iri")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Iri");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Format", (string)null);
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.LibraryType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<int>("Aspect")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValue(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc))
                        .HasColumnName("Created");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("Unknown")
                        .HasColumnName("CreatedBy");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("PurposeId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("PurposeId");

                    b.Property<string>("RdsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SemanticReference")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SemanticReference");

                    b.Property<string>("StatusId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("4590637F39B6BA6F39C74293BE9138DF")
                        .HasColumnName("StatusId");

                    b.Property<string>("TypeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TypeId");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("datetime2")
                        .HasColumnName("Updated");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UpdatedBy");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Version");

                    b.HasKey("Id");

                    b.HasIndex("PurposeId");

                    b.HasIndex("RdsId");

                    b.ToTable("LibraryType", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("LibraryType");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.Location", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<string>("Aspect")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Aspect");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Iri")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Iri");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("ParentId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Location", (string)null);
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.NodeTypeTerminalType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<string>("ConnectorType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ConnectorType");

                    b.Property<string>("NodeTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("Number");

                    b.Property<string>("TerminalTypeId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("NodeTypeId");

                    b.HasIndex("TerminalTypeId");

                    b.ToTable("NodeType_TerminalType", (string)null);
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.PredefinedAttribute", b =>
                {
                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Key");

                    b.Property<bool>("IsMultiSelect")
                        .HasColumnType("bit")
                        .HasColumnName("IsMultiSelect");

                    b.Property<string>("Values")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Values");

                    b.HasKey("Key");

                    b.ToTable("PredefinedAttribute", (string)null);
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.Purpose", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Discipline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Discipline");

                    b.Property<string>("Iri")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Iri");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Purpose", (string)null);
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.Qualifier", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Iri")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Iri");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Qualifier", (string)null);
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.Rds", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<string>("Aspect")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Aspect");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Code");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("RdsCategoryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SemanticReference")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SemanticReference");

                    b.HasKey("Id");

                    b.HasIndex("RdsCategoryId");

                    b.ToTable("Rds", (string)null);
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.RdsCategory", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Iri")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Iri");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("RdsCategory", (string)null);
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.SimpleType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Iri")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Iri");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("SimpleType", (string)null);
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.Source", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Iri")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Iri");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Source", (string)null);
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.TerminalType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Iri")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Iri");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("ParentId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("TerminalType", (string)null);
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.Unit", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("Id");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<string>("Iri")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Iri");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("Unit", (string)null);
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.InterfaceType", b =>
                {
                    b.HasBaseType("TypeLibrary.Models.Data.LibraryType");

                    b.Property<string>("TerminalTypeId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("InterfaceType_TerminalTypeId");

                    b.HasIndex("TerminalTypeId");

                    b.HasDiscriminator().HasValue("InterfaceType");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.NodeType", b =>
                {
                    b.HasBaseType("TypeLibrary.Models.Data.LibraryType");

                    b.Property<string>("LocationType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PredefinedAttributeData")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SymbolId")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("NodeType");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.TransportType", b =>
                {
                    b.HasBaseType("TypeLibrary.Models.Data.LibraryType");

                    b.Property<string>("TerminalTypeId")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("TransportType_TerminalTypeId");

                    b.HasIndex("TerminalTypeId");

                    b.HasDiscriminator().HasValue("TransportType");
                });

            modelBuilder.Entity("AttributeType_Unit", b =>
                {
                    b.HasOne("TypeLibrary.Models.Data.AttributeType", null)
                        .WithMany()
                        .HasForeignKey("AttributeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TypeLibrary.Models.Data.Unit", null)
                        .WithMany()
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("NodeType_AttributeType", b =>
                {
                    b.HasOne("TypeLibrary.Models.Data.AttributeType", null)
                        .WithMany()
                        .HasForeignKey("AttributeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TypeLibrary.Models.Data.NodeType", null)
                        .WithMany()
                        .HasForeignKey("NodeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SimpleType_AttributeType", b =>
                {
                    b.HasOne("TypeLibrary.Models.Data.AttributeType", null)
                        .WithMany()
                        .HasForeignKey("AttributeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TypeLibrary.Models.Data.SimpleType", null)
                        .WithMany()
                        .HasForeignKey("SimpleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SimpleType_NodeType", b =>
                {
                    b.HasOne("TypeLibrary.Models.Data.NodeType", null)
                        .WithMany()
                        .HasForeignKey("NodeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TypeLibrary.Models.Data.SimpleType", null)
                        .WithMany()
                        .HasForeignKey("SimpleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TerminalType_AttributeType", b =>
                {
                    b.HasOne("TypeLibrary.Models.Data.AttributeType", null)
                        .WithMany()
                        .HasForeignKey("AttributeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TypeLibrary.Models.Data.TerminalType", null)
                        .WithMany()
                        .HasForeignKey("TerminalTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TransportType_AttributeType", b =>
                {
                    b.HasOne("TypeLibrary.Models.Data.AttributeType", null)
                        .WithMany()
                        .HasForeignKey("AttributeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TypeLibrary.Models.Data.TransportType", null)
                        .WithMany()
                        .HasForeignKey("TransportTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.AttributeType", b =>
                {
                    b.HasOne("TypeLibrary.Models.Data.Condition", "Condition")
                        .WithMany("AttributeTypes")
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TypeLibrary.Models.Data.Format", "Format")
                        .WithMany("AttributeTypes")
                        .HasForeignKey("FormatId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TypeLibrary.Models.Data.InterfaceType", null)
                        .WithMany("AttributeTypes")
                        .HasForeignKey("InterfaceTypeId");

                    b.HasOne("TypeLibrary.Models.Data.Qualifier", "Qualifier")
                        .WithMany("AttributeTypes")
                        .HasForeignKey("QualifierId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TypeLibrary.Models.Data.Source", "Source")
                        .WithMany("AttributeTypes")
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Condition");

                    b.Navigation("Format");

                    b.Navigation("Qualifier");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.LibraryType", b =>
                {
                    b.HasOne("TypeLibrary.Models.Data.Purpose", "Purpose")
                        .WithMany("LibraryTypes")
                        .HasForeignKey("PurposeId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TypeLibrary.Models.Data.Rds", "Rds")
                        .WithMany("LibraryTypes")
                        .HasForeignKey("RdsId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Purpose");

                    b.Navigation("Rds");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.Location", b =>
                {
                    b.HasOne("TypeLibrary.Models.Data.Location", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.NodeTypeTerminalType", b =>
                {
                    b.HasOne("TypeLibrary.Models.Data.NodeType", "NodeType")
                        .WithMany("TerminalTypes")
                        .HasForeignKey("NodeTypeId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("TypeLibrary.Models.Data.TerminalType", "TerminalType")
                        .WithMany("NodeTypes")
                        .HasForeignKey("TerminalTypeId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("NodeType");

                    b.Navigation("TerminalType");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.Rds", b =>
                {
                    b.HasOne("TypeLibrary.Models.Data.RdsCategory", "RdsCategory")
                        .WithMany("RdsList")
                        .HasForeignKey("RdsCategoryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("RdsCategory");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.TerminalType", b =>
                {
                    b.HasOne("TypeLibrary.Models.Data.TerminalType", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.InterfaceType", b =>
                {
                    b.HasOne("TypeLibrary.Models.Data.TerminalType", "TerminalType")
                        .WithMany("InterfaceTypes")
                        .HasForeignKey("TerminalTypeId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("TerminalType");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.TransportType", b =>
                {
                    b.HasOne("TypeLibrary.Models.Data.TerminalType", "TerminalType")
                        .WithMany("TransportTypes")
                        .HasForeignKey("TerminalTypeId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("TerminalType");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.Condition", b =>
                {
                    b.Navigation("AttributeTypes");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.Format", b =>
                {
                    b.Navigation("AttributeTypes");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.Location", b =>
                {
                    b.Navigation("Children");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.Purpose", b =>
                {
                    b.Navigation("LibraryTypes");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.Qualifier", b =>
                {
                    b.Navigation("AttributeTypes");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.Rds", b =>
                {
                    b.Navigation("LibraryTypes");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.RdsCategory", b =>
                {
                    b.Navigation("RdsList");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.Source", b =>
                {
                    b.Navigation("AttributeTypes");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.TerminalType", b =>
                {
                    b.Navigation("Children");

                    b.Navigation("InterfaceTypes");

                    b.Navigation("NodeTypes");

                    b.Navigation("TransportTypes");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.InterfaceType", b =>
                {
                    b.Navigation("AttributeTypes");
                });

            modelBuilder.Entity("TypeLibrary.Models.Data.NodeType", b =>
                {
                    b.Navigation("TerminalTypes");
                });
#pragma warning restore 612, 618
        }
    }
}