﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetX.Module;
using System.Collections.Concurrent;

namespace NetX.App;

/// <summary>
/// <see cref="WebApplication"/> 方式进行配置
/// </summary>
public sealed class RunOption
{
    /// <summary>
    /// 自定义builder委托<see cref="WebApplicationBuilder"/>
    /// </summary>
    internal Action<WebApplicationBuilder>? ActionBuilder;

    /// <summary>
    /// <see cref="WebApplication"/>
    /// </summary>
    internal Action<WebApplication>? ActionConfigure;

    /// <summary>
    /// <see cref="ConfigurationManager"/>
    /// </summary>
    internal Action<ConfigurationManager>? ActionConfigrationManager;

    /// <summary>
    /// 启动参数
    /// 配置服务注入与中间件注册
    /// 注入顺序
    /// 系统组件注入 -> 启动参数组件注入 -> 用户自定义模块组件注入
    /// </summary>
    internal Action<IServiceCollection, IConfiguration>? ActionServiceCollection { get; set; }

    /// <summary>
    /// <see cref="WebApplicationOptions"/>
    /// </summary>
    internal WebApplicationOptions? Options { get; set; }

    /// <summary>
    /// <see cref="WebApplicationBuilder"/>
    /// </summary>
    internal WebApplicationBuilder? Builder { get; set; }

    /// <summary>
    /// <see cref="WebApplication"/>
    /// </summary>
    internal WebApplication? App { get; set; }

    /// <summary>
    /// 应用服务组件
    /// </summary>
    internal Dictionary<Guid, ModuleOptions> Modules { get; private set; } = new();

    /// <summary>
    /// 默认配置项
    /// </summary>
    public static RunOption Default { get; } = new RunOption();

    /// <summary>
    /// 内部配置类实例
    /// </summary>
    internal RunOption()
    {
        InitModules();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
    /// <returns></returns>
    public RunOption ConfigOption(WebApplicationOptions options)
    {
        Options = options;
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    /// <returns></returns>
    public RunOption ConfigBuilder(Action<WebApplicationBuilder> builder)
    {
        ActionBuilder = builder;
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="application"></param>
    /// <returns></returns>
    public RunOption ConfigApplication(Action<WebApplication> application)
    {
        ActionConfigure = application;
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="configrationManager"></param>
    /// <returns></returns>
    public RunOption ConfigrationManager(Action<ConfigurationManager> configrationManager)
    {
        ActionConfigrationManager = configrationManager;
        return this;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="configServiceCollection"></param>
    /// <returns></returns>
    public RunOption ConfigrationServiceCollection(Action<IServiceCollection, IConfiguration> configServiceCollection)
    {
        ActionServiceCollection = configServiceCollection;
        return this;
    }

    /// <summary>
    /// 初始化加载模块:系统模块\业务模块
    /// </summary>
    private void InitModules()
    {
        if (null == Modules)
            Modules = new();
        Modules.Clear();
        //添加业务自定义模块
        InitUserModules();
    }

    /// <summary>
    /// 初始化用户自定义模块
    /// </summary>
    private void InitUserModules()
    {
        //加载用户模块
        var modelPath = Path.Combine(AppContext.BaseDirectory, ModuleSetupConst.C_MODULE_DIRECTORYNAME);
        if (!Directory.Exists(modelPath))
            Directory.CreateDirectory(modelPath);
        var di = new DirectoryInfo(modelPath);
        di.GetFiles("*.json", SearchOption.AllDirectories).Where(fi => fi.Name.ToLower().Equals(ModuleSetupConst.C_MODULE_CINFIGFILENAME))
            ?.ToList().ForEach(fi =>
            {
                if (string.IsNullOrEmpty(fi.DirectoryName))
                    return;
                var builder = new ConfigurationBuilder()
                .SetBasePath(fi.DirectoryName)
                .AddJsonFile(fi.Name)
                .Build();
                var options = builder.Get<ModuleOptions>();
                if (null == options)
                    return;
                var refDir = Path.Combine(fi.DirectoryName, ModuleSetupConst.C_MODULE_REFDIRECTORYNAME);
                if (Directory.Exists(refDir))
                    Directory.EnumerateFiles(refDir, "*.dll")
                    .ToList().ForEach(p => options.Dependencies.Add(p));
                Modules.Add(options.Id, options);
                InternalApp.UserModeulOptions.Add(options);
            });
    }

    /// <summary>
    /// 添加模块
    /// </summary>
    /// <param name="option"></param>
    public void AddMoudleOption(ModuleOptions option)
    {
        if (null == option)
            return;
        var opt = InternalApp.UserModeulOptions.FirstOrDefault(p => p.Id == option.Id);
        if (null == opt)
            InternalApp.UserModeulOptions.Add(option);
        else
        {
            ConcurrentBag<ModuleOptions> temp = new();
            foreach (var item in InternalApp.UserModeulOptions)
            {
                if (item.Id == option.Id)
                {
                    temp.Add(option);
                    continue;
                }
                temp.Add(item);
            }
            InternalApp.UserModeulOptions = temp;
        }
    }
}

