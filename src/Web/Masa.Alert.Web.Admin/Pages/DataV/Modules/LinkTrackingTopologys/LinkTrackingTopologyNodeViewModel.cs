﻿// Copyright (c) MASA Stack All rights reserved.
// Licensed under the Apache License. See LICENSE.txt in the project root for license information.

namespace Masa.Alert.Web.Admin.Pages.DataV.Modules.LinkTrackingTopologys;

public class LinkTrackingTopologyNodeViewModel
{
    public string Id { get; set; } = default!;

    public string Label { get; set; } = default!;

    public int Depth { get; set; }

    public LinkTrackingTopologyStatuses State { get; set; }

    public int X { get; set; }

    public int Y { get; set; }
}