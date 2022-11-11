﻿// Copyright (c) MASA Stack All rights reserved.
// Licensed under the Apache License. See LICENSE.txt in the project root for license information.

using Masa.Alert.Infrastructure.Common.Extensions;
using Masa.Mc.Service.Admin.Application.MessageTasks.Commands;

namespace Masa.Alert.Application.AlarmRules.Commands;

public class AlarmRuleCommandHandler
{
    private readonly IAlarmRuleRepository _repository;

    public AlarmRuleCommandHandler(IAlarmRuleRepository repository)
    {
        _repository = repository;
    }

    [EventHandler]
    public async Task CreateAsync(CreateAlarmRuleCommand createCommand)
    {
        await ValidateAlarmRuleNameAsync(createCommand.AlarmRule.DisplayName, null);

        var entity = createCommand.AlarmRule.Adapt<AlarmRule>();

        await _repository.AddAsync(entity);
    }

    [EventHandler]
    public async Task UpdateAsync(UpdateAlarmRuleCommand updateCommand)
    {
        await ValidateAlarmRuleNameAsync(updateCommand.AlarmRule.DisplayName, updateCommand.AlarmRuleId);

        var queryable = await _repository.WithDetailsAsync();
        var entity = await queryable.FirstOrDefaultAsync(x => x.Id == updateCommand.AlarmRuleId);

        Check.NotNull(entity, "alarmRule not found");

        entity.Items.RemoveAll(x => !updateCommand.AlarmRule.Items.Any(y => y.Id == x.Id));
        updateCommand.AlarmRule.Adapt(entity);

        await _repository.UpdateAsync(entity);
    }

    [EventHandler]
    public async Task DeleteAsync(DeleteAlarmRuleCommand createCommand)
    {
        var entity = await _repository.FindAsync(x => x.Id == createCommand.AlarmRuleId);

        Check.NotNull(entity, "alarmRule not found");

        await _repository.RemoveAsync(entity);
    }

    [EventHandler]
    public async Task EnabledAsync(EnabledAlarmRuleCommand command)
    {
        var entity = await _repository.FindAsync(x => x.Id == command.AlarmRuleId);

        Check.NotNull(entity, "alarmRule not found");

        entity.SetEnabled();
        await _repository.UpdateAsync(entity);
    }

    [EventHandler]
    public async Task DisableAsync(DisableAlarmRuleCommand command)
    {
        var entity = await _repository.FindAsync(x => x.Id == command.AlarmRuleId);

        Check.NotNull(entity, "alarmRule not found");

        entity.SetDisable();
        await _repository.UpdateAsync(entity);
    }

    private async Task ValidateAlarmRuleNameAsync(string displayName, Guid? id)
    {
        if (await _repository.FindAsync(x => x.DisplayName == displayName && x.Id != id) != null)
        {
            throw new UserFriendlyException("alarmRule name cannot be repeated");
        }
    }
}
