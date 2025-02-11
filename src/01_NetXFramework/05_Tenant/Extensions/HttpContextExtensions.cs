﻿using Microsoft.AspNetCore.Http;

namespace NetX.Tenants;

/// <summary>
/// 扩展http上下文
/// </summary>
internal static class HttpContextExtensions
{
    /// <summary>
    /// 获取当前租户信息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="context"></param>
    /// <returns></returns>
    internal static T? GetTenant<T>(this HttpContext context)
        where T : Tenant
    {
        if (!context.Items.ContainsKey(TenantConst.C_TENANT_HTTPCONTEXTTENANTKEY))
            return null;
        return context.Items[TenantConst.C_TENANT_HTTPCONTEXTTENANTKEY] as T;
    }

    /// <summary>
    /// 获取当前租户信息
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    internal static Tenant? GetTenant(this HttpContext context)
    {
        return context.GetTenant<Tenant>();
    }
}
