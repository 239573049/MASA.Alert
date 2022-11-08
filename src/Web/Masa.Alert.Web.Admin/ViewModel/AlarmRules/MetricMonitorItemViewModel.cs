﻿// Copyright (c) MASA Stack All rights reserved.
// Licensed under the Apache License. See LICENSE.txt in the project root for license information.

namespace Masa.Alert.Web.Admin.ViewModel.AlarmRules;

public class MetricMonitorItemViewModel
{
    public string Name { get; set; } = default!;

    public string Tag { get; set; } = default!;

    public ComparisonOperator ComparisonOperator { get; set; } = ComparisonOperator.GreaterThan;

    public string Value { get; set; } = default!;

    public AggregationTypes AggregationType { get; set; } = AggregationTypes.BeEqualTo;

    public string Alias { get; set; } = default!;

    public bool IsOffset { get; set; }

    public int OffsetPeriod { get; set; }
}