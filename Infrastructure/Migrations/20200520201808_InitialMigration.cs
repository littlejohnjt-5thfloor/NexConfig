using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessTokens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<string>(nullable: true),
                    Token = table.Column<string>(nullable: true),
                    TokenType = table.Column<string>(nullable: true),
                    ExpiresIn = table.Column<int>(nullable: false),
                    RefreshToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessTokens", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    DefaultInvoicingDay = table.Column<int>(nullable: true),
                    Visible = table.Column<bool>(nullable: true),
                    UseTimePasses = table.Column<bool>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    SignUpFee = table.Column<decimal>(type: "Money", nullable: true),
                    CurrencyId = table.Column<int>(nullable: false),
                    TaxRateId = table.Column<int>(nullable: true),
                    FinancialAccountId = table.Column<int>(nullable: true),
                    TermsAndConditions = table.Column<string>(nullable: true),
                    CancellationPeriod = table.Column<int>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    GroupName = table.Column<string>(nullable: true),
                    SubscribersLimit = table.Column<int>(nullable: true),
                    CancellationLimitDays = table.Column<int>(nullable: true),
                    DefaultContractTerm = table.Column<int>(nullable: true),
                    CancelMemeberAccountAfter = table.Column<int>(nullable: true),
                    CheckinPricePlanLimit = table.Column<int>(nullable: true),
                    CheckinWeekLimit = table.Column<int>(nullable: true),
                    HoursPricePlanLimit = table.Column<int>(nullable: true),
                    HoursWeekLimit = table.Column<int>(nullable: true),
                    BookingMinuteWeekLimit = table.Column<int>(nullable: true),
                    BookingMinuteMonthLimit = table.Column<int>(nullable: true),
                    DiscountExtraServices = table.Column<decimal>(type: "Money", nullable: true),
                    DiscountTimePasses = table.Column<decimal>(type: "Money", nullable: true),
                    DiscountCharges = table.Column<decimal>(type: "Money", nullable: true),
                    InvoiceEvery = table.Column<int>(nullable: false),
                    InvoiceEveryWeeks = table.Column<int>(nullable: false),
                    AutoCancelAfter = table.Column<int>(nullable: true),
                    AdvanceInvoiceCycles = table.Column<int>(nullable: true),
                    ProrateDayOfMonth = table.Column<int>(nullable: true),
                    ProrateDaysBefore = table.Column<int>(nullable: true),
                    ProrateCancellations = table.Column<int>(nullable: true),
                    ChargeAndExtend = table.Column<int>(nullable: true),
                    AutoRaiseInvoices = table.Column<bool>(nullable: true),
                    RaiseInvoiceEvery = table.Column<int>(nullable: true),
                    RaiseInvoiceEveryWeeks = table.Column<int>(nullable: true),
                    Archived = table.Column<bool>(nullable: true),
                    Starred = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessTokens");

            migrationBuilder.DropTable(
                name: "Plans");
        }
    }
}
