﻿// Copyright (c) MASA Stack All rights reserved.
// Licensed under the Apache License. See LICENSE.txt in the project root for license information.

global using BlazorComponent;
global using BlazorComponent.I18n;
global using Masa.Blazor;
global using Masa.Alert.Web.Admin.Global;
global using Microsoft.AspNetCore.Components;
global using Microsoft.AspNetCore.Components.Forms;
global using Microsoft.AspNetCore.Components.Web;
global using Microsoft.AspNetCore.Http;
global using System.ComponentModel;
global using System.ComponentModel.DataAnnotations;
global using System.Net.Http.Json;
global using System.Reflection;
global using System.Text.Json;
global using Masa.Alert.Infrastructure.Ddd.Application.Contracts.Dtos;
global using Mapster;
global using Masa.Alert.Infrastructure.Common.Helper;
global using Masa.Alert.ApiGateways.Caller;
global using FluentValidation;
global using Masa.Alert.Infrastructure.Common.Extensions;
global using System.Text;
global using Microsoft.AspNetCore.SignalR.Client;
global using Masa.Alert.Contracts.Admin.Consts;
global using BlazorDownloadFile;
global using Microsoft.JSInterop;
global using Masa.Blazor.Components.Editor;
global using Microsoft.Extensions.DependencyInjection;
global using Masa.Utils.Data.Elasticsearch;
global using Masa.Contrib.SearchEngine.AutoComplete;
global using Masa.BuildingBlocks.SearchEngine.AutoComplete;
global using Masa.BuildingBlocks.SearchEngine.AutoComplete.Options;
global using Masa.Stack.Components;
global using Masa.Stack.Components.Models;
global using System.Collections.Concurrent;
global using Masa.Alert.Web.Admin.ViewModel.AlarmRules;
global using Microsoft.AspNetCore.Components.Rendering;
global using BlazorComponent.Helpers;
global using Masa.Alert.Application.Contracts.AlarmRules;
global using Masa.Alert.Web.Admin.Pages.AlarmRules.Modules;
global using Masa.Alert.Domain.Shared.AlarmRules;
global using static Masa.Stack.Components.JsInitVariables;
global using Masa.Alert.Web.Admin.ViewModel.Enums;
global using Masa.Alert.Infrastructure.Common.Utils;
global using Masa.Alert.Application.Contracts.AlarmHistory.Dtos;
global using Masa.Alert.Application.Contracts.AlarmRules.Dtos;
global using Masa.Alert.Domain.Shared.AlarmHistory;
global using Masa.Alert.Web.Admin.ViewModel.AlarmHistory;
global using Masa.BuildingBlocks.StackSdks.Mc.Enum;
global using Masa.Contrib.StackSdks.Mc.Service;
global using System.Reflection.PortableExecutable;
global using Masa.Alert.Web.Admin.Components.Modules.Alarm;
global using Masa.Alert.Web.Admin.Pages.AlarmHistory.Modules;
global using System.Linq.Expressions;
global using Masa.Stack.Components.Layouts;
global using Masa.Alert.Application.Contracts.WebHooks.Dtos;
global using Masa.Alert.Web.Admin.ViewModel.WebHooks;
global using Masa.Alert.Web.Admin.Pages.WebHooks.Modules;