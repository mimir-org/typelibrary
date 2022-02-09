﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TypeLibrary.Core.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttributeAspect",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Aspect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributeAspect", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttributeAspect_AttributeAspect_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AttributeAspect",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AttributePredefined",
                columns: table => new
                {
                    Key = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ValueStringList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsMultiSelect = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttributePredefined", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Blob",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discipline = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blob", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Collection",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<int>(type: "int", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Format",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Format", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purpose",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discipline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purpose", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Qualifier",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RdsCategory",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RdsCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Simple",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iri = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simple", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Source",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Source", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terminal",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParentTerminalId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terminal_Terminal_ParentTerminalId",
                        column: x => x.ParentTerminalId,
                        principalTable: "Terminal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Unit",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iri = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rds",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RdsCategoryId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SemanticReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aspect = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rds_RdsCategory_RdsCategoryId",
                        column: x => x.RdsCategoryId,
                        principalTable: "RdsCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Attribute",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Entity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aspect = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QualifierId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    SourceId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ConditionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FormatId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelectValuesString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Select = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discipline = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attribute_Condition_ConditionId",
                        column: x => x.ConditionId,
                        principalTable: "Condition",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attribute_Format_FormatId",
                        column: x => x.FormatId,
                        principalTable: "Format",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attribute_Qualifier_QualifierId",
                        column: x => x.QualifierId,
                        principalTable: "Qualifier",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Attribute_Source_SourceId",
                        column: x => x.SourceId,
                        principalTable: "Source",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LibraryType",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusId = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "4590637F39B6BA6F39C74293BE9138DF"),
                    TypeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SemanticReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aspect = table.Column<int>(type: "int", nullable: false),
                    RdsId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PurposeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false, defaultValue: "Unknown"),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interface_TerminalId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    AttributeAspect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SymbolId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttributeDataPredefined = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Transport_TerminalId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LibraryType_Purpose_PurposeId",
                        column: x => x.PurposeId,
                        principalTable: "Purpose",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LibraryType_Rds_RdsId",
                        column: x => x.RdsId,
                        principalTable: "Rds",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LibraryType_Terminal_Interface_TerminalId",
                        column: x => x.Interface_TerminalId,
                        principalTable: "Terminal",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LibraryType_Terminal_Transport_TerminalId",
                        column: x => x.Transport_TerminalId,
                        principalTable: "Terminal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Attribute_Simple",
                columns: table => new
                {
                    AttributeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SimpleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute_Simple", x => new { x.AttributeId, x.SimpleId });
                    table.ForeignKey(
                        name: "FK_Attribute_Simple_Attribute_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attribute_Simple_Simple_SimpleId",
                        column: x => x.SimpleId,
                        principalTable: "Simple",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attribute_Unit",
                columns: table => new
                {
                    AttributeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UnitId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute_Unit", x => new { x.AttributeId, x.UnitId });
                    table.ForeignKey(
                        name: "FK_Attribute_Unit_Attribute_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attribute_Unit_Unit_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Unit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Terminal_Attribute",
                columns: table => new
                {
                    AttributeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TerminalId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminal_Attribute", x => new { x.AttributeId, x.TerminalId });
                    table.ForeignKey(
                        name: "FK_Terminal_Attribute_Attribute_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Terminal_Attribute_Terminal_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attribute_Interface",
                columns: table => new
                {
                    AttributeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InterfaceId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute_Interface", x => new { x.AttributeId, x.InterfaceId });
                    table.ForeignKey(
                        name: "FK_Attribute_Interface_Attribute_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attribute_Interface_LibraryType_InterfaceId",
                        column: x => x.InterfaceId,
                        principalTable: "LibraryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attribute_Node",
                columns: table => new
                {
                    AttributeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NodeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute_Node", x => new { x.AttributeId, x.NodeId });
                    table.ForeignKey(
                        name: "FK_Attribute_Node_Attribute_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attribute_Node_LibraryType_NodeId",
                        column: x => x.NodeId,
                        principalTable: "LibraryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attribute_Transport",
                columns: table => new
                {
                    AttributeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TransportId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attribute_Transport", x => new { x.AttributeId, x.TransportId });
                    table.ForeignKey(
                        name: "FK_Attribute_Transport_Attribute_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attribute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attribute_Transport_LibraryType_TransportId",
                        column: x => x.TransportId,
                        principalTable: "LibraryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibraryType_Collection",
                columns: table => new
                {
                    CollectionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LibraryTypeId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibraryType_Collection", x => new { x.CollectionId, x.LibraryTypeId });
                    table.ForeignKey(
                        name: "FK_LibraryType_Collection_Collection_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibraryType_Collection_LibraryType_LibraryTypeId",
                        column: x => x.LibraryTypeId,
                        principalTable: "LibraryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Simple_Node",
                columns: table => new
                {
                    NodeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SimpleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Simple_Node", x => new { x.NodeId, x.SimpleId });
                    table.ForeignKey(
                        name: "FK_Simple_Node_LibraryType_NodeId",
                        column: x => x.NodeId,
                        principalTable: "LibraryType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Simple_Node_Simple_SimpleId",
                        column: x => x.SimpleId,
                        principalTable: "Simple",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Terminal_Node",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    Connector = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NodeId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TerminalId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminal_Node", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terminal_Node_LibraryType_NodeId",
                        column: x => x.NodeId,
                        principalTable: "LibraryType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Terminal_Node_Terminal_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminal",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_ConditionId",
                table: "Attribute",
                column: "ConditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_FormatId",
                table: "Attribute",
                column: "FormatId");

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_QualifierId",
                table: "Attribute",
                column: "QualifierId");

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_SourceId",
                table: "Attribute",
                column: "SourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_Interface_InterfaceId",
                table: "Attribute_Interface",
                column: "InterfaceId");

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_Node_NodeId",
                table: "Attribute_Node",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_Simple_SimpleId",
                table: "Attribute_Simple",
                column: "SimpleId");

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_Transport_TransportId",
                table: "Attribute_Transport",
                column: "TransportId");

            migrationBuilder.CreateIndex(
                name: "IX_Attribute_Unit_UnitId",
                table: "Attribute_Unit",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_AttributeAspect_ParentId",
                table: "AttributeAspect",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryType_Interface_TerminalId",
                table: "LibraryType",
                column: "Interface_TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryType_PurposeId",
                table: "LibraryType",
                column: "PurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryType_RdsId",
                table: "LibraryType",
                column: "RdsId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryType_Transport_TerminalId",
                table: "LibraryType",
                column: "Transport_TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_LibraryType_Collection_LibraryTypeId",
                table: "LibraryType_Collection",
                column: "LibraryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Rds_RdsCategoryId",
                table: "Rds",
                column: "RdsCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Simple_Node_SimpleId",
                table: "Simple_Node",
                column: "SimpleId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminal_ParentTerminalId",
                table: "Terminal",
                column: "ParentTerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminal_Attribute_TerminalId",
                table: "Terminal_Attribute",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminal_Node_NodeId",
                table: "Terminal_Node",
                column: "NodeId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminal_Node_TerminalId",
                table: "Terminal_Node",
                column: "TerminalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attribute_Interface");

            migrationBuilder.DropTable(
                name: "Attribute_Node");

            migrationBuilder.DropTable(
                name: "Attribute_Simple");

            migrationBuilder.DropTable(
                name: "Attribute_Transport");

            migrationBuilder.DropTable(
                name: "Attribute_Unit");

            migrationBuilder.DropTable(
                name: "AttributeAspect");

            migrationBuilder.DropTable(
                name: "AttributePredefined");

            migrationBuilder.DropTable(
                name: "Blob");

            migrationBuilder.DropTable(
                name: "LibraryType_Collection");

            migrationBuilder.DropTable(
                name: "Simple_Node");

            migrationBuilder.DropTable(
                name: "Terminal_Attribute");

            migrationBuilder.DropTable(
                name: "Terminal_Node");

            migrationBuilder.DropTable(
                name: "Unit");

            migrationBuilder.DropTable(
                name: "Collection");

            migrationBuilder.DropTable(
                name: "Simple");

            migrationBuilder.DropTable(
                name: "Attribute");

            migrationBuilder.DropTable(
                name: "LibraryType");

            migrationBuilder.DropTable(
                name: "Condition");

            migrationBuilder.DropTable(
                name: "Format");

            migrationBuilder.DropTable(
                name: "Qualifier");

            migrationBuilder.DropTable(
                name: "Source");

            migrationBuilder.DropTable(
                name: "Purpose");

            migrationBuilder.DropTable(
                name: "Rds");

            migrationBuilder.DropTable(
                name: "Terminal");

            migrationBuilder.DropTable(
                name: "RdsCategory");
        }
    }
}