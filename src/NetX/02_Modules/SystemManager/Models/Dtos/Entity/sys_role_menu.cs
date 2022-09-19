﻿using FreeSql.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetX.SystemManager.Models.Dtos.Entity
{
    public class sys_role_menu
    {
        [Column(IsPrimary = true)]
        public string roleid { get; set; }
        [Column(IsPrimary = true)]
        public string menuid { get; set; }
    }
}
