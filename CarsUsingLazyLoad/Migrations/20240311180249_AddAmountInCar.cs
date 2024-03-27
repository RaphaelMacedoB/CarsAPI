using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarsUsingLazyLoad.Migrations
{
  /// <inheritdoc />
  public partial class AddAmountInCar : Migration
  {
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<int>(
          name: "Amount",
          table: "Cars",
          type: "int",
          nullable: true,
          defaultValue: 2);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
          name: "Amount",
          table: "Cars");
    }
  }
}
