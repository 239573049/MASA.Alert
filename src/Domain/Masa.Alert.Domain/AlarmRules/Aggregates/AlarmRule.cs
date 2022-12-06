﻿namespace Masa.Alert.Domain.AlarmRules.Aggregates;

public class AlarmRule : FullAggregateRoot<Guid, Guid>
{
    public string DisplayName { get; protected set; } = string.Empty;

    public AlarmRuleTypes Type { get; protected set; }

    public string ProjectIdentity { get; protected set; } = string.Empty;

    public string AppIdentity { get; protected set; } = string.Empty;

    public bool IsEnabled { get; protected set; }

    public string ChartYAxisUnit { get; protected set; } = string.Empty;

    public CheckFrequency CheckFrequency { get; protected set; } = default!;

    public bool IsGetTotal { get; protected set; }

    public string TotalVariable { get; protected set; } = "total";

    public string WhereExpression { get; protected set; } = string.Empty;

    public int ContinuousTriggerThreshold { get; protected set; }

    public SilenceCycle SilenceCycle { get; protected set; } = default!;

    public List<LogMonitorItem> LogMonitorItems { get; protected set; } = new();

    public List<MetricMonitorItem> MetricMonitorItems { get; protected set; } = new();

    public ICollection<AlarmRuleItem> Items { get; protected set; } = new Collection<AlarmRuleItem>();

    public virtual IEnumerable<AlarmRuleRecord> AlarmRuleRecords => LazyLoader.Load(this, ref _alarmRuleRecords!, nameof(AlarmRuleRecords))!;

    public Guid SchedulerJobId { get; protected set; } = default;

    private List<AlarmRuleRecord> _alarmRuleRecords = default!;

    private Action<object, string> LazyLoader { get; set; } = default!;

    private AlarmRule(Action<object, string> lazyLoader)
    {
        LazyLoader = lazyLoader;
    }

    public AlarmRule(string displayName, AlarmRuleTypes type, string projectIdentity, string appIdentity, bool isEnabled, string chartYAxisUnit
        , CheckFrequency checkFrequency, bool isGetTotal, string totalVariable, string whereExpression, int continuousTriggerThreshold, SilenceCycle silenceCycle)
    {
        DisplayName = displayName;
        Type = type;
        ProjectIdentity = projectIdentity;
        AppIdentity = appIdentity;
        IsGetTotal = isGetTotal;
        TotalVariable = totalVariable;
        WhereExpression = whereExpression;

        SetEnabled(isEnabled);
        SetChartConfig(chartYAxisUnit);
        SetCheckFrequency(checkFrequency);
        SetAdvancedConfig(continuousTriggerThreshold, silenceCycle);
        _alarmRuleRecords = new List<AlarmRuleRecord>();
    }

    public AlarmRuleRecord? GetLatest()
    {
        LazyLoader.Load(this, ref _alarmRuleRecords!, nameof(AlarmRuleRecords));
        return _alarmRuleRecords.Where(x => x.AlarmRuleId == Id).OrderByDescending(x => x.ExcuteTime).FirstOrDefault();
    }

    public long? GetOffsetResult(int offsetPeriod, string alias)
    {
        LazyLoader.Load(this, ref _alarmRuleRecords!, nameof(AlarmRuleRecords));

        var offsetRecord = _alarmRuleRecords.Where(x => x.AlarmRuleId == Id).OrderByDescending(x => x.ExcuteTime).Skip(offsetPeriod - 1).FirstOrDefault();

        return offsetRecord?.AggregateResult.FirstOrDefault(x => x.Key == alias).Value;
    }

    public string GetCronExpression()
    {
        return CheckFrequency.GetCronExpression();
    }

    public DateTimeOffset? GetStartCheckTime(DateTimeOffset checkTime, AlarmRuleRecord? latest)
    {
        if (CheckFrequency.Type == AlarmCheckFrequencyTypes.Cron && latest == null)
        {
            return null;
        }

        if (CheckFrequency.Type == AlarmCheckFrequencyTypes.Cron)
        {
            return latest?.ExcuteTime;
        }

        if (CheckFrequency.Type == AlarmCheckFrequencyTypes.FixedInterval)
        {
            var intervalTime = CheckFrequency.FixedInterval.GetIntervalTime();
            return checkTime.Add(-intervalTime);
        }

        return null;
    }

    public DateTimeOffset? GetSilenceEndTime(DateTimeOffset lastNotificationTime)
    {
        if (SilenceCycle.Type == SilenceCycleTypes.Time)
        {
            var intervalTime = SilenceCycle.TimeInterval.GetIntervalTime();
            return lastNotificationTime.Add(intervalTime);
        }

        if (SilenceCycle.Type == SilenceCycleTypes.Cycle)
        {
            return GetSilenceEndTimeByCycle(lastNotificationTime);
        }

        return null;
    }

