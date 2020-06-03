﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(ConfigurationContext))]
    [Migration("20200602224502_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Entities.AccessToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClientId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateSaved")
                        .HasColumnType("datetime2");

                    b.Property<int>("EntityId")
                        .HasColumnType("int");

                    b.Property<int>("ExpiresIn")
                        .HasColumnType("int");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Token")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TokenType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AccessTokens");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Business", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AboutUs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CookiePolicyUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateSaved")
                        .HasColumnType("datetime2");

                    b.Property<int>("DefaultLanguage")
                        .HasColumnType("int");

                    b.Property<int>("DefaultPaymentGatewayId")
                        .HasColumnType("int");

                    b.Property<string>("EmailContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FloorSpace")
                        .HasColumnType("int");

                    b.Property<int>("FloorSpaceUnit")
                        .HasColumnType("int");

                    b.Property<int?>("FridayCloseTime")
                        .HasColumnType("int");

                    b.Property<bool>("FridayClosed")
                        .HasColumnType("bit");

                    b.Property<int?>("FridayOpenTime")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Last4Digits")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Latitude")
                        .HasColumnType("Money");

                    b.Property<decimal?>("Longitude")
                        .HasColumnType("Money");

                    b.Property<int?>("MondayCloseTime")
                        .HasColumnType("int");

                    b.Property<bool>("MondayClosed")
                        .HasColumnType("bit");

                    b.Property<int?>("MondayOpenTime")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Neighborhood")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NumberOfFloors")
                        .HasColumnType("int");

                    b.Property<int>("PassportBlogPostAccess")
                        .HasColumnType("int");

                    b.Property<string>("PassportChannels")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassportCommunityAccess")
                        .HasColumnType("int");

                    b.Property<string>("PassportDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PassportEventAccess")
                        .HasColumnType("int");

                    b.Property<int>("PassportMembersAccess")
                        .HasColumnType("int");

                    b.Property<bool>("PassportPublished")
                        .HasColumnType("bit");

                    b.Property<string>("PassportSpaceName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportTagLine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreAuthLastError")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PrivacyPolicyUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Quote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("SameOpeningTimes")
                        .HasColumnType("bit");

                    b.Property<int?>("SaturdayCloseTime")
                        .HasColumnType("int");

                    b.Property<bool>("SaturdayClosed")
                        .HasColumnType("bit");

                    b.Property<int?>("SaturdayOpenTime")
                        .HasColumnType("int");

                    b.Property<string>("ShortIntroduction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SimpleTimeZoneId")
                        .HasColumnType("int");

                    b.Property<int>("SpaceWebsiteLanguageId")
                        .HasColumnType("int");

                    b.Property<string>("StreetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SundayCloseTime")
                        .HasColumnType("int");

                    b.Property<bool>("SundayClosed")
                        .HasColumnType("bit");

                    b.Property<int?>("SundayOpenTime")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TermsAndConditions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ThursdayCloseTime")
                        .HasColumnType("int");

                    b.Property<bool>("ThursdayClosed")
                        .HasColumnType("bit");

                    b.Property<int?>("ThursdayOpenTime")
                        .HasColumnType("int");

                    b.Property<string>("TownCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TuesdayCloseTime")
                        .HasColumnType("int");

                    b.Property<bool>("TuesdayClosed")
                        .HasColumnType("bit");

                    b.Property<int?>("TuesdayOpenTime")
                        .HasColumnType("int");

                    b.Property<int>("VenueType")
                        .HasColumnType("int");

                    b.Property<string>("WebAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WednesdayCloseTime")
                        .HasColumnType("int");

                    b.Property<bool>("WednesdayClosed")
                        .HasColumnType("bit");

                    b.Property<int?>("WednesdayOpenTime")
                        .HasColumnType("int");

                    b.HasKey("EntityId");

                    b.ToTable("Businesses");
                });

            modelBuilder.Entity("ApplicationCore.Entities.FinancialAccount", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AccountType")
                        .HasColumnType("int");

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateSaved")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityId");

                    b.ToTable("FinancialAccounts");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Pass", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Archived")
                        .HasColumnType("bit");

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.Property<bool>("CountsTowardsPlanLimits")
                        .HasColumnType("bit");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateSaved")
                        .HasColumnType("datetime2");

                    b.Property<int>("FinancialAccountId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int?>("MinutesIncluded")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.Property<int>("TaxRateId")
                        .HasColumnType("int");

                    b.HasKey("EntityId");

                    b.ToTable("Passes");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Plan", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AdvanceInvoiceCycles")
                        .HasColumnType("int");

                    b.Property<bool?>("Archived")
                        .HasColumnType("bit");

                    b.Property<int?>("AutoCancelAfter")
                        .HasColumnType("int");

                    b.Property<bool?>("AutoRaiseInvoices")
                        .HasColumnType("bit");

                    b.Property<int?>("BookingMinuteMonthLimit")
                        .HasColumnType("int");

                    b.Property<int?>("BookingMinuteWeekLimit")
                        .HasColumnType("int");

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.Property<int?>("CancelMemeberAccountAfter")
                        .HasColumnType("int");

                    b.Property<int?>("CancellationLimitDays")
                        .HasColumnType("int");

                    b.Property<int>("CancellationPeriod")
                        .HasColumnType("int");

                    b.Property<int?>("ChargeAndExtend")
                        .HasColumnType("int");

                    b.Property<int?>("CheckinPricePlanLimit")
                        .HasColumnType("int");

                    b.Property<int?>("CheckinWeekLimit")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateSaved")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DefaultContractTerm")
                        .HasColumnType("int");

                    b.Property<int?>("DefaultInvoicingDay")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("DiscountCharges")
                        .HasColumnType("Money");

                    b.Property<decimal?>("DiscountExtraServices")
                        .HasColumnType("Money");

                    b.Property<decimal?>("DiscountTimePasses")
                        .HasColumnType("Money");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<int?>("FinancialAccountId")
                        .HasColumnType("int");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HoursPricePlanLimit")
                        .HasColumnType("int");

                    b.Property<int?>("HoursWeekLimit")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceEvery")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceEveryWeeks")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.Property<bool?>("ProrateCancellations")
                        .HasColumnType("bit");

                    b.Property<int?>("ProrateDayOfMonth")
                        .HasColumnType("int");

                    b.Property<int?>("ProrateDaysBefore")
                        .HasColumnType("int");

                    b.Property<int?>("RaiseInvoiceEvery")
                        .HasColumnType("int");

                    b.Property<int?>("RaiseInvoiceEveryWeeks")
                        .HasColumnType("int");

                    b.Property<decimal?>("SignUpFee")
                        .HasColumnType("Money");

                    b.Property<bool?>("Starred")
                        .HasColumnType("bit");

                    b.Property<int?>("SubscribersLimit")
                        .HasColumnType("int");

                    b.Property<int?>("TaxRateId")
                        .HasColumnType("int");

                    b.Property<string>("TermsAndConditions")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("UseTimePasses")
                        .HasColumnType("bit");

                    b.Property<bool?>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("EntityId");

                    b.ToTable("Plans");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Product", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("AllowNegativeStock")
                        .HasColumnType("bit");

                    b.Property<bool?>("Archived")
                        .HasColumnType("bit");

                    b.Property<int?>("AvailableAs")
                        .HasColumnType("int");

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.Property<int>("CurrencyId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateSaved")
                        .HasColumnType("datetime2");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<int?>("FinancialAccountId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("OnlyForContacts")
                        .HasColumnType("bit");

                    b.Property<bool?>("OnlyForMembers")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.Property<string>("Sku")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Starred")
                        .HasColumnType("bit");

                    b.Property<int?>("StockAlertLevel")
                        .HasColumnType("int");

                    b.Property<string>("Tags")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TaxRateId")
                        .HasColumnType("int");

                    b.Property<bool?>("TrackStock")
                        .HasColumnType("bit");

                    b.Property<bool?>("Visible")
                        .HasColumnType("bit");

                    b.HasKey("EntityId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Resource", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool?>("AirConditioning")
                        .HasColumnType("bit");

                    b.Property<int?>("Allocation")
                        .HasColumnType("int");

                    b.Property<bool?>("AllowMultipleBookings")
                        .HasColumnType("bit");

                    b.Property<bool?>("Archived")
                        .HasColumnType("bit");

                    b.Property<int?>("BookInAdvanceLimit")
                        .HasColumnType("int");

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.Property<bool?>("CCTV")
                        .HasColumnType("bit");

                    b.Property<bool?>("Catering")
                        .HasColumnType("bit");

                    b.Property<bool?>("ConferencePhone")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DateSaved")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<bool?>("Drinks")
                        .HasColumnType("bit");

                    b.Property<string>("EmailConfirmationContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Heating")
                        .HasColumnType("bit");

                    b.Property<bool?>("HideInCalenday")
                        .HasColumnType("bit");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool?>("Internet")
                        .HasColumnType("bit");

                    b.Property<int?>("IntervalLimit")
                        .HasColumnType("int");

                    b.Property<bool?>("LargeDisplay")
                        .HasColumnType("bit");

                    b.Property<int?>("LateBookingLimit")
                        .HasColumnType("int");

                    b.Property<int?>("LateCancellationLimit")
                        .HasColumnType("int");

                    b.Property<decimal?>("Latitude")
                        .HasColumnType("Money");

                    b.Property<decimal?>("Longitude")
                        .HasColumnType("Money");

                    b.Property<int?>("MaxBookingLength")
                        .HasColumnType("int");

                    b.Property<int?>("MinBookingLength")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("NaturalLight")
                        .HasColumnType("bit");

                    b.Property<int?>("NoReturnPoilcyAllResources")
                        .HasColumnType("int");

                    b.Property<int?>("NoReturnPolicy")
                        .HasColumnType("int");

                    b.Property<int?>("NoReturnPolicyAllUsers")
                        .HasColumnType("int");

                    b.Property<bool?>("Projector")
                        .HasColumnType("bit");

                    b.Property<bool>("RequiresConfirmation")
                        .HasColumnType("bit");

                    b.Property<int>("ResourceTypeId")
                        .HasColumnType("int");

                    b.Property<bool?>("SecurityLocks")
                        .HasColumnType("bit");

                    b.Property<string>("Shifts")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("StandardPhone")
                        .HasColumnType("bit");

                    b.Property<bool?>("TeaAndCoffee")
                        .HasColumnType("bit");

                    b.Property<bool>("Visible")
                        .HasColumnType("bit");

                    b.Property<bool?>("VoiceRecorder")
                        .HasColumnType("bit");

                    b.Property<bool?>("WhiteBoard")
                        .HasColumnType("bit");

                    b.HasKey("EntityId");

                    b.ToTable("Resources");
                });

            modelBuilder.Entity("ApplicationCore.Entities.ResourceType", b =>
                {
                    b.Property<int>("EntityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BusinessId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateSaved")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityId");

                    b.ToTable("ResourceTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
