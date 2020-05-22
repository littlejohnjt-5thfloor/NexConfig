﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ConfigurationContext))]
    partial class ConfigurationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("ApplicationCore.Entities.Plan", b =>
                {
                    b.Property<int>("Id")
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

                    b.Property<int>("InvoiceEvery")
                        .HasColumnType("int");

                    b.Property<int>("InvoiceEveryWeeks")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("Money");

                    b.Property<int?>("ProrateCancellations")
                        .HasColumnType("int");

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

                    b.HasKey("Id");

                    b.ToTable("Plans");
                });
#pragma warning restore 612, 618
        }
    }
}
