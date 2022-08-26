﻿using Microsoft.AspNetCore.Mvc.Filters;
using NetX.Common;
using NetX.DatabaseSetup;
using NetX.Tenants;
using System.Security.Claims;

namespace NetX.App;

/// <summary>
/// TenantContext过滤器
/// </summary>
public class TenantContextFilter : BaseFilter, IResourceFilter, IAsyncResourceFilter
{
    private readonly ITenantAccessor<Tenant> _accessor;
    //private readonly IServiceProvider _serviceProvider;
    private readonly TenantOption _tenantOption;
    private readonly MigrationService _migrationService;

    /// <summary>
    /// TenantContext资源过滤器实例
    /// </summary>
    /// <param name="accessor"></param>
    /// <param name="tenantOption"></param>
    /// <param name="migrationService"></param>
    /// <param name="dbAccessor"></param>
    public TenantContextFilter(ITenantAccessor<Tenant> accessor, TenantOption tenantOption, MigrationService migrationService)
    {
        _accessor = accessor;
        _tenantOption = tenantOption;
        _migrationService = migrationService;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public void OnResourceExecuted(ResourceExecutedContext context)
    {

    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    public void OnResourceExecuting(ResourceExecutingContext context)
    {
        var identity = context.HttpContext.User.Identity as ClaimsIdentity;
        if(null != _accessor.Tenant)
        {
            if (TenantContext.Current.Principal == null)
                TenantContext.Current.Init(new NetXPrincipal(identity, _accessor.Tenant, _tenantOption));
            else
                TenantContext.Current.Principal.SetIdentityInfo(identity);
            _migrationService.SetupDatabase();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="next"></param>
    /// <returns></returns>
    public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next)
    {
        OnResourceExecuting(context);
        OnResourceExecuted(await next());
    }
}
