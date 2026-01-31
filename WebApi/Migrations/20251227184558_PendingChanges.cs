using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class PendingChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTag_BlogPost_BlogPostsId",
                table: "BlogPostTag");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTag_Tag_TagsId",
                table: "BlogPostTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPostTag",
                table: "BlogPostTag");

            migrationBuilder.RenameTable(
                name: "BlogPostTag",
                newName: "BlogPostTags");

            migrationBuilder.RenameColumn(
                name: "TagsId",
                table: "BlogPostTags",
                newName: "TagId");

            migrationBuilder.RenameColumn(
                name: "BlogPostsId",
                table: "BlogPostTags",
                newName: "BlogpostId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPostTag_TagsId",
                table: "BlogPostTags",
                newName: "IX_BlogPostTags_TagId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tag",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Tag",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UrlHandle",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DoC",
                table: "BlogPost",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPostTags",
                table: "BlogPostTags",
                columns: new[] { "BlogpostId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTags_BlogPost_BlogpostId",
                table: "BlogPostTags",
                column: "BlogpostId",
                principalTable: "BlogPost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTags_Tag_TagId",
                table: "BlogPostTags",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTags_BlogPost_BlogpostId",
                table: "BlogPostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostTags_Tag_TagId",
                table: "BlogPostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPostTags",
                table: "BlogPostTags");

            migrationBuilder.RenameTable(
                name: "BlogPostTags",
                newName: "BlogPostTag");

            migrationBuilder.RenameColumn(
                name: "TagId",
                table: "BlogPostTag",
                newName: "TagsId");

            migrationBuilder.RenameColumn(
                name: "BlogpostId",
                table: "BlogPostTag",
                newName: "BlogPostsId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPostTags_TagId",
                table: "BlogPostTag",
                newName: "IX_BlogPostTag_TagsId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Tag",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DisplayName",
                table: "Tag",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UrlHandle",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DoC",
                table: "BlogPost",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "BlogPost",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPostTag",
                table: "BlogPostTag",
                columns: new[] { "BlogPostsId", "TagsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTag_BlogPost_BlogPostsId",
                table: "BlogPostTag",
                column: "BlogPostsId",
                principalTable: "BlogPost",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostTag_Tag_TagsId",
                table: "BlogPostTag",
                column: "TagsId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
