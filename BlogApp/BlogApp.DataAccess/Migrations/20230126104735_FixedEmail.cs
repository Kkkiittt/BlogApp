using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogApp.DataAccess.Migrations
{
	public partial class FixedEmail : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.AlterColumn<DateTime>(
				name: "Updated",
				table: "Users",
				type: "timestamp with time zone",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldType: "timestamp with time zone");

			migrationBuilder.AddColumn<bool>(
				name: "EmailVerified",
				table: "Users",
				type: "boolean",
				nullable: false,
				defaultValue: false);

			migrationBuilder.AlterColumn<DateTime>(
				name: "Updated",
				table: "Articles",
				type: "timestamp with time zone",
				nullable: true,
				oldClrType: typeof(DateTime),
				oldType: "timestamp with time zone");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropColumn(
				name: "EmailVerified",
				table: "Users");

			migrationBuilder.AlterColumn<DateTime>(
				name: "Updated",
				table: "Users",
				type: "timestamp with time zone",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
				oldClrType: typeof(DateTime),
				oldType: "timestamp with time zone",
				oldNullable: true);

			migrationBuilder.AlterColumn<DateTime>(
				name: "Updated",
				table: "Articles",
				type: "timestamp with time zone",
				nullable: false,
				defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
				oldClrType: typeof(DateTime),
				oldType: "timestamp with time zone",
				oldNullable: true);
		}
	}
}
