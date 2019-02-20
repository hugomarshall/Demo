using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoCore.Infra.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DemoCoreData");

            migrationBuilder.CreateTable(
                name: "BestWorkTime",
                schema: "DemoCoreData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescriptionPT = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    DescriptionEN = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    EntityState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BestWorkTime", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Designer",
                schema: "DemoCoreData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescriptionEN = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    DescriptionPT = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    EntityState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designer", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Developer",
                schema: "DemoCoreData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescriptionEN = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    DescriptionPT = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    EntityState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "People",
                schema: "DemoCoreData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Skype = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    LinkedIn = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Portfolio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsDeveloper = table.Column<bool>(type: "bit", nullable: false),
                    IsDesigner = table.Column<bool>(nullable: false),
                    EntityState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "WorkAvailability",
                schema: "DemoCoreData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DescriptionEN = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    DescriptionPT = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    EntityState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkAvailability", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                });

            migrationBuilder.CreateTable(
                name: "Knowledge",
                schema: "DemoCoreData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PeopleId = table.Column<int>(nullable: false),
                    Other = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UrlLinkCRUD = table.Column<string>(nullable: true),
                    EntityState = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Knowledge", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.UniqueConstraint("AK_Knowledge_PeopleId", x => x.PeopleId);
                    table.ForeignKey(
                        name: "FK_Knowledge_People_PeopleId",
                        column: x => x.PeopleId,
                        principalSchema: "DemoCoreData",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Occupation",
                schema: "DemoCoreData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PeopleId = table.Column<int>(nullable: false),
                    EntityState = table.Column<int>(nullable: false),
                    HasChanges = table.Column<bool>(nullable: false),
                    IsNew = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateLastUpdate = table.Column<DateTime>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occupation", x => x.Id)
                        .Annotation("SqlServer:Clustered", true);
                    table.UniqueConstraint("AK_Occupation_PeopleId", x => x.PeopleId);
                    table.ForeignKey(
                        name: "FK_Occupation_People_PeopleId",
                        column: x => x.PeopleId,
                        principalSchema: "DemoCoreData",
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeDesigner",
                schema: "DemoCoreData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KnowledgeId = table.Column<int>(nullable: false),
                    DesignerId = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeDesigner", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnowledgeDesigner_Designer_DesignerId",
                        column: x => x.DesignerId,
                        principalSchema: "DemoCoreData",
                        principalTable: "Designer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KnowledgeDesigner_Knowledge_KnowledgeId",
                        column: x => x.KnowledgeId,
                        principalSchema: "DemoCoreData",
                        principalTable: "Knowledge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeDeveloper",
                schema: "DemoCoreData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    KnowledgeId = table.Column<int>(nullable: false),
                    DeveloperId = table.Column<int>(nullable: false),
                    Value = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeDeveloper", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnowledgeDeveloper_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalSchema: "DemoCoreData",
                        principalTable: "Developer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KnowledgeDeveloper_Knowledge_KnowledgeId",
                        column: x => x.KnowledgeId,
                        principalSchema: "DemoCoreData",
                        principalTable: "Knowledge",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OccupationBestWorkTime",
                schema: "DemoCoreData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BestWorkTimeId = table.Column<int>(nullable: false),
                    OccupationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccupationBestWorkTime", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OccupationBestWorkTime_BestWorkTime_BestWorkTimeId",
                        column: x => x.BestWorkTimeId,
                        principalSchema: "DemoCoreData",
                        principalTable: "BestWorkTime",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OccupationBestWorkTime_Occupation_OccupationId",
                        column: x => x.OccupationId,
                        principalSchema: "DemoCoreData",
                        principalTable: "Occupation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OccupationWorkAvailability",
                schema: "DemoCoreData",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OccupationId = table.Column<int>(nullable: false),
                    WorkAvailabilityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccupationWorkAvailability", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OccupationWorkAvailability_Occupation_OccupationId",
                        column: x => x.OccupationId,
                        principalSchema: "DemoCoreData",
                        principalTable: "Occupation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OccupationWorkAvailability_WorkAvailability_WorkAvailabilityId",
                        column: x => x.WorkAvailabilityId,
                        principalSchema: "DemoCoreData",
                        principalTable: "WorkAvailability",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeDesigner_DesignerId",
                schema: "DemoCoreData",
                table: "KnowledgeDesigner",
                column: "DesignerId");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeDesigner_KnowledgeId",
                schema: "DemoCoreData",
                table: "KnowledgeDesigner",
                column: "KnowledgeId");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeDeveloper_DeveloperId",
                schema: "DemoCoreData",
                table: "KnowledgeDeveloper",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeDeveloper_KnowledgeId",
                schema: "DemoCoreData",
                table: "KnowledgeDeveloper",
                column: "KnowledgeId");

            migrationBuilder.CreateIndex(
                name: "IX_OccupationBestWorkTime_BestWorkTimeId",
                schema: "DemoCoreData",
                table: "OccupationBestWorkTime",
                column: "BestWorkTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_OccupationBestWorkTime_OccupationId",
                schema: "DemoCoreData",
                table: "OccupationBestWorkTime",
                column: "OccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_OccupationWorkAvailability_OccupationId",
                schema: "DemoCoreData",
                table: "OccupationWorkAvailability",
                column: "OccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_OccupationWorkAvailability_WorkAvailabilityId",
                schema: "DemoCoreData",
                table: "OccupationWorkAvailability",
                column: "WorkAvailabilityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KnowledgeDesigner",
                schema: "DemoCoreData");

            migrationBuilder.DropTable(
                name: "KnowledgeDeveloper",
                schema: "DemoCoreData");

            migrationBuilder.DropTable(
                name: "OccupationBestWorkTime",
                schema: "DemoCoreData");

            migrationBuilder.DropTable(
                name: "OccupationWorkAvailability",
                schema: "DemoCoreData");

            migrationBuilder.DropTable(
                name: "Designer",
                schema: "DemoCoreData");

            migrationBuilder.DropTable(
                name: "Developer",
                schema: "DemoCoreData");

            migrationBuilder.DropTable(
                name: "Knowledge",
                schema: "DemoCoreData");

            migrationBuilder.DropTable(
                name: "BestWorkTime",
                schema: "DemoCoreData");

            migrationBuilder.DropTable(
                name: "Occupation",
                schema: "DemoCoreData");

            migrationBuilder.DropTable(
                name: "WorkAvailability",
                schema: "DemoCoreData");

            migrationBuilder.DropTable(
                name: "People",
                schema: "DemoCoreData");
        }
    }
}
