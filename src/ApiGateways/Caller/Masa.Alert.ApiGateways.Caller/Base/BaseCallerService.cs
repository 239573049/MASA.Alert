﻿namespace Masa.Alert.ApiGateways.Caller.Base;

public abstract class ServiceBase
{
    protected ICaller Caller { get; init; }

    protected abstract string BaseUrl { get; set; }

    protected ServiceBase(ICaller caller)
    {
        Caller = caller;
    }

    protected async Task<TResponse> GetAsync<TResponse>(string methodName, Dictionary<string, string>? paramters = null)
    {
        return await Caller.GetAsync<TResponse>(BuildAdress(methodName), paramters ?? new()) ?? throw new UserFriendlyException("The service is abnormal, please contact the administrator!");
    }

    protected async Task<TResponse> GetAsync<TRequest, TResponse>(string methodName, TRequest data) where TRequest : class
    {
        return await Caller.GetAsync<TRequest, TResponse>(BuildAdress(methodName), data) ?? throw new UserFriendlyException("The service is abnormal, please contact the administrator!");
    }

    protected async Task PutAsync<TRequest>(string methodName, TRequest data)
    {
        await Caller.PutAsync(BuildAdress(methodName), data);
    }

    protected async Task PostAsync<TRequest>(string methodName, TRequest data)
    {
        await Caller.PostAsync(BuildAdress(methodName), data);
    }

    protected async Task DeleteAsync<TRequest>(string methodName, TRequest? data = default)
    {
        await Caller.DeleteAsync(BuildAdress(methodName), data);
    }

    protected async Task DeleteAsync(string methodName)
    {
        await Caller.DeleteAsync(BuildAdress(methodName), null);
    }

    protected async Task SendAsync<TRequest>(string methodName, TRequest? data = default)
    {
        if (methodName.StartsWith("Add"))
        {
            await PostAsync(methodName, data);
        }
        else if (methodName.StartsWith("Update"))
        {
            await PutAsync(methodName, data);
        }
        else if (methodName.StartsWith("Remove") || methodName.StartsWith("Delete"))
        {
            await DeleteAsync(methodName, data);
        }
    }

    protected async Task<TResponse> SendAsync<TRequest, TResponse>(string methodName, TRequest data) where TRequest : class
    {
        return await Caller.GetAsync<TRequest, TResponse>(BuildAdress(methodName), data) ?? throw new Exception("The service is abnormal, please contact the administrator!");
    }

    private string BuildAdress(string methodName)
    {
        return Path.Combine(BaseUrl, methodName.Replace("Async", ""));
    }
}
