﻿// Copyright (c) MASA Stack All rights reserved.
// Licensed under the Apache License. See LICENSE.txt in the project root for license information.

global using System.Text.Json;
global using Dapr.Actors;
global using Dapr.Actors.Client;
global using Dapr.Actors.Runtime;
global using FluentValidation;
global using FluentValidation.AspNetCore;
global using Masa.BuildingBlocks.Data.UoW;
global using Masa.BuildingBlocks.Ddd.Domain.Entities;
global using Masa.BuildingBlocks.Ddd.Domain.Entities.Auditing;
global using Masa.BuildingBlocks.Ddd.Domain.Events;
global using Masa.BuildingBlocks.Ddd.Domain.Repositories;
global using Masa.BuildingBlocks.Dispatcher.Events;
global using Masa.BuildingBlocks.Dispatcher.IntegrationEvents;
global using Masa.Contrib.Configuration;
global using Masa.Contrib.Data.UoW.EFCore;
global using Masa.Contrib.Ddd.Domain;
global using Masa.Contrib.Ddd.Domain.Repository.EFCore;
global using Masa.Contrib.Dispatcher.Events;
global using Masa.Contrib.Dispatcher.Events.Enums;
global using Masa.Contrib.Dispatcher.IntegrationEvents.Dapr;
global using Masa.Contrib.Dispatcher.IntegrationEvents.EventLogs.EFCore;
global using Masa.Contrib.Service.MinimalAPIs;
global using Masa.Alert.Infrastructure.Ddd.Application.Contracts.Dtos;
global using Microsoft.AspNetCore.Authentication.JwtBearer;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.OpenApi.Models;
global using System.Linq.Expressions;
global using Masa.Alert.Infrastructure.EntityFrameworkCore.EntityFrameworkCore.ValueConverters;
global using System.Collections.Concurrent;
global using Microsoft.AspNetCore.Mvc;
global using Mapster;
global using MapsterMapper;
global using System.Reflection;
global using System.Linq;
global using Masa.Alert.Infrastructure.Common.Helper;
global using Masa.Alert.Infrastructure.Common.Extensions;
global using System.Collections.ObjectModel;
global using Masa.Contrib.Isolation.UoW.EFCore;
global using Masa.Contrib.Isolation.MultiEnvironment;
global using Masa.Contrib.Data.Contracts.EFCore;
global using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
global using Microsoft.EntityFrameworkCore.ChangeTracking;
global using System.Dynamic;
global using Masa.BuildingBlocks.Ddd.Domain.Entities.Full;
global using Dapr;
global using Microsoft.AspNetCore.SignalR;
global using Microsoft.Extensions.Options;
global using Microsoft.AspNetCore.Authorization;
global using Masa.Alert.Contracts.Admin.Consts;
global using Dapr.Client;
global using Masa.BuildingBlocks.StackSdks.Auth;
global using Masa.BuildingBlocks.StackSdks.Auth.Contracts.Model;
global using Masa.BuildingBlocks.StackSdks.Auth.Contracts.Enum;
global using Masa.Contrib.Dispatcher.IntegrationEvents;
global using Masa.Alert.Infrastructure.Common.Utils;
global using Masa.Contrib.Configuration.ConfigurationApi.Dcc;
global using Masa.BuildingBlocks.Configuration;
global using Microsoft.Extensions.Diagnostics.HealthChecks;
global using Masa.BuildingBlocks.Authentication.Identity;
//global using Masa.Alert.Infrastructure.Tsc;
global using Masa.BuildingBlocks.Data;
global using System.Net;
global using System.Text.RegularExpressions;
global using HealthChecks.UI.Client;
global using Masa.Alert.EntityFrameworkCore;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Lonsid.Fusion.Infrastructure.Middleware;
global using Masa.Alert.Application.Contracts.AlarmRules.Dtos;
global using Masa.Alert.Domain.Shared.AlarmRules;
global using static Masa.Alert.Application.Contracts.AlarmRules.Dtos.GetAlarmRuleInputDto;
global using Masa.Alert.Application.AlarmRules.Queries;
global using Masa.Alert.Application.AlarmRules.Commands;
global using Masa.Contrib.Caching.Distributed.StackExchangeRedis;
global using Masa.Alert.Application.Contracts.QueryContext;
global using Microsoft.Extensions.DependencyInjection;