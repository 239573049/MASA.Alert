﻿// Copyright (c) MASA Stack All rights reserved.
// Licensed under the Apache License. See LICENSE.txt in the project root for license information.

namespace Masa.Alert.Domain.AlarmRules.Aggregates;

public class TimeInterval : ValueObject
{
    public int IntervalTime { get; protected set; }

    public TimeType IntervalTimeType { get; protected set; }

    protected override IEnumerable<object> GetEqualityValues()
    {
        yield return IntervalTime;
        yield return IntervalTimeType;
    }

    public TimeInterval(int intervalTime, TimeType intervalTimeType)
    {
        IntervalTime = intervalTime;
        IntervalTimeType = intervalTimeType;
    }

    public TimeSpan GetIntervalTime()
    {
        return IntervalTimeType.GetIntervalTime(IntervalTime);
    }

    public string GetCronExpression()
    {
        return IntervalTimeType.GetCronExpression(IntervalTime);
    }
}
