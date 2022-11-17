﻿namespace Masa.Alert.ApiGateways.Caller;

public class AlertCaller : DaprCallerBase
{
    TokenProvider _tokenProvider;

    protected override string AppId { get; set; } = App.APP;

    public override string? Name { get; set; } = nameof(AlertCaller);

    private AlarmRuleService? _alarmRuleService;
    private AlarmHistoryService? _alarmHistoryService;

    public AlarmRuleService AlarmRuleService => _alarmRuleService ??= new(Caller);
    public AlarmHistoryService AlarmHistoryService => _alarmHistoryService ??= new(Caller);

    public AlertCaller(IServiceProvider serviceProvider
        , TokenProvider tokenProvider)
        : base(serviceProvider)
    {
        _tokenProvider = tokenProvider;
    }

    protected override void ConfigHttpRequestMessage(HttpRequestMessage requestMessage)
    {
        requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _tokenProvider.AccessToken);
        base.ConfigHttpRequestMessage(requestMessage);
    }
}
