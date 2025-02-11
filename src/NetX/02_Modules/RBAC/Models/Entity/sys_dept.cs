﻿using NetX.Ddd.Domain.Aggregates;

namespace NetX.RBAC.Models;

/// <summary>
/// 
/// </summary>
public class sys_dept : BaseEntity<string>
{
    /// <summary>
    /// 
    /// </summary>
    public string parentid { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string deptname { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int orderno { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public DateTime createtime { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public int status { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string? remark { get; set; }
}