    public DateTimeOffset? GetSilenceEndTimeByCycle(DateTimeOffset lastTime)
    {
        if (CheckFrequency.Type == AlarmCheckFrequencyTypes.FixedInterval)
        {
            var intervalTime = CheckFrequency.FixedInterval.GetIntervalTime();

            for (int i = 0; i < SilenceCycle.SilenceCycleValue; i++)
            {
                lastTime = lastTime.Add(intervalTime);
            }
            return lastTime;
        }

        if (CheckFrequency.Type == AlarmCheckFrequencyTypes.Cron)
        {
            var cronExpression = new CronExpression(CheckFrequency.CronExpression);

            var timezone = TimeZoneInfo.FindSystemTimeZoneById("China Standard Time");

            if (timezone != null)
                cronExpression.TimeZone = timezone;

            for (int i = 0; i < SilenceCycle.SilenceCycleValue; i++)
            {
                var nextExcuteTime = cronExpression.GetNextValidTimeAfter(lastTime);
                if (nextExcuteTime.HasValue)
                {
                    lastTime = nextExcuteTime.Value;
                }
            }

            return lastTime;
        }

        return null;
    }

    public void SetEnabled()
    {
        IsEnabled = true;
    }

    public void SetDisable()
    {
        IsEnabled = false;
    }

    public void SetChartConfig(string chartYAxisUnit)
    {
        ChartYAxisUnit = chartYAxisUnit;
    }

    public void SetLogMonitorConfig(List<LogMonitorItem> items, bool isGetTotal, string totalVariable, string whereExpression)
    {
        LogMonitorItems = items;
        IsGetTotal = isGetTotal;
        TotalVariable = totalVariable;
        WhereExpression = whereExpression;
    }

    public void SetAdvancedConfig(int continuousTriggerThreshold, SilenceCycle silenceCycle)
    {
        ContinuousTriggerThreshold = continuousTriggerThreshold;
        SilenceCycle = silenceCycle;
    }

    public void Check(DateTimeOffset excuteTime, ConcurrentDictionary<string, long> aggregateResult, List<RuleResultItem> ruleResult)
    {
        var latestRecord = GetLatest();
        var consecutiveCount = latestRecord?.ConsecutiveCount ?? 0;
        var isTrigger = ruleResult.Any(x => x.IsValid);

        if (isTrigger)
        {
            consecutiveCount++;
        }
        else
        {
            consecutiveCount = 0;
        }

        _alarmRuleRecords.Add(new AlarmRuleRecord(Id, aggregateResult, isTrigger, consecutiveCount, excuteTime, ruleResult));

        if (isTrigger && consecutiveCount >= ContinuousTriggerThreshold)
        {
            var alertSeverity = ruleResult.Where(x => x.IsValid).Min(x => x.AlarmRuleItem.AlertSeverity);

            AddDomainEvent(new TriggerAlarmEvent(Id, alertSeverity, ruleResult));
        }
        else if (latestRecord != null && latestRecord.IsTrigger)
        {
            AddDomainEvent(new RecoveryAlarmEvent(Id));
        }
    }

    public void SkipCheck(DateTimeOffset excuteTime)
    {
        _alarmRuleRecords.Add(new AlarmRuleRecord(Id, new ConcurrentDictionary<string, long>(), false, 0, excuteTime, new List<RuleResultItem>()));
    }

    public bool CheckIsNotification(DateTimeOffset? lastNotificationTime)
    {
        if (!Items.Any(x => x.IsNotification))
        {
            return false;
        }

        if (!lastNotificationTime.HasValue)
        {
            return true;
        }

        var silenceEndTime = GetSilenceEndTime(lastNotificationTime.Value);

        if (!silenceEndTime.HasValue || DateTimeOffset.Now > silenceEndTime)
        {
            return true;
        }

        return false;
    }

    public void SetCheckFrequency(CheckFrequency checkFrequency)
    {
        if (Id == default)
        {
            Id = IdGeneratorFactory.SequentialGuidGenerator.NewId();
        }

        if (IsEnabled && CheckFrequency.GetCronExpression() != checkFrequency.GetCronExpression())
        {
            AddDomainEvent(new UpsertAlarmRuleJobEvent(Id));
        }

        CheckFrequency = checkFrequency;
    }

    public void SetSchedulerJobId(Guid schedulerJobId)
    {
        SchedulerJobId = schedulerJobId;
    }

    public void SetEnabled(bool isEnabled)
    {
        if (Id != default)
        {
            if (IsEnabled != isEnabled)
            {
                if (isEnabled && SchedulerJobId == default)
                {
                    AddDomainEvent(new UpsertAlarmRuleJobEvent(Id));
                }
                else if (isEnabled)
                {
                    AddDomainEvent(new EnableAlarmRuleJobEvent(Id));
                }
                else
                {
                    AddDomainEvent(new DisableAlarmRuleJobEvent(Id));
                }
            }
        }

        IsEnabled = isEnabled;
    }
}
