using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoCore.Infra.Data.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OccupationWorkAvailability",
                schema: "DemoCoreData",
                table: "OccupationWorkAvailability");

            migrationBuilder.DropIndex(
                name: "IX_OccupationWorkAvailability_OccupationId",
                schema: "DemoCoreData",
                table: "OccupationWorkAvailability");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OccupationBestWorkTime",
                schema: "DemoCoreData",
                table: "OccupationBestWorkTime");

            migrationBuilder.DropIndex(
                name: "IX_OccupationBestWorkTime_OccupationId",
                schema: "DemoCoreData",
                table: "OccupationBestWorkTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KnowledgeDeveloper",
                schema: "DemoCoreData",
                table: "KnowledgeDeveloper");

            migrationBuilder.DropIndex(
                name: "IX_KnowledgeDeveloper_KnowledgeId",
                schema: "DemoCoreData",
                table: "KnowledgeDeveloper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KnowledgeDesigner",
                schema: "DemoCoreData",
                table: "KnowledgeDesigner");

            migrationBuilder.DropIndex(
                name: "IX_KnowledgeDesigner_KnowledgeId",
                schema: "DemoCoreData",
                table: "KnowledgeDesigner");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "DemoCoreData",
                table: "OccupationWorkAvailability");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "DemoCoreData",
                table: "OccupationBestWorkTime");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "DemoCoreData",
                table: "KnowledgeDeveloper");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "DemoCoreData",
                table: "KnowledgeDesigner");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OccupationWorkAvailability",
                schema: "DemoCoreData",
                table: "OccupationWorkAvailability",
                columns: new[] { "OccupationId", "WorkAvailabilityId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_OccupationBestWorkTime",
                schema: "DemoCoreData",
                table: "OccupationBestWorkTime",
                columns: new[] { "OccupationId", "BestWorkTimeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_KnowledgeDeveloper",
                schema: "DemoCoreData",
                table: "KnowledgeDeveloper",
                columns: new[] { "KnowledgeId", "DeveloperId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_KnowledgeDesigner",
                schema: "DemoCoreData",
                table: "KnowledgeDesigner",
                columns: new[] { "KnowledgeId", "DesignerId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_OccupationWorkAvailability",
                schema: "DemoCoreData",
                table: "OccupationWorkAvailability");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OccupationBestWorkTime",
                schema: "DemoCoreData",
                table: "OccupationBestWorkTime");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KnowledgeDeveloper",
                schema: "DemoCoreData",
                table: "KnowledgeDeveloper");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KnowledgeDesigner",
                schema: "DemoCoreData",
                table: "KnowledgeDesigner");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "DemoCoreData",
                table: "OccupationWorkAvailability",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "DemoCoreData",
                table: "OccupationBestWorkTime",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "DemoCoreData",
                table: "KnowledgeDeveloper",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "DemoCoreData",
                table: "KnowledgeDesigner",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OccupationWorkAvailability",
                schema: "DemoCoreData",
                table: "OccupationWorkAvailability",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OccupationBestWorkTime",
                schema: "DemoCoreData",
                table: "OccupationBestWorkTime",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KnowledgeDeveloper",
                schema: "DemoCoreData",
                table: "KnowledgeDeveloper",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KnowledgeDesigner",
                schema: "DemoCoreData",
                table: "KnowledgeDesigner",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OccupationWorkAvailability_OccupationId",
                schema: "DemoCoreData",
                table: "OccupationWorkAvailability",
                column: "OccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_OccupationBestWorkTime_OccupationId",
                schema: "DemoCoreData",
                table: "OccupationBestWorkTime",
                column: "OccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeDeveloper_KnowledgeId",
                schema: "DemoCoreData",
                table: "KnowledgeDeveloper",
                column: "KnowledgeId");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeDesigner_KnowledgeId",
                schema: "DemoCoreData",
                table: "KnowledgeDesigner",
                column: "KnowledgeId");
        }
    }
}
