using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccessTokens",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EntityId = table.Column<int>(nullable: false),
                    DateSaved = table.Column<DateTime>(nullable: true),
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
                name: "Businesses",
                columns: table => new
                {
                    EntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    DateSaved = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DefaultLanguage = table.Column<int>(nullable: false),
                    SpaceWebsiteLanguageId = table.Column<int>(nullable: false),
                    WebAddress = table.Column<string>(nullable: true),
                    DefaultPaymentGatewayId = table.Column<int>(nullable: false),
                    TermsAndConditions = table.Column<string>(nullable: true),
                    ShortIntroduction = table.Column<string>(nullable: true),
                    AboutUs = table.Column<string>(nullable: true),
                    Quote = table.Column<string>(nullable: true),
                    PrivacyPolicyUrl = table.Column<string>(nullable: true),
                    CookiePolicyUrl = table.Column<string>(nullable: true),
                    WebContact = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    EmailContact = table.Column<string>(nullable: true),
                    CountryId = table.Column<int>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    SimpleTimeZoneId = table.Column<int>(nullable: false),
                    Last4Digits = table.Column<string>(nullable: true),
                    PreAuthLastError = table.Column<string>(nullable: true),
                    PassportChannels = table.Column<string>(nullable: true),
                    PassportPublished = table.Column<bool>(nullable: false),
                    PassportSpaceName = table.Column<string>(nullable: true),
                    PassportTagLine = table.Column<string>(nullable: true),
                    VenueType = table.Column<int>(nullable: false),
                    Tags = table.Column<string>(nullable: true),
                    NumberOfFloors = table.Column<int>(nullable: true),
                    FloorSpace = table.Column<int>(nullable: true),
                    FloorSpaceUnit = table.Column<int>(nullable: false),
                    Longitude = table.Column<decimal>(type: "Money", nullable: true),
                    Latitude = table.Column<decimal>(type: "Money", nullable: true),
                    PassportDescription = table.Column<string>(nullable: true),
                    TownCity = table.Column<string>(nullable: true),
                    PostalCode = table.Column<string>(nullable: true),
                    StreetName = table.Column<string>(nullable: true),
                    StreetNumber = table.Column<string>(nullable: true),
                    Neighborhood = table.Column<string>(nullable: true),
                    ContactPhoneNumber = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    PassportMembersAccess = table.Column<int>(nullable: false),
                    PassportEventAccess = table.Column<int>(nullable: false),
                    PassportCommunityAccess = table.Column<int>(nullable: false),
                    PassportBlogPostAccess = table.Column<int>(nullable: false),
                    MondayOpenTime = table.Column<int>(nullable: true),
                    MondayCloseTime = table.Column<int>(nullable: true),
                    TuesdayOpenTime = table.Column<int>(nullable: true),
                    TuesdayCloseTime = table.Column<int>(nullable: true),
                    WednesdayOpenTime = table.Column<int>(nullable: true),
                    WednesdayCloseTime = table.Column<int>(nullable: true),
                    ThursdayOpenTime = table.Column<int>(nullable: true),
                    ThursdayCloseTime = table.Column<int>(nullable: true),
                    FridayOpenTime = table.Column<int>(nullable: true),
                    FridayCloseTime = table.Column<int>(nullable: true),
                    SaturdayOpenTime = table.Column<int>(nullable: true),
                    SaturdayCloseTime = table.Column<int>(nullable: true),
                    SundayOpenTime = table.Column<int>(nullable: true),
                    SundayCloseTime = table.Column<int>(nullable: true),
                    MondayClosed = table.Column<bool>(nullable: false),
                    TuesdayClosed = table.Column<bool>(nullable: false),
                    WednesdayClosed = table.Column<bool>(nullable: false),
                    ThursdayClosed = table.Column<bool>(nullable: false),
                    FridayClosed = table.Column<bool>(nullable: false),
                    SaturdayClosed = table.Column<bool>(nullable: false),
                    SundayClosed = table.Column<bool>(nullable: false),
                    SameOpeningTimes = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Businesses", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "FinancialAccounts",
                columns: table => new
                {
                    EntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    DateSaved = table.Column<DateTime>(nullable: true),
                    BusinessId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AccountType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinancialAccounts", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Passes",
                columns: table => new
                {
                    EntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    DateSaved = table.Column<DateTime>(nullable: true),
                    BusinessId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    MinutesIncluded = table.Column<int>(nullable: true),
                    CountsTowardsPlanLimits = table.Column<bool>(nullable: false),
                    CurrencyId = table.Column<int>(nullable: false),
                    TaxRateId = table.Column<int>(nullable: false),
                    FinancialAccountId = table.Column<int>(nullable: false),
                    Archived = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passes", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Plans",
                columns: table => new
                {
                    EntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    DateSaved = table.Column<DateTime>(nullable: true),
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
                    ProrateCancellations = table.Column<bool>(nullable: true),
                    ChargeAndExtend = table.Column<int>(nullable: true),
                    AutoRaiseInvoices = table.Column<bool>(nullable: true),
                    RaiseInvoiceEvery = table.Column<int>(nullable: true),
                    RaiseInvoiceEveryWeeks = table.Column<int>(nullable: true),
                    Archived = table.Column<bool>(nullable: true),
                    Starred = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plans", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    EntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    DateSaved = table.Column<DateTime>(nullable: true),
                    BusinessId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Sku = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(nullable: true),
                    DisplayOrder = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    Visible = table.Column<bool>(nullable: true),
                    CurrencyId = table.Column<int>(nullable: false),
                    TaxRateId = table.Column<int>(nullable: true),
                    FinancialAccountId = table.Column<int>(nullable: true),
                    AvailableAs = table.Column<int>(nullable: true),
                    OnlyForContacts = table.Column<bool>(nullable: true),
                    OnlyForMembers = table.Column<bool>(nullable: true),
                    Archived = table.Column<bool>(nullable: true),
                    Starred = table.Column<bool>(nullable: true),
                    TrackStock = table.Column<bool>(nullable: true),
                    AllowNegativeStock = table.Column<bool>(nullable: true),
                    StockAlertLevel = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "Resources",
                columns: table => new
                {
                    EntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    DateSaved = table.Column<DateTime>(nullable: true),
                    BusinessId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ResourceTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    EmailConfirmationContent = table.Column<string>(nullable: true),
                    Visible = table.Column<bool>(nullable: false),
                    RequiresConfirmation = table.Column<bool>(nullable: false),
                    DisplayOrder = table.Column<int>(nullable: false),
                    GroupName = table.Column<string>(nullable: true),
                    Projector = table.Column<bool>(nullable: true),
                    Internet = table.Column<bool>(nullable: true),
                    ConferencePhone = table.Column<bool>(nullable: true),
                    StandardPhone = table.Column<bool>(nullable: true),
                    WhiteBoard = table.Column<bool>(nullable: true),
                    LargeDisplay = table.Column<bool>(nullable: true),
                    Catering = table.Column<bool>(nullable: true),
                    TeaAndCoffee = table.Column<bool>(nullable: true),
                    Drinks = table.Column<bool>(nullable: true),
                    SecurityLocks = table.Column<bool>(nullable: true),
                    CCTV = table.Column<bool>(nullable: true),
                    VoiceRecorder = table.Column<bool>(nullable: true),
                    AirConditioning = table.Column<bool>(nullable: true),
                    Heating = table.Column<bool>(nullable: true),
                    NaturalLight = table.Column<bool>(nullable: true),
                    AllowMultipleBookings = table.Column<bool>(nullable: true),
                    Allocation = table.Column<int>(nullable: true),
                    BookInAdvanceLimit = table.Column<int>(nullable: true),
                    LateBookingLimit = table.Column<int>(nullable: true),
                    LateCancellationLimit = table.Column<int>(nullable: true),
                    IntervalLimit = table.Column<int>(nullable: true),
                    NoReturnPolicy = table.Column<int>(nullable: true),
                    NoReturnPoilcyAllResources = table.Column<int>(nullable: true),
                    NoReturnPolicyAllUsers = table.Column<int>(nullable: true),
                    MaxBookingLength = table.Column<int>(nullable: true),
                    MinBookingLength = table.Column<int>(nullable: true),
                    Shifts = table.Column<string>(nullable: true),
                    Longitude = table.Column<decimal>(type: "Money", nullable: true),
                    Latitude = table.Column<decimal>(type: "Money", nullable: true),
                    HideInCalenday = table.Column<bool>(nullable: true),
                    Archived = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resources", x => x.EntityId);
                });

            migrationBuilder.CreateTable(
                name: "ResourceTypes",
                columns: table => new
                {
                    EntityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<int>(nullable: false),
                    DateSaved = table.Column<DateTime>(nullable: true),
                    BusinessId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTypes", x => x.EntityId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessTokens");

            migrationBuilder.DropTable(
                name: "Businesses");

            migrationBuilder.DropTable(
                name: "FinancialAccounts");

            migrationBuilder.DropTable(
                name: "Passes");

            migrationBuilder.DropTable(
                name: "Plans");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Resources");

            migrationBuilder.DropTable(
                name: "ResourceTypes");
        }
    }
}
