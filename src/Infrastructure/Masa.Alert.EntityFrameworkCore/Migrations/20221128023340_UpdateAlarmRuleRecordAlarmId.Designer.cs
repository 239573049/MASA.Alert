﻿// <auto-generated />
using System;
using Masa.Alert.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Masa.Alert.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(AlertDbContext))]
    [Migration("20221128023340_UpdateAlarmRuleRecordAlarmId")]
    partial class UpdateAlarmRuleRecordAlarmId
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Masa.Alert.Domain.AlarmHistories.Aggregates.AlarmHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AlarmCount")
                        .HasColumnType("int");

                    b.Property<Guid>("AlarmRuleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AlertSeverity")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Creator")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("Duration")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("FirstAlarmTime")
                        .HasColumnType("datetimeoffset");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNotification")
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

                    b.Property<string>("RuleResultItems")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AlarmHistorys", "alert");
                });

            modelBuilder.Entity("Masa.Alert.Domain.AlarmRules.Aggregates.AlarmRule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<string>("MetricMonitorItems")
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

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<string>("WhereExpression")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AlarmRules", "alert");
                });

            modelBuilder.Entity("Masa.Alert.Domain.AlarmRules.Aggregates.AlarmRuleRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AggregateResult")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("AlarmHistoryId")
                        .HasColumnType("uniqueidentifier");

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

                    b.Property<string>("RuleResultItems")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlarmRuleId");

                    b.ToTable("AlarmRuleRecords", "alert");
                });

            modelBuilder.Entity("Masa.Alert.Domain.WebHooks.Aggregates.WebHook", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Creator")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModificationTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Modifier")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SecretKey")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WebHooks", "alert");
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

            modelBuilder.Entity("Masa.Alert.Domain.AlarmHistories.Aggregates.AlarmHistory", b =>
                {
                    b.OwnsOne("Masa.Alert.Domain.AlarmHistories.Aggregates.AlarmHandle", "Handle", b1 =>
                        {
                            b1.Property<Guid>("AlarmHistoryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Handler")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("Handler");

                            b1.Property<bool>("IsHandleNotice")
                                .HasColumnType("bit")
                                .HasColumnName("IsHandleNotice");

                            b1.Property<string>("NotificationConfig")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("HandleNotificationConfig");

                            b1.Property<int>("Status")
                                .HasColumnType("int")
                                .HasColumnName("HandleStatus");

                            b1.Property<Guid>("WebHookId")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("WebHookId");

                            b1.HasKey("AlarmHistoryId");

                            b1.ToTable("AlarmHistorys", "alert");

                            b1.WithOwner()
                                .HasForeignKey("AlarmHistoryId");
                        });

                    b.OwnsMany("Masa.Alert.Domain.AlarmHistories.Aggregates.AlarmHandleStatusCommit", "HandleStatusCommits", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("AlarmHistoryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<DateTimeOffset>("CreationTime")
                                .HasColumnType("datetimeoffset");

                            b1.Property<string>("Remarks")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<int>("Status")
                                .HasColumnType("int");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.HasKey("Id");

                            b1.HasIndex("AlarmHistoryId");

                            b1.ToTable("AlarmHandleStatusCommits", "alert");

                            b1.WithOwner()
                                .HasForeignKey("AlarmHistoryId");
                        });

                    b.Navigation("Handle")
                        .IsRequired();

                    b.Navigation("HandleStatusCommits");
                });

            modelBuilder.Entity("Masa.Alert.Domain.AlarmRules.Aggregates.AlarmRule", b =>
                {
                    b.OwnsMany("Masa.Alert.Domain.AlarmRules.Aggregates.AlarmRuleItem", "Items", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("AlarmRuleId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("AlertSeverity")
                                .HasColumnType("int");

                            b1.Property<string>("Expression")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<bool>("IsNotification")
                                .HasColumnType("bit");

                            b1.Property<bool>("IsRecoveryNotification")
                                .HasColumnType("bit");

                            b1.Property<string>("NotificationConfig")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("RecoveryNotificationConfig")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("Id");

                            b1.HasIndex("AlarmRuleId");

                            b1.ToTable("AlarmRuleItems", "alert");

                            b1.WithOwner()
                                .HasForeignKey("AlarmRuleId");
                        });

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

                    b.Navigation("Items");

                    b.Navigation("SilenceCycle")
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
                });
#pragma warning restore 612, 618
        }
    }
}