﻿// <auto-generated />
using System;
using Masa.Alert.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Masa.Alert.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(AlertDbContext))]
    partial class AlertDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Masa.Alert.Domain.AlarmHistorys.Aggregates.AlarmHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AlarmCount")
                        .HasColumnType("int");

                    b.Property<Guid>("AlarmRuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AlarmRuleItems")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AlertSeverity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Creator")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("FirstAlarmTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("LastAlarmTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTimeOffset?>("LastNotificationTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Modifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset?>("RecoveryTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AlarmHistorys", "alert");
                });

            modelBuilder.Entity("Masa.Alert.Domain.AlarmRules.Aggregates.AlarmRule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AlarmRuleType")
                        .HasColumnType("int");

                    b.Property<string>("AppIdentity")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ChartYAxisUnit")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("ContinuousTriggerThreshold")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Creator")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsEnabled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsGetTotal")
                        .HasColumnType("bit");

                    b.Property<string>("LogMonitorItems")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Modifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProjectIdentity")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("TotalVariable")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("WhereExpression")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AlarmRules", "alert");
                });

            modelBuilder.Entity("Masa.Alert.Domain.AlarmRules.Aggregates.AlarmRuleItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AlarmRuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AlertSeverity")
                        .HasColumnType("int");

                    b.Property<string>("Expression")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsNotification")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRecoveryNotification")
                        .HasColumnType("bit");

                    b.Property<string>("NotificationConfig")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RecoveryNotificationConfig")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlarmRuleId");

                    b.ToTable("AlarmRuleItems", "alert");
                });

            modelBuilder.Entity("Masa.Alert.Domain.AlarmRules.Aggregates.AlarmRuleRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AggregateResult")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("AlarmRuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ConsecutiveCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Creator")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTrigger")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Modifier")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AlarmRuleId");

                    b.ToTable("AlarmRuleRecords", "alert");
                });

            modelBuilder.Entity("Masa.BuildingBlocks.Dispatcher.IntegrationEvents.Logs.IntegrationEventLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("EventTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("RowVersion");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<int>("TimesSent")
                        .HasColumnType("int");

                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "EventId", "RowVersion" }, "IX_EventId_Version");

                    b.HasIndex(new[] { "State", "ModificationTime" }, "IX_State_MTime");

                    b.HasIndex(new[] { "State", "TimesSent", "ModificationTime" }, "IX_State_TimesSent_MTime");

                    b.ToTable("IntegrationEventLog", (string)null);
                });

            modelBuilder.Entity("Masa.Alert.Domain.AlarmRules.Aggregates.AlarmRule", b =>
                {
                    b.OwnsOne("Masa.Alert.Domain.AlarmRules.Aggregates.CheckFrequency", "CheckFrequency", b1 =>
                        {
                            b1.Property<Guid>("AlarmRuleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("CronExpression")
                                .IsRequired()
                                .HasMaxLength(128)
                                .HasColumnType("nvarchar(128)")
                                .HasColumnName("CheckFrequencyCron");

                            b1.Property<int>("Type")
                                .HasColumnType("int")
                                .HasColumnName("CheckFrequencyType");

                            b1.HasKey("AlarmRuleId");

                            b1.ToTable("AlarmRules", "alert");

                            b1.WithOwner()
                                .HasForeignKey("AlarmRuleId");

                            b1.OwnsOne("Masa.Alert.Domain.AlarmRules.Aggregates.TimeInterval", "FixedInterval", b2 =>
                                {
                                    b2.Property<Guid>("CheckFrequencyAlarmRuleId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<int>("IntervalTime")
                                        .HasColumnType("int")
                                        .HasColumnName("CheckFrequencyIntervalTime");

                                    b2.Property<int>("IntervalTimeType")
                                        .HasColumnType("int")
                                        .HasColumnName("CheckFrequencyIntervalTimeType");

                                    b2.HasKey("CheckFrequencyAlarmRuleId");

                                    b2.ToTable("AlarmRules", "alert");

                                    b2.WithOwner()
                                        .HasForeignKey("CheckFrequencyAlarmRuleId");
                                });

                            b1.Navigation("FixedInterval")
                                .IsRequired();
                        });

                    b.OwnsOne("Masa.Alert.Domain.AlarmRules.Aggregates.SilenceCycle", "SilenceCycle", b1 =>
                        {
                            b1.Property<Guid>("AlarmRuleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("SilenceCycleValue")
                                .HasColumnType("int")
                                .HasColumnName("SilenceCycleValue");

                            b1.Property<int>("Type")
                                .HasColumnType("int")
                                .HasColumnName("SilenceCycleType");

                            b1.HasKey("AlarmRuleId");

                            b1.ToTable("AlarmRules", "alert");

                            b1.WithOwner()
                                .HasForeignKey("AlarmRuleId");

                            b1.OwnsOne("Masa.Alert.Domain.AlarmRules.Aggregates.TimeInterval", "TimeInterval", b2 =>
                                {
                                    b2.Property<Guid>("SilenceCycleAlarmRuleId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<int>("IntervalTime")
                                        .HasColumnType("int")
                                        .HasColumnName("SilenceCycleIntervalTime");

                                    b2.Property<int>("IntervalTimeType")
                                        .HasColumnType("int")
                                        .HasColumnName("SilenceCycleIntervalTimeType");

                                    b2.HasKey("SilenceCycleAlarmRuleId");

                                    b2.ToTable("AlarmRules", "alert");

                                    b2.WithOwner()
                                        .HasForeignKey("SilenceCycleAlarmRuleId");
                                });

                            b1.Navigation("TimeInterval")
                                .IsRequired();
                        });

                    b.Navigation("CheckFrequency")
                        .IsRequired();

                    b.Navigation("SilenceCycle")
                        .IsRequired();
                });

            modelBuilder.Entity("Masa.Alert.Domain.AlarmRules.Aggregates.AlarmRuleItem", b =>
                {
                    b.HasOne("Masa.Alert.Domain.AlarmRules.Aggregates.AlarmRule", null)
                        .WithMany("Items")
                        .HasForeignKey("AlarmRuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Masa.Alert.Domain.AlarmRules.Aggregates.AlarmRuleRecord", b =>
                {
                    b.HasOne("Masa.Alert.Domain.AlarmRules.Aggregates.AlarmRule", null)
                        .WithMany("AlarmRuleRecords")
                        .HasForeignKey("AlarmRuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Masa.Alert.Domain.AlarmRules.Aggregates.AlarmRule", b =>
                {
                    b.Navigation("AlarmRuleRecords");

                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
