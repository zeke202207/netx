﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetX.Common.ModuleInfrastructure;

/// <summary>
/// 返回分页结果集
/// </summary>
/// <typeparam name="T"></typeparam>
public class PagerResultModel<T>
{
    /// <summary>
    /// 总数
    /// </summary>
    [JsonProperty("total")]
    public int Total { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [JsonProperty("items")]
    public T Items { get; set; }
}
