﻿using NetX.Ddd.Domain.Aggregates;

namespace NetX.RBAC.Models;

/// <summary>
/// 
/// </summary>
public class sys_api : BaseEntity<string>
{
    /// <summary>
    /// 
    /// </summary>
    public string path { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string group { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string method { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTime createtime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string description { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public bool issystem { get; set; }
}
