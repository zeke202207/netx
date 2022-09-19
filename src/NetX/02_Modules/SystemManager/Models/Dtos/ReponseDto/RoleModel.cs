﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NetX.SystemManager.Models;

public class RoleModel
{
    [JsonPropertyName("id")]
    public string Id { get;set; }
    [JsonPropertyName("rolename")]
    public string RoleName { get; set; }
    [JsonPropertyName("status")]
    public string Status { get; set; }
    [JsonPropertyName("createtime")]
    public DateTime CreateTime { get; set; }
    [JsonPropertyName("menu")]
    public List<string> Menus { get; set; }
    [JsonPropertyName("remark")]
    public string Remark { get; set; }
}
