﻿using NetX.Ddd.Domain;
using NetX.Ddd.Domain.Aggregates;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetX.RBAC.Models;

/// <summary>
/// 
/// </summary>
[UPKey("userid", "roleid")]
public class sys_user_role : BaseEntity<string>
{
    [NotMapped]
    public new string Id { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string userid { get; set; }
    /// <summary>
    /// 
    /// </summary>
    public string roleid { get; set; }
}
